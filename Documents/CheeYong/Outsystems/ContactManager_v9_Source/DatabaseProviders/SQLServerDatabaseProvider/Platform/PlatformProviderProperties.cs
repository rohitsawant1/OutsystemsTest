/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.Platform;

namespace OutSystems.HubEdition.DatabaseProvider.SqlServer.Platform {
    internal class PlatformProviderProperties : ProviderProperties, IPlatformProviderProperties {

        public PlatformProviderProperties(IDatabaseProvider provider) : base(provider) { }

        public bool SupportsMultipleDatabases {
            get { return true; }
        }

        public bool SupportsIntegratedAuthentication {
            get { return true; }
        }
    }
}
