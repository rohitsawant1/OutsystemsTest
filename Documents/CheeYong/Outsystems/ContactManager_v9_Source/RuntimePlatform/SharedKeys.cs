using System.Runtime.CompilerServices;
namespace OutSystems.HubEdition.RuntimePlatform {
    internal sealed class SharedKeys {

        public static string SettingsWeakSymmetricKey() {
            return "toChange";
        }

        public static string ConfidentialInformationSymmetricKey() {
            return "toChange";
        }

        public static string PrivateSalt() {
            return "cdjnes3h4w";
        }
        
    }
}