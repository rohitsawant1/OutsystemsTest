/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using OutSystems.HubEdition.DatabaseProvider.Oracle.ConfigurationService;
using OutSystems.HubEdition.DatabaseProvider.Oracle.Platform.DatabaseObjects;
using OutSystems.HubEdition.Extensibility.Data.ConfigurationService;
using OutSystems.HubEdition.Extensibility.Data.DatabaseObjects;
using OutSystems.HubEdition.Extensibility.Data.DMLService;
using OutSystems.HubEdition.Extensibility.Data.ExecutionService;
using OutSystems.HubEdition.Extensibility.Data.IntrospectionService;
using OutSystems.HubEdition.Extensibility.Data.Platform;
using OutSystems.HubEdition.Extensibility.Data.Platform.DatabaseObjects;
using OutSystems.HubEdition.Extensibility.Data.Platform.DDLService;
using OutSystems.HubEdition.Extensibility.Data.Platform.DMLService;
using OutSystems.HubEdition.Extensibility.Data.Platform.ExecutionService;
using OutSystems.HubEdition.Extensibility.Data.Platform.IntrospectionService;
using OutSystems.HubEdition.Extensibility.Data.Platform.Session;

namespace OutSystems.HubEdition.DatabaseProvider.Oracle.Platform {
    internal class PlatformDatabaseServices: DatabaseServices, IPlatformDatabaseServices {

        private readonly IPlatformDatabaseObjectFactory objectFactory;
        private readonly IPlatformIntrospectionService introspectionService;
        private readonly IPlatformExecutionService executionService;
        private readonly IPlatformDMLService dmlService;
        private readonly IDDLService ddlService;
        private readonly IPlatformSessionService sessionService;

        IPlatformDatabaseObjectFactory IPlatformDatabaseServices.ObjectFactory { get { return objectFactory; } }
        IPlatformIntrospectionService IPlatformDatabaseServices.IntrospectionService { get { return introspectionService; } }
        IPlatformExecutionService IPlatformDatabaseServices.ExecutionService { get { return executionService; } }
        IPlatformDMLService IPlatformDatabaseServices.DMLService { get { return dmlService; } }

        public IDDLService DDLService { get { return ddlService;  } }
        public IPlatformSessionService SessionService { get { return sessionService; } }


        public PlatformDatabaseServices(IRuntimeDatabaseConfiguration databaseConfiguration): base(databaseConfiguration) {
            objectFactory = new PlatformDatabaseObjectFactory(this);
            executionService = new ExecutionService.PlatformExecutionService(this);
            dmlService = new DMLService.PlatformDMLService(this);
            introspectionService = new IntrospectionService.PlatformIntrospectionService(this);
            ddlService = new DDLService.DDLService(this);
            sessionService = new Session.PlatformSessionService(this);
        }
        
        public override IDatabaseObjectFactory ObjectFactory { get { return objectFactory; } }
        public override IIntrospectionService IntrospectionService { get { return introspectionService; } }
        public override IExecutionService ExecutionService { get { return executionService; } }
        public override IDMLService DMLService { get { return dmlService; } }

        public IIntegrationDatabaseConfiguration IntegrationDatabaseConfiguration {
            get {
                var dbConfig = DatabaseConfiguration as RuntimeDatabaseConfiguration;

                if (dbConfig == null) {
                    throw new Exception("Could not cast the DatabaseConfiguration property as a Oracle's RuntimeDatabaseConfiguration.");
                }

                return new DatabaseConfiguration() {
                    ConnectionStringOverride = DatabaseConfiguration.ConnectionString,
                    Schema = DatabaseConfiguration.DatabaseIdentifier,
                    NLSLanguage = dbConfig?.NLS_Language,
                };
            }
        }
    }
}
