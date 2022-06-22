/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

namespace OutSystems.RuntimeCommon {

    public sealed class DatabaseProviderKey {
        public static readonly DatabaseProviderKey NONE = Deserialize("Invalid");

        private readonly string providerName;

        private DatabaseProviderKey(string providerName) {
            this.providerName = providerName;
        }

        public string Serialize() {
            return providerName;
        }

        public static DatabaseProviderKey Deserialize(string serialized) {
            return new DatabaseProviderKey(serialized);
        }

        public override bool Equals(object obj) {
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }

            return Equals(obj as DatabaseProviderKey);
        }

        public bool Equals(DatabaseProviderKey key) {
            if (key == null) {
                return false;
            }

            return providerName.Equals(key.providerName);
        }

        public override string ToString() {
            return providerName;
        }

        public override int GetHashCode() {
            return providerName.GetHashCode();
        }
    }
}