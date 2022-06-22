/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using OutSystems.RuntimeCommon.Settings;

namespace OutSystems.Logging {

    public enum PluginPriority {
        Low = 0,
        Medium = 1,
        High = 2
    };

    public interface ILoggingPlugin {

        string Name { get; }
        string Key { get; }
        PluginPriority Priority { get; }

        bool AppliesTo(ISettingsProvider settingsProvider);

        ILoggingTargetFactory GetLoggingTargetFactory(IServiceProvider serviceProvider);
    }

}