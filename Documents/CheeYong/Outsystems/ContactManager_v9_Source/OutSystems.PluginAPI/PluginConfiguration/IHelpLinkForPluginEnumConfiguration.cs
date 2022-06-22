/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

namespace OutSystems.PluginAPI.PluginConfiguration {
    public interface IHelpLinkForPluginEnumConfiguration {
        /// <summary>
        /// Defines the string value the help information relates to.
        /// </summary>
        ///
        /// <value>The string value the help information relates to.</value>
        string EnumValue { get; }

        /// <summary>
        /// Defines the text of the link that is placed next to the enum parameter in the user interface.
        /// </summary>
        ///
        /// <value>The link text that will represent the parameter.</value>
        string Text { get; }

        /// <summary>
        /// Defines the URL where the help link will point to.
        /// </summary>
        /// <value>The URL the help link will point to</value>
        string Url { get; }
    }
}