/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;

namespace OutSystems.Extensibility {
    public class ConfigurationParameter {

        private const String SEPARATOR = ".";

        // Mandatory attributes
        protected String OwnerIdentifier;
        protected String Name;

        // Additional attributes that hold meta-information about the ConfigurationParameter
        protected bool NodeConfiguration = true;
        protected bool EncryptedConfiguration = false;

        /**
         * The default value that should be returned if the ConfigurationParameter is not defined
         */
        public String DefaultValue {
            get;
            protected set;
        }

        private ConfigurationParameter(String ownerIdentifier, String name) {
            this.OwnerIdentifier = ownerIdentifier;
            this.Name = name;
        }

        // Make sure to override GetUniqueName() method
        protected ConfigurationParameter() : this(null, null) {
        }

        public static ConfigurationParameter Create(String ownerIdentifier, String name) {
            if (string.IsNullOrEmpty(ownerIdentifier)) {
                throw new ArgumentException("OwnerIdentifier must not be empty.");
            }

            return new ConfigurationParameter(ownerIdentifier, name);
        }

        /**
         * If this parameter is not node-specific, then it is shared among all nodes
         */
        public ConfigurationParameter Shared() {
            this.NodeConfiguration = false;
            return this;
        }

        /**
         * If this parameter requires encryption when it is stored (eg. passwords)
         */ 
        public ConfigurationParameter Encrypted() {
            this.EncryptedConfiguration = true;
            return this;
        }

        /**
         * Default value that will be returned when somebody asks for the parameter and it is not defined
         */
        public ConfigurationParameter WithDefaultValue(String defaultValue) {
            this.DefaultValue = defaultValue;
            return this;
        }

        /**
         * Default value that will be returned when somebody asks for the parameter and it is not defined
         */
        public ConfigurationParameter WithDefaultValue(int defaultValue) {
            this.DefaultValue = Convert.ToString(defaultValue);
            return this;
        }

        /**
         * Default value that will be returned when somebody asks for the parameter and it is not defined
         */
        public ConfigurationParameter WithDefaultValue(bool defaultValue) {
            this.DefaultValue = Convert.ToString(defaultValue);
            return this;
        }

        public virtual String GetUniqueName() {
            return this.OwnerIdentifier + SEPARATOR + this.Name;
        }

        public bool IsNodeConfiguration() {
            return this.NodeConfiguration;
        }

        public bool IsEncryptedConfiguration() {
            return this.EncryptedConfiguration;
        }

        public override bool Equals(object obj) {
            if (!(obj is ConfigurationParameter)) {
                return false;
            }
            return GetUniqueName() == ((ConfigurationParameter) obj).GetUniqueName();
        }

        public override int GetHashCode() {
            return GetUniqueName().GetHashCode();
        }
    }
}