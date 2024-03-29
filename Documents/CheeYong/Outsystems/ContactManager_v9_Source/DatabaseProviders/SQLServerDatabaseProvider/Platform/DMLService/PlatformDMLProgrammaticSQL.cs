/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using OutSystems.HubEdition.Extensibility.Data.Platform.DMLService;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.DatabaseProvider.SqlServer.Platform.DMLService {
    internal class PlatformDMLProgrammaticSQL: BasePlatformDMLProgrammaticSQL {
        public PlatformDMLProgrammaticSQL(IPlatformDMLService dmlService) : base(dmlService) {}

        public override string IfElseStatement(string condition, string ifBody, string elseBody) {
            if (elseBody.IsNullOrEmpty()) {
                return string.Format("IF {0} {1}", condition, ifBody);
            }
            return string.Format("IF {0} {1} ELSE {2}", condition, ifBody, elseBody);
        }

        public override string GetVariableValue(string name) {
            return "@" + name;
        }

        public override string SetVariable(string varName, string value) {
            return string.Format("SET @{0} = {1};", varName, value);
        }

        public override IDictionary<QueryPlaceholder, string> SetVariableFromQuery(string varName) {
            IDictionary<QueryPlaceholder, string> placeholders = new Dictionary<QueryPlaceholder, string>();
            placeholders.Add(QueryPlaceholder.BeforeStatement, String.Format("SET @{0} = (", varName));
            placeholders.Add(QueryPlaceholder.AfterStatement, ");");
            return placeholders;
        }

        public override string SetVariableFromLastInsertedId(string varName) {
            return string.Format("SET @{0} = (SELECT SCOPE_IDENTITY());", varName);
        }

        public override string BeginProgrammaticSQLBlock(params VariableDetails[] variables) {
            string variablesSQL = variables.IsEmpty() ? "" : string.Format("DECLARE {0};{1}", 
                variables.Select(var => String.Format("@{0} {1}", var.Name, var.Type.SqlDataType)).StrCat(", "), Environment.NewLine);
            return variablesSQL + "BEGIN";
        }
    }
}
