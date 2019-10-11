/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using OutSystems.HubEdition.DatabaseProvider.MySQL.ConfigurationService;
using OutSystems.HubEdition.Extensibility.Data.ConfigurationService;
using OutSystems.HubEdition.Extensibility.Data.Platform.Configuration;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.DatabaseProvider.MySQL.Platform.Configuration {
    public class MySQLPlatformConfigurationManager : BasePlatformConfigurationManager {
        public MySQLPlatformConfigurationManager(IPlatformDatabaseConfiguration uiConfiguration)
            : base(uiConfiguration) {
        }

        public override bool RecommendDatabaseBackup {
            get { return true; }
        }

        public override FileStream StreamForScriptFile {
            get {
                string path = Path.Combine(Script_Path, "platform_model_mysql.sql");
                return new FileStream(path, FileMode.Open, FileAccess.Read);
            }
        }

        public override string ProcessStatement(string statement) {
            MySQLPlatformDatabaseConfiguration config = (MySQLPlatformDatabaseConfiguration)uiConfiguration;
            statement = statement.Trim();
            return statement;
        }


        public override string StatementSeparator {
            get {
                return "GO";
            }
        }

        public override void Pre_CreateOrUpgradePlatform() {
            //this is implemented, MySQL does not have any behavior
        }

    }
}
