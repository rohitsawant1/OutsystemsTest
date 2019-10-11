/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using OutSystems.RuntimeCommon.Cryptography.Implementations;
using OutSystems.RuntimeCommon.Cryptography.Implementations.Crypt;
using OutSystems.RuntimeCommon.Cryptography.Implementations.Hash;
using OutSystems.RuntimeCommon.Cryptography.Implementations.Signature;
using OutSystems.RuntimeCommon.Cryptography.Interfaces;

namespace OutSystems.RuntimeCommon.Cryptography {

    public class CryptManager {
        private const int DEFAULT_SALT_SIZE = 256;
        
        private static volatile CryptManager _instance;
        private static readonly object _syncRoot = new object();

        public static CryptManager Instance {
            get {
                if (_instance == null) {
                    lock (_syncRoot) {
                        if (_instance == null) {
                            return _instance = new CryptManager();
                        }
                    }
                }
                return _instance;
            }
        }
 
        internal enum EHashType {
            SHA_512_256,
            SHA_512_384,
            SHA_384,
            SHA_256,
            SHA_512,
            SHA_1
        }

        internal enum ESymmetricTransformCryptType {
            AES_256,
            AES_128
        }

        internal enum ESignType {
            HMAC_SHA1,
            HMAC_SHA256
        }

        private static class AlgorithmFactory {
            public static IHashGenerator GetHasher(EHashType type) {
                switch (type) {
                    case EHashType.SHA_512:
                        return new SHA512HashAdapter();
                    case EHashType.SHA_256:
                        return new SHA256HashAdapter();
                    case EHashType.SHA_384:
                        return new SHA384HashAdapter();
                    case EHashType.SHA_512_256:
                        return new SHA512_256HashAdapter();
                    case EHashType.SHA_512_384:
                        return new SHA512_384HashAdapter();
                    case EHashType.SHA_1:
                        return new SHA1HashAdapter();

                }
                return null;
            }

            public static ISymmetricTransformCrypt GetSymmetricTransformCrypt(ESymmetricTransformCryptType type) {
                switch (type) {
                case ESymmetricTransformCryptType.AES_128:
                    return new CryptManagedAdapter(new AES128Managed());
                case ESymmetricTransformCryptType.AES_256:
                    return new CryptManagedAdapter(new AES256Managed());
                }

                return null;
            }

            public static ISignGenerator GetSigner(ESignType type) {
                switch (type) {
                    case ESignType.HMAC_SHA1:
                        return new HMACSHA1HashAdapter();
                    case ESignType.HMAC_SHA256:
                        return new HMACSHA256HashAdapter();

                }
                return null;
            } 
        }

        public Encoding Encoder { get; private set; }

        private IHashGenerator _hashSHA1Generator;
        private IHashGenerator _hashSHA256Generator;
        private IHashGenerator hashSHA512Generator;
        private IHashGenerator defaultHashGenerator;

        private ISignGenerator signHMACSHA1Generator;
        private ISignGenerator signHMACSHA256Generator;

        private ISaltGenerator _saltGenerator;
        private IAsymmetricCrypt _asymmetricCryptGenerator;

        private ISymmetricTransformCrypt aes128;
        private ISymmetricTransformCrypt aes256;

        private CryptManager() {
            Init();
        }
        
        private void Init() {
            _hashSHA1Generator = AlgorithmFactory.GetHasher(EHashType.SHA_1);
            _hashSHA256Generator = AlgorithmFactory.GetHasher(EHashType.SHA_256);
            hashSHA512Generator = AlgorithmFactory.GetHasher(EHashType.SHA_512);
            defaultHashGenerator = hashSHA512Generator;
            signHMACSHA1Generator = AlgorithmFactory.GetSigner(ESignType.HMAC_SHA1);
            signHMACSHA256Generator = AlgorithmFactory.GetSigner(ESignType.HMAC_SHA256);
            _saltGenerator = new SecureRNGAdapter();
            _asymmetricCryptGenerator = new RSAAdapter();

            Encoder = Encoding.UTF8;
            aes128 = AlgorithmFactory.GetSymmetricTransformCrypt(ESymmetricTransformCryptType.AES_128);
            aes256 = AlgorithmFactory.GetSymmetricTransformCrypt(ESymmetricTransformCryptType.AES_256);
        }

        #region EncodingsUtils
        private byte[] Encode(string text){
            return Encoder.GetBytes(text);
        }

        private static byte[] EncodeDefault(string text) {
            return Encoding.Default.GetBytes(text);
        }

        private string Encode(byte[] text) {
            return Encoder.GetString(text);
        }

        private static byte[] EncodeUTF16(string text) {
            return (new UnicodeEncoding()).GetBytes(text);
        }

