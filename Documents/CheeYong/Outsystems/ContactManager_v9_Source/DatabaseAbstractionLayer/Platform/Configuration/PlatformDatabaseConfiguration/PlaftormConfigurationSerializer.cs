/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using OutSystems.HubEdition.Extensibility.Data.ConfigurationService;
using OutSystems.HubEdition.Extensibility.Data.ConfigurationService.MetaConfiguration;
using OutSystems.PluginAPI.PluginConfiguration.Introspection;

namespace OutSystems.HubEdition.Extensibility.Data.Platform.Configuration {

    public static class Serializers {
    
        public static Serializer<IPlatformDatabaseConfiguration> ForPlatform {
            get {
                Func<IPlatformDatabaseConfiguration, IEnumerable<IPluginParameter>> e =
                    c =>  {
                        var m = new MetaDatabaseConfiguration(c);
                        var ps = m.Parameters.Where(p => p.Persist);
                        if (c.AuthenticationMode == AuthenticationType.Windows_Authentication) {
                            return ps.Where(p =>
                                !(p is IUserDefinedPluginParameter) ||
                                !((IUserDefinedPluginParameter)p).IsPassword);
                        } else {
                            return ps;
                        }
                    };

                return new Serializer<IPlatformDatabaseConfiguration>("PlatformDatabaseConfiguration", e);
            }
        }

        public static Serializer<ISettableTwoUserDatabaseConfiguration> ForLogging {
            get {
                Func<ISettableTwoUserDatabaseConfiguration, IEnumerable<IPluginParameter>> e =
                    c => {
                        var m = new MetaDatabaseConfiguration(c);
                        var ps = m.Parameters.Where(p => p.Persist);
                        if (c.AuthenticationMode == AuthenticationType.Windows_Authentication)
                        {
                            return ps.Where(p =>
                                !(p is IUserDefinedPluginParameter) ||
                                !((IUserDefinedPluginParameter)p).IsPassword);
                        }
                        else
                        {
                            return ps;
                        }
                    };

                return new Serializer<ISettableTwoUserDatabaseConfiguration>("LoggingDatabaseConfiguration", e);
            }
        }

        public static Serializer<ISettableTwoUserDatabaseConfiguration> ForRuntime {
            get {
                Func<ISettableTwoUserDatabaseConfiguration, IEnumerable<IPluginParameter>> e =
                    c => {
                        var m = new MetaDatabaseConfiguration(c);
                        var ps = m.Parameters.Where(p => p.Persist);
                        if (c.AuthenticationMode == AuthenticationType.Windows_Authentication) {
                            return ps.Where(p =>
                                !(p is IUserDefinedPluginParameter) ||
                                !((IUserDefinedPluginParameter)p).IsPassword);
                        } else {
                            return ps;
                        }
                    };

                return new Serializer<ISettableTwoUserDatabaseConfiguration>("ApplicationDatabaseConfiguration", e);
            }
        }


        public static Serializer<ISessionDatabaseConfiguration> ForSession {
            get {
                Func<ISessionDatabaseConfiguration, IEnumerable<IPluginParameter>> e =
                    c => {
                        var m = new MetaDatabaseConfiguration(c);
                        var ps = m.Parameters.Where(p => p.Persist);
                        if (c.AuthenticationMode == AuthenticationType.Windows_Authentication) {
                            return ps.Where(p =>
                                !(p is IUserDefinedPluginParameter) ||
                                !((IUserDefinedPluginParameter)p).IsPassword);
                        } else {
                            return ps;
                        }
                    };

                return new Serializer<ISessionDatabaseConfiguration>("SessionDatabaseConfiguration", e);
            }
        }
    }

    public static class Deserializers {

        public static Deserializer<IPlatformDatabaseConfiguration> ForPlatform {
            get {
                return new Deserializer<IPlatformDatabaseConfiguration>("PlatformDatabaseConfiguration");
            }
        }
        public static Deserializer<ISettableTwoUserDatabaseConfiguration> ForLogging {
            get {
                return new Deserializer<ISettableTwoUserDatabaseConfiguration>("LoggingDatabaseConfiguration");
            }
        }

        public static Deserializer<ISettableTwoUserDatabaseConfiguration> ForRuntime {
            get {
                return new Deserializer<ISettableTwoUserDatabaseConfiguration>("ApplicationDatabaseConfiguration");
            }
        }

        public static Deserializer<ISessionDatabaseConfiguration> ForSession {
            get {
                return new Deserializer<ISessionDatabaseConfiguration>("SessionDatabaseConfiguration");
            }
        }

    }

}
