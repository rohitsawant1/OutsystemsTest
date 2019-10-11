/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.DMLService;
using OutSystems.HubEdition.Extensibility.Data.Platform.DMLService;

namespace OutSystems.HubEdition.DatabaseProvider.SqlServer.Platform.DMLService {
    internal class PlatformDMLService : SqlServer.DMLService.DMLService, IPlatformDMLService {

        private readonly IPlatformDMLFunctions functions;
        private readonly IPlatformDMLIdentifiers identifiers;
        private readonly IPlatformDMLProgrammaticSQL programmaticSql;

        IPlatformDMLIdentifiers IPlatformDMLService.Identifiers { get { return identifiers; } }
        IPlatformDMLFunctions IPlatformDMLService.Functions { get { return functions; } }

        public IPlatformDMLProgrammaticSQL ProgrammaticSql { get { return programmaticSql; } }

        public PlatformDMLService(IDatabaseServices databaseServices): base(databaseServices) {
            functions = new PlatformDMLFunctions(this);
            identifiers = new PlatformDMLIdentifiers(this);
            programmaticSql = new PlatformDMLProgrammaticSQL(this);
        }

        public override IDMLIdentifiers Identifiers { get { return identifiers; } }
        public override IDMLFunctions Functions { get { return functions; } }
    }
}
