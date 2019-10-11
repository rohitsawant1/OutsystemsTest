/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SapNcoConnectionManager {
    public class ConnectionManager {

        internal static string GetRfcConfigParametersHashCode(RfcConfigParameters configParameters) {
            StringBuilder sb = new StringBuilder();
            foreach (var keyValue in configParameters) {
                sb.AppendLine(keyValue.Key);
                sb.AppendLine(keyValue.Value);
            }

            return sb.ToString().GetHashCode().ToString("X");
        }

        public class Destination {
            public string ServerKey { get; set; }
            public string Suffix { get; set; }
            public RfcDestination RfcDestination { get; set; }
            public bool InUse { get; set; }
            public DateTime InUseSince { get; set; }

            public string FullName {
                get {
                    return ServerKey + "_" + Suffix;
                }
            }
        }

        private class ServerConfiguration : IDestinationConfiguration {
            private static Dictionary<string, RfcConfigParameters> configuredServerDestinationsByKey = new Dictionary<string, RfcConfigParameters>();
            private static Dictionary<RfcConfigParameters, string> configuredServerDestinationsByConfig = new Dictionary<RfcConfigParameters, string>();
            
            public static string AddServerDestination(ServerDestinationProperties sdp) {
                lock (configuredServerDestinationsByKey) {
                    RfcConfigParameters configParameters = sdp.ToRfcConfigParameters();

                    string serverKey = ConnectionManager.GetRfcConfigParametersHashCode(configParameters);

                    if (configuredServerDestinationsByKey.ContainsKey(serverKey)) {
                        return serverKey;
                    }

                    configuredServerDestinationsByKey[serverKey] = configParameters;
                    configuredServerDestinationsByConfig[configParameters] = serverKey;

                    return serverKey;
                }
            }

            public static string AddServerDestination(RfcConfigParameters configParameters) {
                lock (configuredServerDestinationsByKey) {
                    string serverKey = ConnectionManager.GetRfcConfigParametersHashCode(configParameters);
                    if (configuredServerDestinationsByKey.ContainsKey(serverKey)) {
                        return serverKey;
                    }

                    configuredServerDestinationsByKey[serverKey] = configParameters;
                    configuredServerDestinationsByConfig[configParameters] = serverKey;

                    return serverKey;
                }
            }

            public static bool HasServerKey(string serverKey) {
                lock (configuredServerDestinationsByKey) {
                    return configuredServerDestinationsByKey.ContainsKey(serverKey);
                }
            }

            public ServerConfiguration() {
            }

            public bool ChangeEventsSupported() {
                return false;
            }

#pragma warning disable 67
            public event RfcDestinationManager.ConfigurationChangeHandler ConfigurationChanged;
#pragma warning restore 67

            public RfcConfigParameters GetParameters(string destinationName) {
                RfcConfigParameters rfcParams = null;

                string serverKey = destinationName.Split('_')[0];

                lock (configuredServerDestinationsByKey) {
                    if (configuredServerDestinationsByKey.ContainsKey(serverKey)) {
                        rfcParams = configuredServerDestinationsByKey[serverKey];
                    }
                }

                return rfcParams;
            }
        }

        private class ServerDestinationProperties {
            public string ServerID { get; set; }
            public string Client { get; set; }
            public string SystemNumber { get; set; }
            public string Server { get; set; }
            public string AliasUser { get; set; }
            public string User { get; set; }
            public string Password { get; set; }
            public string SapRouter { get; set; }
            public int PoolSize { get; set; }
            public int PeakLimit { get; set; }
            public int ExpirationTime { get; set; }
            public int ExpirationPeriod { get; set; }
            public int IdleCheckTime { get; set; }
            public string CodePage { get; set; }
            public string Language { get; set; }
            public string SsoTicket { get; set; }

            public override bool Equals(object obj) {
                ServerDestinationProperties sdp = (ServerDestinationProperties)obj;

                return
                    this.ServerID == sdp.ServerID &&
                    this.Client == sdp.Client &&
                    this.SystemNumber == sdp.SystemNumber &&
                    this.Server == sdp.Server &&
                    this.AliasUser == sdp.AliasUser &&
                    this.User == sdp.User &&
                    this.Password == sdp.Password &&
                    this.SapRouter == sdp.SapRouter &&
                    this.PoolSize == sdp.PoolSize &&
                    this.PeakLimit == sdp.PeakLimit &&
                    this.ExpirationTime == sdp.ExpirationTime &&
                    this.ExpirationPeriod == sdp.ExpirationPeriod &&
                    this.IdleCheckTime == sdp.IdleCheckTime &&
                    this.CodePage == sdp.CodePage &&
                    this.Language == sdp.Language &&
                    this.SsoTicket == sdp.SsoTicket;
            }

            public override int GetHashCode() {
                return
                    (this.ServerID ?? String.Empty).GetHashCode() ^
                    (this.Client ?? String.Empty).GetHashCode() ^
                    (this.SystemNumber ?? String.Empty).GetHashCode() ^
                    (this.Server ?? String.Empty).GetHashCode() ^
                    (this.AliasUser ?? String.Empty).GetHashCode() ^
                    (this.User ?? String.Empty).GetHashCode() ^
                    (this.Password ?? String.Empty).GetHashCode() ^
                    (this.SapRouter ?? String.Empty).GetHashCode() ^
                    this.PoolSize.GetHashCode() ^
                    this.PeakLimit.GetHashCode() ^
                    this.ExpirationTime.GetHashCode() ^
                    this.ExpirationPeriod.GetHashCode() ^
                    this.IdleCheckTime.GetHashCode() ^
                    (this.CodePage ?? String.Empty).GetHashCode() ^
                    (this.Language ?? String.Empty).GetHashCode() ^
                    (this.SsoTicket ?? String.Empty).GetHashCode();
            }

            public static bool operator ==(ServerDestinationProperties sdp1, ServerDestinationProperties sdp2) {
                return sdp1.Equals(sdp2);
            }

            public static bool operator !=(ServerDestinationProperties sdp1, ServerDestinationProperties sdp2) {
                return !(sdp1 == sdp2);
            }

            public RfcConfigParameters ToRfcConfigParameters() {
                RfcConfigParameters rfcParams = new RfcConfigParameters();
                rfcParams.Add(RfcConfigParameters.AppServerHost, this.Server);
                rfcParams.Add(RfcConfigParameters.SystemID, this.ServerID);
                rfcParams.Add(RfcConfigParameters.SystemNumber, this.SystemNumber);
                rfcParams.Add(RfcConfigParameters.SAPRouter, this.SapRouter);
                rfcParams.Add(RfcConfigParameters.Client, this.Client);
                rfcParams.Add(RfcConfigParameters.User, this.User);
                rfcParams.Add(RfcConfigParameters.Password, this.Password);
                if (!String.IsNullOrEmpty(this.AliasUser)) {
                    rfcParams.Add(RfcConfigParameters.AliasUser, this.AliasUser);
                }
                if (!String.IsNullOrEmpty(this.SsoTicket)) {
                    rfcParams.Add(RfcConfigParameters.SAPSSO2Ticket, this.SsoTicket);
                }
                if (!String.IsNullOrEmpty(this.CodePage)) {
                    rfcParams.Add(RfcConfigParameters.Codepage, this.CodePage);
                }
                if (!String.IsNullOrEmpty(this.Language)) {
                    rfcParams.Add(RfcConfigParameters.Language, this.Language);
                }
                rfcParams.Add(RfcConfigParameters.PoolSize, this.PoolSize.ToString());
                rfcParams.Add(RfcConfigParameters.PeakConnectionsLimit, this.PeakLimit.ToString());
                rfcParams.Add(RfcConfigParameters.IdleCheckTime, (this.IdleCheckTime / 1000).ToString());
                rfcParams.Add(RfcConfigParameters.PoolIdleTimeout, (this.ExpirationPeriod / 1000).ToString());
                rfcParams.Add(RfcConfigParameters.MaxPoolWaitTime, this.ExpirationTime.ToString());

                return rfcParams;
            }
        }

        private static bool serverConfigurationRegistered = false;
        private static object serverConfigurationRegistrationLock = new object();

        public static RfcConfigParameters GetRfcConfigParameters(string serverID,
                                 string client,
                                 string systemNumber,
                                 string server,
                                 string aliasUser,
                                 string user,
                                 string password,
                                 string sapRouter,
                                 int poolSize,
                                 int peakLimit,
                                 int expirationTime,
                                 int expirationPeriod,
                                 int idleCheckTime,
                                 string codePage,
                                 string language,
                                 bool getSSoTicket,
                                 string ssoTicket) {
            return new ServerDestinationProperties() {
                ServerID = serverID,
                Client = client,
                SystemNumber = systemNumber,
                Server = server,
                AliasUser = aliasUser,
                User = user,
                Password = password,
                SapRouter = sapRouter,
                PoolSize = poolSize,
                PeakLimit = peakLimit,
                ExpirationTime = expirationTime,
                ExpirationPeriod = expirationPeriod,
                IdleCheckTime = idleCheckTime,
                CodePage = codePage,
                Language = language,
                SsoTicket = ssoTicket
            }.ToRfcConfigParameters();
        }

        public static Destination GetDestination(RfcConfigParameters configParameters) {
            string serverKey = ServerConfiguration.AddServerDestination(configParameters);

            lock (serverConfigurationRegistrationLock) {
                if (!serverConfigurationRegistered) {
                    RfcDestinationManager.RegisterDestinationConfiguration(new ServerConfiguration());
                    serverConfigurationRegistered = true;
                }
            }

            if (ServerConfiguration.HasServerKey(serverKey)) {
                Destination destination = new Destination() {
                    InUse = true,
                    InUseSince = DateTime.Now,
                    ServerKey = serverKey,
                    Suffix = String.Empty,
                    RfcDestination = RfcDestinationManager.GetDestination(serverKey)
                };

                return destination;
            }

            return null;
        }

        public static Destination GetDestination(string serverKey) {
            if (ServerConfiguration.HasServerKey(serverKey)) {
                Destination destination = new Destination() {
                    InUse = true,
                    InUseSince = DateTime.Now,
                    ServerKey = serverKey,
                    Suffix = String.Empty,
                    RfcDestination = RfcDestinationManager.GetDestination(serverKey)
                };
                return destination;
            }

            return null;
        }

        public static void ReleaseDestination(Destination destination) {
        }
    }
}
