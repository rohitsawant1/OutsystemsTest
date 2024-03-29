/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;

namespace OutSystems.PluginAPI.PluginConfiguration {
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class HelpLinkForPluginEnumConfigurationAttribute: Attribute, IHelpLinkForPluginEnumConfiguration {
        /// <summary>
        /// Defines the string value the help information relates to.
        /// </summary>
        ///
        /// <value>The string value the help information relates to.</value>
        public string EnumValue { get; set; }

        /// <summary>
        /// Defines the text of the link that is placed next to the enum parameter in the user interface.
        /// </summary>
        ///
        /// <value>The link text that will represent the parameter.</value>
        public string Text { get; set; }

        /// <summary>
        /// Defines the URL where the help link will point to.
        /// </summary>
        /// <value>The URL the help link will point to</value>
        public string Url { get; set; }
    }
}
