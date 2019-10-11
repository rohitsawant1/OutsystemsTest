/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.IO;
using System.Text;
using OutSystems.HubEdition.Extensibility.Data.ConfigurationService;
using OutSystems.HubEdition.Extensibility.Data.TransactionService;
using OutSystems.RuntimeCommon;
using System.Reflection;

namespace OutSystems.HubEdition.Extensibility.Data.Platform.Configuration {
    public abstract class BaseConfigurationManager {

        public static string Script_Path = Path.Combine(CurrentInstallationDir, "db");

        private static string CurrentInstallationDir {
            get {
                return Path.GetFullPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + FileSystemUtils.PathSeparator);
            }
        }

        public abstract string StatementSeparator {
            get;
        }

        public bool TestConnection(IRuntimeDatabaseConfiguration runtimeConfiguration, out string friendlyMessage) {
            ITransactionService transactionService = runtimeConfiguration.DatabaseProvider.GetIntegrationDatabaseServices(runtimeConfiguration).TransactionService;
            if (transactionService.TestConnection(out friendlyMessage)) {
                friendlyMessage = "Test completed successfully.";
                return true;
            }
            return false;
        }

        protected string ReadScriptFile(FileStream stream) {
            using (var fsSource = stream) {
                using (var reader = new StreamReader(fsSource, Encoding.UTF8)) {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
