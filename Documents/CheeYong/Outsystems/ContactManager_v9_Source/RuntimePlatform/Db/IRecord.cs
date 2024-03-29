/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using OutSystems.ObjectKeys;
using System.Collections;
using OutSystems.RuntimeCommon;
using System.Data;

namespace OutSystems.HubEdition.RuntimePlatform.Db
{
	/// <summary>
    /// Represents a record from the database.
	/// </summary>
	public interface IRecord
	{
        object AttributeGet(GlobalObjectKey key);
        void FillFromOther(IRecord other);
        bool ChangedAttributeGet(GlobalObjectKey key);
        bool OptimizedAttributeGet(GlobalObjectKey key);

        void ReadDB(IDataReader reader);
        BitArray[] AllOptimizedAttributes { get; set; }

        IRecord Duplicate();
        void RecursiveReset();
        void InternalRecursiveSave();
	}

    public interface ITypedRecord<ConcreteRecordType> : IRecord {
        void ReadIM(ConcreteRecordType record);
        new ConcreteRecordType Duplicate();
    }

    public delegate void CreateRecordFunction<TargetType>(ref TargetType targetRec);
    public delegate void ConvertFunction<SourceType, TargetType>(ref SourceType sourceRec, ref TargetType targetRec);

    public class RecordUtils {

        public static T Create<T>(T targetRec, CreateRecordFunction<T> create) {
            create(ref targetRec);
            return targetRec;
        }

        public static T Convert<S, T>(S source, Func<S, T> converter) {
            return converter(source);
        }

        public static T Convert<S, T>(S sourceRec, T targetRec, ConvertFunction<S, T> conv) {
            conv(ref sourceRec, ref targetRec);
            return targetRec;
        }
    }
}