        internal static string EncodeBase64(byte[] str){
            return Convert.ToBase64String(str);
        }

        private static string EncodeBase64(Guid guid) {
            return Base64.ToBase64(guid);
        }

        internal static byte[] DecodeBase64ToBytes(string str){
            return Convert.FromBase64String(str);
        }
        #endregion

        #region Guids

        private static Guid ToGuid(byte[] data, IHashGenerator hashGenerator) {

            #if DEBUG

            if (data.IsEmpty()) {
                throw  new ArgumentNullException("data");
            }

            #endif
            if (data.IsEmpty()) {
                return  Guid.Empty;
            }

            byte[] value = hashGenerator.Hash(data);
            var destination = new byte[16];
            Array.Copy(value, destination, destination.Length);
            return new Guid(destination);
        }

        private Guid ToGuid(string data, IHashGenerator hashGenerator) {

            #if DEBUG

            if (data.IsEmpty()) {
                throw new ArgumentNullException("data");
            }

            #endif

            return data.IsEmpty()? Guid.Empty: ToGuid(Encode(data), hashGenerator);
        }

        private string ToGuidToBase64(string data, IHashGenerator hashGenerator) {

            #if DEBUG

            if (data.IsEmpty()) {
                throw new ArgumentNullException("data");
            }

            #endif

            return EncodeBase64(data.IsEmpty()? Guid.Empty: ToGuid(data, hashGenerator));
        }
        
        private static Guid ToGuidUsingDefaultEncoding(string text, IHashGenerator hashGenerator) {

            #if DEBUG

            if (text.IsEmpty()) {
                throw new ArgumentNullException("text");
            }

            #endif

            return text.IsEmpty()? Guid.Empty: ToGuid(EncodeDefault(text), hashGenerator);
        }

        private static Guid ToGuidWithSaltAndUTF16(string data, string salt, IHashGenerator hashGenerator) {

            #if DEBUG

            if (data.IsEmpty()) {
                throw new ArgumentNullException("data");
            }

            #endif

            return data.IsEmpty()? Guid.Empty: ToGuid(EncodeUTF16(data + salt), hashGenerator);
        }

        private static string GenerateToBase64UsingDefaultEncoding(string text, IHashGenerator hashGenerator) {
            return Base64.ToBase64(ToGuidUsingDefaultEncoding(text, hashGenerator));
        }

        internal Guid ToGuid(byte[] data) {
            return ToGuid(data, defaultHashGenerator);
        }

        internal Guid ToGuid(string data) {
            return ToGuid(data, defaultHashGenerator);
        }

        internal string ToGuidToBase64(string data) {
            return ToGuidToBase64(data, defaultHashGenerator);
        }

        internal Guid ToGuidUsingDefaultEncoding(string text) {
            return ToGuidUsingDefaultEncoding(text, defaultHashGenerator);
        }

        internal Guid ToGuidWithSaltAndUTF16(string data, string salt) {
            return ToGuidWithSaltAndUTF16(data, salt, defaultHashGenerator);
        }
        
        internal string GenerateToBase64UsingDefaultEncoding(string text) {
            return GenerateToBase64UsingDefaultEncoding(text, defaultHashGenerator);
        }

        #endregion Guids

        #region Password

        private static string HexDeriveUsingUTF16(string plainText, string salt, IHashGenerator hashGenerator) {
            return (BitConverter.ToString(hashGenerator.Hash(EncodeUTF16(plainText + salt)))).Replace("-", "");
        }

        private static int GetHexPasswordsSizeInCharacters(IHashGenerator hashGenerator) {
            // We need to multiply by two because we encode the hash with BitConverter.ToString (puts every byte with two characters)
            return hashGenerator.HashSizeInBytes * 2;
        }

        internal string SHA512HexDeriveUsingUTF16(string plainText, string salt) {
            return HexDeriveUsingUTF16(plainText, salt, hashSHA512Generator);
        }

        internal int SHA512HexPasswordsSizeInCharacters { get { return GetHexPasswordsSizeInCharacters(hashSHA512Generator); } }

        #region Hash

        private static byte[] HashToBytes(byte[] bytes, IHashGenerator hashGenerator) {
            return hashGenerator.Hash(bytes);
        }

        private static string Hash(byte[] bytes, IHashGenerator hashGenerator) {
            return EncodeBase64(hashGenerator.Hash(bytes));
        }

        private string Hash(string plain, IHashGenerator hashGenerator) {
            return EncodeBase64(hashGenerator.Hash(Encode(plain)));
        }
        
        private static string HashUsingDefaultEncoding(string plain, IHashGenerator hashGenerator) {
            return EncodeBase64(hashGenerator.Hash(EncodeDefault(plain)));
        }

