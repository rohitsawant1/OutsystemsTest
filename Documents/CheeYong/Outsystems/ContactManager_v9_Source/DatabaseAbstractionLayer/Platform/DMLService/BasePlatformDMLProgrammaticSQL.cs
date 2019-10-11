/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.Collections.Generic;
using OutSystems.HubEdition.Extensibility.Data.DMLService;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.Extensibility.Data.Platform.DMLService {
    public abstract class BasePlatformDMLProgrammaticSQL: IPlatformDMLProgrammaticSQL {

        protected BasePlatformDMLProgrammaticSQL(IPlatformDMLService dmlService) {
            DMLService = dmlService;
        }

        /// <summary>
        /// This property represents the associated <see cref="IDMLService"/>.
        /// </summary>
        public IPlatformDMLService DMLService { get; private set; }

        public abstract string IfElseStatement(string condition, string ifBody, string elseBody);
        public abstract string GetVariableValue(string name);
        public abstract string SetVariable(string varName, string value);
        public abstract IDictionary<QueryPlaceholder, string> SetVariableFromQuery(string varName);
        public abstract string SetVariableFromLastInsertedId(string varName);

        /// <summary>
        /// This method generates SQL that starts a programmatic SQL Block.
        /// </summary>
        /// <returns>SQL that starts a programmatic SQL Block.</returns>
        public abstract string BeginProgrammaticSQLBlock(params VariableDetails[] variables);

        /// <summary>
        /// This method generates SQL that ends a programmatic SQL Block.
        /// This implementation returns "END;".
        /// </summary>
        /// <returns>SQL that ends a programmatic SQL Block.</returns>
        public virtual string EndProgrammaticSQLBlock() {
            return "END";
        }

        /// <summary>
        /// This method generates the SQL to execute a DDL statement inside a block.
        /// This implementation simply returns the DDL statement terminated with ";".
        /// </summary>
        /// <param name="statement">The DDL statement to execute.</param>
        /// <returns>SQL statement to execute the given DDL statement.</returns>
        public virtual string ExecuteDDLInsideBlock(string statement) {
            if (statement.EndsWith(";")) {
                return statement;
            }
            return statement + ";";
        }
    }
}
