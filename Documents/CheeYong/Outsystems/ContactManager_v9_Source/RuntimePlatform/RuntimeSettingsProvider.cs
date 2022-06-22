/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using OutSystems.RuntimeCommon.Settings;

namespace OutSystems.HubEdition.RuntimePlatform {
    public class RuntimeSettingsProvider : ISettingsProvider {
        private static RuntimeSettingsProvider settingsProvider = new RuntimeSettingsProvider();
        public static RuntimeSettingsProvider Instance {
            get { return settingsProvider; }
        }

        [ThreadStatic]
        private static Stack<Dictionary<string, object>> overridenSettings;
        private static Stack<Dictionary<string, object>> OverridenSettings {
            get {
                if (overridenSettings == null) {
                    overridenSettings = new Stack<Dictionary<string, object>>();
                }

                return overridenSettings;
            }
        }
        
        public T Get<T>(ISetting<T> setting) {
            if (overridenSettings != null) {
                foreach (var settingsDictionary in overridenSettings) {
                    if (settingsDictionary.ContainsKey(setting.Key)) {
                        return (T)settingsDictionary[setting.Key];
                    }
                }
            }

            // TODO RRTC this probably needs a cache here.
            // Accessing ConfigurationManager is fast, but decrypting and converting may still have some performance impact.
            // Still needs impact analysis
            var settingValue = ConfigurationManager.AppSettings[setting.Key];
            if (settingValue == null) { // TODO RRTC Remove when no services use the DatabaseAccess from RuntimePlatform
#pragma warning disable 618
                var fullKeyName = Settings.GetFullSettingName(setting.Key);
#pragma warning restore 618
                if (setting.Key != fullKeyName) {
                    settingValue = ConfigurationManager.AppSettings[fullKeyName];
                }
            }

            return LoadFromString(setting, settingValue);
        }

        internal T LoadFromString<T>(ISetting<T> setting, string settingValue) {
            if (setting.IsEncrypted) {
                settingValue = SecureConfidentialInformationEncryption.TryDecryptString(settingValue);
            }
            if (settingValue == null) {
                return setting.DefaultValue;
            } else {
                settingValue = settingValue.Trim(); // Keeping compatibility with the old Settings behavior
                try {
                    Type t = typeof(T);
                    t = Nullable.GetUnderlyingType(t) ?? t;

                    return settingValue == null ? setting.DefaultValue : (T)Convert.ChangeType(settingValue, t, CultureInfo.InvariantCulture);
                } catch (FormatException) {
                    // Keeping compatibility with the old Settings behavior
                    return setting.DefaultValue;
                }
            }
        }

        public static void WithSettingsOverride(Dictionary<string, object> settings, Action action) {
            OverridenSettings.Push(settings);

            try {
                action();
            } finally {
                OverridenSettings.Pop();
            }
        }
    }
}