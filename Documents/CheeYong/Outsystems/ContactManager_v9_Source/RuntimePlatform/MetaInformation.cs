/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using OutSystems.RuntimeCommon;
using System.Data;

namespace OutSystems.HubEdition.RuntimePlatform.MetaInformation {
    public class ServiceStudioObject : Attribute {
        public ServiceStudioObject( string name) {
            this.name = name;
        }
        protected readonly string name;
        
        public string Name {
            get { return name; }
        }
    }

    public class EntityAttributeDetails : ServiceStudioObject {
        public EntityAttributeDetails(string name,int length, bool isAutonumber, bool isPrimaryKey, bool isEntityReference, bool isMandatory)
            : base(name) {
            this.length = length;
            this.isAutonumber = isAutonumber;
            this.isPrimaryKey = isPrimaryKey;
            this.isEntityReference = isEntityReference;
            this.isMandatory = isMandatory;
        }
        
        protected int length;
        
        public int Length {
            get { return length; }
        }

        protected bool isAutonumber;

        public bool IsAutonumber {
            get { return isAutonumber; }
        }

        protected bool isPrimaryKey;

        public bool IsPrimaryKey {
            get { return isPrimaryKey; }
        }

        protected bool isEntityReference;

        public bool IsEntityReference {
            get { return isEntityReference; }
        }

        protected bool isMandatory;

        public bool IsMandatory {
            get { return isMandatory; }
        }
        
    }
    
    public class EntityRecordDetails : ServiceStudioObject {
        
        public EntityRecordDetails(string name, string key, string ownerKey, int generation, string physicalTableName)
            : this(name, key, ownerKey, generation, physicalTableName, null) {
        }

        public EntityRecordDetails(string name, string key, string ownerKey, int generation, string physicalTableName, string dbConnection)
            : base(name) {

            this.key = key;
            this.ownerKey = ownerKey;
            this.generation = generation;
            this.physicalTableName = physicalTableName;
            this.dbConnection = dbConnection;
        }

        protected readonly string key;
        protected readonly string ownerKey;
        protected readonly int generation;
        protected readonly string physicalTableName;
        protected readonly string dbConnection;
        
        public string Key {
            get { return key; }
        }
        
        public string OwnerKey {
            get { return ownerKey; }
        }
        
        public int Generation {
            get { return generation; }
        }
        
        public string PhysicalTableName {
            get { return physicalTableName; }
        }

        public string DBConnection {
            get { return dbConnection; }
        }
    }

}
