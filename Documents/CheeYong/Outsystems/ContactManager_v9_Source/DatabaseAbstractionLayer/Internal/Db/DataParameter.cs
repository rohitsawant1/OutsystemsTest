/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Data;
using OutSystems.HubEdition.Extensibility.Data.ExecutionService;

namespace OutSystems.Internal.Db {

    // TODO JMR REFACTOR: To be moved to another project
    public class DataParameter {

        public IDbDataParameter DriverParameter { get; private set; }

        private IExecutionService executionService;

        internal DataParameter(IExecutionService executionService, IDbDataParameter parameter) {
            if (executionService == null || parameter == null) {
                throw new ArgumentNullException();
            }
            this.executionService = executionService;
            this.DriverParameter = parameter;
        }

        public object Value {
            get { return DriverParameter.Value; }
            set { DriverParameter.Value = value; }
        }

        public void SetValue(DbType dbType, object paramValue, bool transformLiteral) {
            if (transformLiteral) {
                paramValue = executionService.TransformRuntimeToDatabaseValue(dbType, paramValue);
            }
            executionService.SetParameterValue(DriverParameter, dbType, paramValue);
        }

        public ParameterDirection ParamDirection {
            get { return DriverParameter.Direction; }
            set { executionService.SetParameterDirection(DriverParameter, value); }
        }

        public int Size {
            set { DriverParameter.Size = value; }
            get { return DriverParameter.Size; }
        }

        public DbType DbType {
            get { return DriverParameter.DbType; }
            set { DriverParameter.DbType = value; }
        }
    }
}