        private static string HashUsingUTF16(string bytes, IHashGenerator hashGenerator) {
            return EncodeBase64(hashGenerator.Hash(EncodeUTF16(bytes)));
        }

        internal byte[] HashSHA512ToBytes(byte[] bytes) {
            return HashToBytes(bytes, hashSHA512Generator);
        }

        internal string HashSHA512(byte[] bytes) {
            return Hash(bytes, hashSHA512Generator);
        }

        internal string HashSHA512(string plain) {
            return Hash(plain, hashSHA512Generator);
        }
        
        internal string HashSHA512UsingDefaultEncoding(string plain) {
            return HashUsingDefaultEncoding(plain, hashSHA512Generator);
        }

        internal string HashSHA512UsingUTF16(string bytes) {
            return HashUsingUTF16(bytes, hashSHA512Generator);
        }

        internal byte[] HashSHA256ToBytes(byte[] bytes) {
            return HashToBytes(bytes, _hashSHA256Generator);
        }

        internal string HashSHA1(byte[] bytes) {
            return Hash(bytes, _hashSHA1Generator);
        }

        internal byte[] HashSHA1FromASCIIToBytes(string plain) {
            return _hashSHA1Generator.Hash(Encoding.ASCII.GetBytes(plain));
        }

        internal string HashSHA1FromASCII(string plain) {
            return EncodeBase64(_hashSHA1Generator.Hash(Encoding.ASCII.GetBytes(plain)));
        }
        #endregion

        internal string GenerateStrongPassword() {
            return GenerateStrongPassword(DEFAULT_SALT_SIZE);
        }

        internal string GenerateStrongPassword(int sizeInBytes) {
            return EncodeBase64(_saltGenerator.GetBytes(sizeInBytes));
        }

        internal byte[] GenerateSalt(int sizeInBytes) {
            return _saltGenerator.GetBytes(sizeInBytes);
        }

        #endregion

        #region Signature

        internal string Sign(byte[] bytes, string key) {
            return Sign(bytes, Encode(key));
        }

        internal string Sign(string plainText, string key) {
            return Sign(Encode(plainText), Encode(key));
        }

        private string Sign(byte[] bytes, byte[] key) {
            return EncodeBase64(ByteSign(bytes, key));
        }

        internal byte[] ByteSign(byte[] bytes, byte[] key) {
            return signHMACSHA1Generator.Sign(bytes, key);
        }


        internal byte[] ByteSignHMACSHA256(byte[] bytes, byte[] key) {
            return signHMACSHA256Generator.Sign(bytes, key);
        }

        public static bool SlowEquals(byte[] a, byte[] b) {

            if (a.Length != b.Length) {
                return false;
            }

            int diff = 0;
            for (int i = 0; i < a.Length; i++)
                diff |= a[i] ^ b[i];
            return diff == 0;
        }

        internal static bool SlowEquals(string a, string b) {

            if (a.Length != b.Length) {
                return false;
            }

            int diff = 0;
            for (int i = 0; i < a.Length; i++)
                diff |= a[i] ^ b[i];
            return diff == 0;
        }

        #endregion

        #region SymmetricCrypth

        private static CryptoStream GetEncryptorStream(ISymmetricTransformCrypt transformCrypt, Stream outputStream, byte[] key, byte[] iv) {
            return transformCrypt.GetEncryptorStream(outputStream, new CryptAlgorithmParameters(key, iv));
        }

        private static CryptoStream GetDecryptorStream(ISymmetricTransformCrypt transformCrypt, Stream outputStream, byte[] key, byte[] iv) {
            return transformCrypt.GetDecryptorStream(outputStream, new CryptAlgorithmParameters(key, iv));
        }

        private static int GetCryptInitializationVectorSizeInBytes(ISymmetricTransformCrypt transformCrypt) {
            return transformCrypt.InitializationVectorSizeInBytes;
        }
 
        internal CryptoStream GetAES256EncryptorStream(Stream outputStream, byte[] key, byte[] iv) {
            return GetEncryptorStream(aes256, outputStream, key, iv);
        }

        internal CryptoStream GetAES256DecryptorStream(Stream outputStream, byte[] key, byte[] iv) {
            return GetDecryptorStream(aes256, outputStream, key, iv);
        }

        internal int AES256InitializationVectorSizeInBytes { get { return GetCryptInitializationVectorSizeInBytes(aes256); } }

        internal CryptoStream GetAES128EncryptorStream(Stream outputStream, byte[] key, byte[] iv) {
            return GetEncryptorStream(aes128, outputStream, key, iv);
        }

