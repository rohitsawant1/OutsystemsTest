using System;
using System.IO;
using System.Text;
using OutSystems.RuntimeCommon;
using OutSystems.RuntimeCommon.Cryptography;
using OutSystems.RuntimeCommon.Cryptography.VersionedAlgorithms;

using OutSystems.Internal.Db;

#if RUNTIMEPLATFORM
namespace OutSystems.HubEdition.RuntimePlatform {
#else

using OutSystems.HubEdition.RuntimePlatform;

namespace OutSystems.Common {

#endif

internal abstract class AESBase<TAlgorithm> : SingletonVersionedEncryptAlgorithm<TAlgorithm>, SecureConfidentialInformationEncryption.IAlgorithmWithCachedKey where TAlgorithm : AESBase<TAlgorithm>, new() {
        private string key;
        
        private string Key {
            get {
                if (key == null) {
                    key = GetKeyWithoutUsingCache();
                }

                return key;
            }
        }
        
        protected abstract string GetKeyWithoutUsingCache();

        public void ClearCache() {
            key = null;
        }

        protected override string InnerDecrypt(string encryptedValue) {
            return SymmCryptHelper.DecryptWithAES128(Key, encryptedValue);
        }

        protected override string InnerApplyAlgorithm(string value) {
            return SymmCryptHelper.EncryptWithAES128(Key, value);
        }
    }

#if RUNTIMEPLATFORM
    public class AuthenticatedEncryptionWithAssociatedData {

        public static readonly AuthenticatedEncryptionWithAssociatedData Instance = new AuthenticatedEncryptionWithAssociatedData();

        private byte[] _key = null;
        private byte[] Key {
            get {
                if (_key == null) {
                    _key = Convert.FromBase64String(SecureConfidentialInformationEncryption.ReadKeyFromFile(RuntimePlatformSettings.Misc.SettingsKeyPath.GetValue()));
                }
                return _key;
            }
        }

        public byte[] Encrypt(byte[] data, byte[] associatedData) {
            return SymmCryptHelper.EncryptThenMacWithAES(Key, data, associatedData);
        }

        public byte[] Decrypt(byte[] data, byte[] associatedData) {
            return SymmCryptHelper.DecryptThenMacWithAES(Key, data, associatedData);
        }

    }
#endif


    internal sealed class SecureConfidentialInformationEncryption {
        public interface IAlgorithmWithCachedKey {
            void ClearCache();
        }

        public class FixedKeyRC4 : SingletonVersionedEncryptAlgorithm<FixedKeyRC4> {
            protected override string InnerDecrypt(string encryptedValue) {
                return SymmRC4CryptHelper.Decrypt(encryptedValue, SharedKeys.SettingsWeakSymmetricKey());
            }

            protected override string InnerApplyAlgorithm(string value) {
                return SymmRC4CryptHelper.Encrypt(value, SharedKeys.SettingsWeakSymmetricKey());
            }

            public override bool IsSecure {
                get { return false; }
            }
        }

        public class FixedKeyAES128 : AESBase<FixedKeyAES128> {
            protected override string GetKeyWithoutUsingCache() {
                return PasswordHelper.DeriveKeyFromSecret(SharedKeys.ConfidentialInformationSymmetricKey(), 256 / 8);
            }
        }

#if RUNTIMEPLATFORM || SERVERCOMMON

        public class DynamicKeyAES128 : AESBase<DynamicKeyAES128> {
            protected override string GetKeyWithoutUsingCache() {
#if RUNTIMEPLATFORM
                string keyLocation = RuntimePlatformSettings.Misc.SettingsKeyPath.GetValue();
#endif
#if SERVERCOMMON
                string keyLocation = HubEdition.ServerCommon.PlatformSettings.Get(HubEdition.ServerCommon.PlatformSettings.Configs.SettingsKeyPath);
#endif

                if (keyLocation.IsNullOrEmpty()) {
                    throw new InvalidOperationException("Cannot find the private key path");
                }

                return ReadKeyFromFile(keyLocation);
            }
        }

#endif

        /// <summary>
        /// List of algorithms by order of security.
        /// IMPORTANT: don't remove or change the order of the algorithms. If you need to add a more secure algorithm it must be added to the end of this list.
        /// Otherwise you will break the platform encryption mechanism.
        /// </summary>
        private static readonly VersionedEncryptAlgorithms algorithms = new VersionedEncryptAlgorithms(
            FixedKeyRC4.Instance,
            FixedKeyAES128.Instance
#if RUNTIMEPLATFORM || SERVERCOMMON
            , DynamicKeyAES128.Instance
#endif
        );

#if RUNTIMEPLATFORM || SERVERCOMMON

        public static string EncryptWithBestAlgorithm(string text) {
            return algorithms.ApplyBestAlgorithm(text);
        }

        public static string EncryptMaintainingCompatibility(string text) {
            return EncryptMaintainingCompatibility(null, text);
        }

        public static string EncryptMaintainingCompatibility(OutSystems.Internal.Db.Transaction trans, string text) {
            /* This encrypts to the last algorithm that need to be supported everywhere (ie, we known that every published application supports) */
            /* If we need to add a new algorithm we just need to change this method to maintain the compatibility (see P9 code) */
            return EncryptWithBestAlgorithm(text);
        }

        public static VersionedEncryptAlgorithms Algorithms { get { return algorithms; } }

        public static void ClearEncryptionKeyCaches() {
            for (var i = 0; i <= algorithms.BestAlgorithmIndex; i++) {
                var alg = algorithms.GetSpecificAlgorithmFromIndex(i) as IAlgorithmWithCachedKey;

                if (alg != null) {
                    alg.ClearCache();
                }
            }
        }

        [Obsolete("This method should be ONLY used for settings upgrade scenarios.")]
        public static string DecryptForUpgrade(string text) {
            return algorithms.DecryptAllowingInsecureAlgorithms(text);
        }

        public static string EncryptString(string text) {
            return EncryptWithBestAlgorithm(text);
        }

        public static string TryDecryptString(string text) {
            if (!text.IsNullOrEmpty()) {
                try {
                    return Decrypt(text);
                }
                catch (Exception) {
                    //exception not handled
                }
            }
            return text;
        }

#endif

        public static string EncryptWithAlgorithm(string text, IVersionedEncryptAlgorithm algorithm) {
            return algorithms.ApplySpecificAlgorithm(text, algorithm);
        }

        public static string Decrypt(string text) {
            return algorithms.Decrypt(text);
        }

        public static string ReadKeyFromFile(string pathToFile) {
            using (var reader = new StreamReader(pathToFile, Encoding.UTF8)) {
                string line;
                while ((line = reader.ReadLine()) != null) {
                    if (line.StartsWith("--") || (line.Trim().Length == 0)) {
                        continue;
                    }
                    return line.Trim();
                }
            }

            throw new IOException(String.Format("Could not read the key from '{0}'.", pathToFile));
        }
    }
}
