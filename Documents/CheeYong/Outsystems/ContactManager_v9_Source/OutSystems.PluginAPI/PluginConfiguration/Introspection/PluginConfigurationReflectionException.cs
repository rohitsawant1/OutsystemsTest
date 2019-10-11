/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;

namespace OutSystems.PluginAPI.PluginConfiguration.Introspection {
    /// <summary>
    /// Exception for signaling configuration reflection errors.
    /// </summary>
    public class PluginConfigurationReflectionException: Exception {
        public PluginConfigurationReflectionException(Exception e) : base(e.Message, e) { }
    }
}
