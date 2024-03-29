/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using OutSystems.ObjectKeys;

namespace OutSystems.RuntimeCommon {

    public static class Constants {

        public static readonly ObjectKey EnterpriseManagerESpaceKey = ObjectKey.Parse("3136AC21-3073-405E-85DC-8FBC1E819BD9");
        public static readonly ObjectKey EPATaskboxESpaceKey = ObjectKey.Parse("460089c7-af3d-437a-ab33-a93fa9d39bab");

        public static readonly ObjectKey AdminEmailSitePropertyKey = ObjectKey.Parse("f0B30515-DB99-34C5-0738-23B6598E51CB");

        // ISA-215: entry point used by the Integrated Debugger
        public static readonly ObjectKey IntegratedDebuggerWebServiceKey = ObjectKey.Parse("jw2rr7qkdNY7Mjp72gDcKw");
        public static readonly ObjectKey CheckPermissionWebServiceMethodKey = ObjectKey.Parse("4i5DIENZxR7To2ESVzOpfQ");

        public static readonly GlobalObjectKey EpaTaskboxSeenActivityKey = new GlobalObjectKey(EPATaskboxESpaceKey,
            ObjectKey.Parse("d67cdd4a-cbc6-4acd-a1c5-42032c1d57ac"));

        public static readonly DateTime DefaultDateTime = new DateTime(1900, 1, 1, 0, 0, 0);
        public const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        public static readonly IFormatProvider DateTimeFormatProvider = CultureInfo.InvariantCulture;
        public static readonly IFormatProvider IntegerFormatProvider = CultureInfo.InvariantCulture;
        public static readonly IFormatProvider DoubleFormatProvider = CultureInfo.InvariantCulture;
        public static readonly IFormatProvider DecimalFormatProvider = CultureInfo.InvariantCulture;

        public const string ServiceCenterName = "ServiceCenter";
        public const string ECTProviderName = "ECT_Provider";
        public const string LifeTimeCloudConnectName = "LifeTimeCloudConnect";
        public const string NativeAppBuilderName = "NativeAppBuilder";
        public const string UsersName = "Users";

        public const string NativePluginAPIName = "NativePluginAPI";

        public const string MainDatabaseLogicalName = "(Main)";

        [Obsolete("Use MainDatabaseLogicalName instead.")]
        public const string SystemDatabaseLogicalName = MainDatabaseLogicalName;

        public const string ApplicationsLibDirectory = "bin";
        public const string ApplicationsLateLoadLibDirectory = "bin2";

        public const string UserEntityName = "User";
        public const string TenantEntityName = "Tenant";
        public const string RoleEntityName = "Role";
        public const string SentEmailEntityName = "Sent_Email";

        public const string TimerScheduleWhenPublished = "WhenPublished";

        public const int MinimumExtendedGuidLength = 32;
        public const int LargeTextSize = 5000; // Used to improve ActiPro performance on large strings.

        public const string NewLineCharacter = "\n";

        // DECIMAL(37, 8) explanation:
        // At the time of this coding, we only use the .net decimal for non-int types
        // The .net decimal allows a total number of 29 significant digits. This includes the
        // integer part and the decimal part. 
        // The database has a fixed part for integer and another for decimal.
        // So, we define an integer part of 29 (and a fixed of 8) => (29+8, 8)
        public const int DecimalTotalPrecision = 37; // length property
        public const int DecimalDecimals = 8;

        public const string EnableHSTSParameterName = "EnableHSTS";

        // Personal area name which can be used by any user
        public const string COMMON_PERSONAL_AREA_NAME = "_common";
        public const int COMMON_PERSONAL_AREA_USER_ID = 0;

        public const string ComboBoxSpecialListIdPrefix = "__ossli_";

        public const int DEBUGGER_MAX_STRING_LENGTH = 75;
        public const int DEBUGGER_MAX_ROW_COUNT = 150;
        public const string TrimmedAttribute = "debug.trimmed";

        public const string CssExtension = ".css";
        public const string JavaScriptExtension = ".js";
        public const string SourceMapExtension = ".map";
        public const string NonMinifiedExtension = ".non-min";
        public const string ImageFolderName = "img";
        public const string CustomHandlersFolderName = "CustomHandlers";

        public const string PrecacheManifestFileName = "precache.manifest";
        public const string ProducerValidationFileSuffix = "referencesHealth";
        public const string PrebundleApplicationInfoFileName = "manifest.json";
        public const string EntityModulesManifestFileName = "entityModules.manifest";
        public const string ModuleDefinitionFileName = "moduleDefinitions.json";
        public const string RabbitMQInstallScriptFilename = "RabbitMQ_Installation.ps1";
        public static string RabbitMQInstallScriptPath = AppDomain.CurrentDomain.BaseDirectory + "\\scripts\\RabbitMQ\\";
        
        public static readonly Encoding DefaultEncoding = new UTF8Encoding(true);

        // The size to be used by Buffered Streams (Systems.IO.BufferedStream)
        public const int MaxStreamBufferSize = 32768;

        public static class EnterPriseManager {
            public static readonly GlobalObjectKey ACTIVITY_EXTENSION = new GlobalObjectKey(EnterpriseManagerESpaceKey,
                ObjectKey.Parse("265e2259-1adb-4cde-a235-3a77d99ce335"));

            public static readonly GlobalObjectKey GROUP = new GlobalObjectKey(EnterpriseManagerESpaceKey,
                ObjectKey.Parse("4effce71-0443-c5bc-df17-3f68afb0f338"));

            public static readonly GlobalObjectKey USER_MASTER_ROLE = new GlobalObjectKey(EnterpriseManagerESpaceKey,
                ObjectKey.Parse("8b8315d7-00f0-8bae-c12b-74900be1c016"));

            public static readonly GlobalObjectKey ROLE_PERMISSION = new GlobalObjectKey(EnterpriseManagerESpaceKey,
                ObjectKey.Parse("28a1ca7e-7b0a-3434-39c3-a5cdaaabbb6e"));

            public static readonly GlobalObjectKey PERMISSION_AREA_EXTENSION = new GlobalObjectKey(EnterpriseManagerESpaceKey,
                ObjectKey.Parse("63ab6220-8276-4bf3-a034-24c3b5ad318f"));

            public static readonly GlobalObjectKey USER_EXTENSION = new GlobalObjectKey(EnterpriseManagerESpaceKey,
                ObjectKey.Parse("fe1ac284-9017-4149-b911-afd06bed4851"));
        }

        public static class EntityDataKind {
            public const string StaticEntity = "staticEntity";
            public const string ClientEntity = "clientEntity";
            public const string Entity = "entity";
        }

        public static class PlatformLogs {
            public const string XifName = "PlatformLogs.xif";
            public const string LogicalDatabaseName = "LogDatabase";
            public const string ReservedDbConnectionName = "$OS_LOG_DB_7e3e8ce0"; // Added a guid-like identifier to minimize the possibility of a clash
        }

        public static class AppOfflineCustomHandler {
            public const string FileName = "app_offline.aspx";
            public const string ErrorCodeKey = "AppOffline_ErrorCode";
            public const string ErrorDetailKey = "AppOffline_ErrorDetail";
            public const string ContactKey = "AppOffline_Contact";
        }
    }
}