        internal CryptoStream GetAES128DecryptorStream(Stream outputStream, byte[] key, byte[] iv) {
            return GetDecryptorStream(aes128, outputStream, key, iv);
        }

        internal int AES128InitializationVectorSizeInBytes { get { return GetCryptInitializationVectorSizeInBytes(aes128); } } 

        #endregion

        #region AsymmetricCrypth

        internal string AsymmEncrypt(string plainText, string key) {
            return EncodeBase64(_asymmetricCryptGenerator.Encrypt(Encode(plainText), Encode(key)));
        }

        internal string AsymmEncrypt(string plainText) {
            return EncodeBase64(_asymmetricCryptGenerator.Encrypt(Encode(plainText), null));
        }

        internal string AsymmDecrypt(string plainText, string key) {
            return Encode(_asymmetricCryptGenerator.Decrypt(DecodeBase64ToBytes(plainText), Encode(key)));
        }

        #endregion

        #region NOT FIPS compliant section...

        [Obsolete("NOT FIPS compliant")]
        internal class InsecureManager {
            private readonly CryptManager cryptManager;
            private readonly IHashGenerator md5HashGenerator;
            private readonly ISymmetricCrypt symmetricRC4CryptGenerator;

            public InsecureManager(CryptManager cryptManager) {
                this.cryptManager = cryptManager;
                md5HashGenerator = new Implementations.Hash.Insecure.MD5HashAdapter();                
                symmetricRC4CryptGenerator = new Implementations.Crypt.Insecure.RC4Adapter();
            }

            #region Guids

            internal Guid ToGuid(byte[] data) {
                return CryptManager.ToGuid(data, md5HashGenerator);
            }

            internal Guid ToGuid(string data) {
                return cryptManager.ToGuid(data, md5HashGenerator);
            }

            internal string ToGuidToBase64(string data) {
                return cryptManager.ToGuidToBase64(data, md5HashGenerator);
            }

            internal Guid ToGuidUsingDefaultEncoding(string text) {
                return CryptManager.ToGuidUsingDefaultEncoding(text, md5HashGenerator);
            }

            internal Guid ToGuidWithSaltAndUTF16(string data, string salt) {
                return CryptManager.ToGuidWithSaltAndUTF16(data, salt, md5HashGenerator);
            }
        
            internal string GenerateToBase64UsingDefaultEncoding(string text) {
                return CryptManager.GenerateToBase64UsingDefaultEncoding(text, md5HashGenerator);
            }

            #endregion

            #region Password

            internal string HexDeriveUsingUTF16(string plainText, string salt) {
                return CryptManager.HexDeriveUsingUTF16(plainText, salt, md5HashGenerator);
            }

            #endregion

            #region Hash

            internal byte[] HashToBytes(byte[] bytes) {
                return CryptManager.HashToBytes(bytes, md5HashGenerator);
            }

            internal string Hash(byte[] bytes) {
                return CryptManager.Hash(bytes, md5HashGenerator);
            }

            internal string Hash(string plain) {
                return cryptManager.Hash(plain, md5HashGenerator);
            }
        
            internal string HashUsingDefaultEncoding(string plain) {
                return CryptManager.HashUsingDefaultEncoding(plain, md5HashGenerator);
            }

            internal string HashUsingUTF16(string bytes) {
                return CryptManager.HashUsingUTF16(bytes, md5HashGenerator);
            }

            #endregion

            #region SymmetricRC4Crypth

            internal string SymmetricRC4Encrypt(string plainText, string key) {
                return EncodeBase64(symmetricRC4CryptGenerator.Encrypt(cryptManager.Encode(plainText), cryptManager.Encode(key)));
            }

            internal byte[] SymmetricRC4EncryptToBytes(string plainText, string key) {
                return symmetricRC4CryptGenerator.Encrypt(cryptManager.Encode(plainText), cryptManager.Encode(key));
            }

            internal string SymmetricRC4Decrypt(string plainText, string key) {
                return cryptManager.Encode(symmetricRC4CryptGenerator.Decrypt(DecodeBase64ToBytes(plainText), cryptManager.Encode(key)));
            }

            internal string SymmetricRC4Decrypt(byte[] bytes, string key) {
                return cryptManager.Encode(symmetricRC4CryptGenerator.Decrypt(bytes, cryptManager.Encode(key)));
            }

            #endregion SymmetricRC4Crypth
        }

        [Obsolete("NOT FIPS compliant")]
        private object insecureInstance;

        [Obsolete("NOT FIPS compliant")]
        internal InsecureManager Insecure {
            get {
                if (insecureInstance == null) {
                    insecureInstance = new InsecureManager(this);
                }

                return (InsecureManager) insecureInstance;
            }
        }

        #endregion NOT FIPS compliant section...
    }
}
