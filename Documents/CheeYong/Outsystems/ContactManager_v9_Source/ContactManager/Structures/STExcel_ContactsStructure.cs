﻿/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Data;
using System.Runtime.Serialization;
using System.Reflection;
using System.Xml;
using OutSystems.ObjectKeys;
using OutSystems.RuntimeCommon;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Db;
using OutSystems.Internal.Db;
using System.Xml.Serialization;
using System.Collections;
using OutSystems.HubEdition.RuntimePlatform.NewRuntime;

namespace ssContactManager {
	/// <summary>
	/// Structure <code>STExcel_ContactsStructure</code> that represents the Service Studio structure
	///  <code>Excel_Contacts</code> <p> Description: </p>
	/// </summary>
	[Serializable()]
	public partial struct STExcel_ContactsStructure: ISerializable, ITypedRecord<STExcel_ContactsStructure>, ISimpleRecord {
		private static readonly GlobalObjectKey IdName = GlobalObjectKey.Parse("X0RMeX3yYU+0eg2nFEDfaA*zCiUgsUvxU2OwJkO95JpOw");
		private static readonly GlobalObjectKey IdJobTitle = GlobalObjectKey.Parse("X0RMeX3yYU+0eg2nFEDfaA*+dUKzCy8wEuj6PJHd3dy+g");
		private static readonly GlobalObjectKey IdPhone = GlobalObjectKey.Parse("X0RMeX3yYU+0eg2nFEDfaA*UZFtWPuVYU+5pgK9txt6hw");
		private static readonly GlobalObjectKey IdEmail = GlobalObjectKey.Parse("X0RMeX3yYU+0eg2nFEDfaA*yLAOIsxeoU6xt7H2HuuZZw");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Name")]
		public string ssName;

		[System.Xml.Serialization.XmlElement("JobTitle")]
		public string ssJobTitle;

		[System.Xml.Serialization.XmlElement("Phone")]
		public string ssPhone;

		[System.Xml.Serialization.XmlElement("Email")]
		public string ssEmail;


		public BitArray OptimizedAttributes;

		public STExcel_ContactsStructure(params string[] dummy) {
			OptimizedAttributes = null;
			ssName = "";
			ssJobTitle = "";
			ssPhone = "";
			ssEmail = "";
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[0];
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
				} else {
				}
			}
			get {
				BitArray[] all = new BitArray[0];
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssName = r.ReadText(index++, "Excel_Contacts.Name", "");
			ssJobTitle = r.ReadText(index++, "Excel_Contacts.JobTitle", "");
			ssPhone = r.ReadPhoneNumber(index++, "Excel_Contacts.Phone", "");
			ssEmail = r.ReadEmail(index++, "Excel_Contacts.Email", "");
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(STExcel_ContactsStructure r) {
			this = r;
		}


		public static bool operator == (STExcel_ContactsStructure a, STExcel_ContactsStructure b) {
			if (a.ssName != b.ssName) return false;
			if (a.ssJobTitle != b.ssJobTitle) return false;
			if (a.ssPhone != b.ssPhone) return false;
			if (a.ssEmail != b.ssEmail) return false;
			return true;
		}

		public static bool operator != (STExcel_ContactsStructure a, STExcel_ContactsStructure b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(STExcel_ContactsStructure)) return false;
			return (this == (STExcel_ContactsStructure) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssName.GetHashCode()
				^ ssJobTitle.GetHashCode()
				^ ssPhone.GetHashCode()
				^ ssEmail.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public STExcel_ContactsStructure(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssName = "";
			ssJobTitle = "";
			ssPhone = "";
			ssEmail = "";
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssName", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssName' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssName = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssJobTitle", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssJobTitle' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssJobTitle = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssPhone", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssPhone' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssPhone = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssEmail", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssEmail' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssEmail = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
		}

		public void InternalRecursiveSave() {
		}


		public STExcel_ContactsStructure Duplicate() {
			STExcel_ContactsStructure t;
			t.ssName = this.ssName;
			t.ssJobTitle = this.ssJobTitle;
			t.ssPhone = this.ssPhone;
			t.ssEmail = this.ssEmail;
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Structure");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
				fieldName = fieldName.ToLowerInvariant();
			}
			if (detailLevel > 0) {
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".Name")) VarValue.AppendAttribute(recordElem, "Name", ssName, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "Name");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".JobTitle")) VarValue.AppendAttribute(recordElem, "JobTitle", ssJobTitle, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "JobTitle");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".Phone")) VarValue.AppendAttribute(recordElem, "Phone", ssPhone, detailLevel, TypeKind.PhoneNumber); else VarValue.AppendOptimizedAttribute(recordElem, "Phone");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".Email")) VarValue.AppendAttribute(recordElem, "Email", ssEmail, detailLevel, TypeKind.Email); else VarValue.AppendOptimizedAttribute(recordElem, "Email");
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "name") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Name")) variable.Value = ssName; else variable.Optimized = true;
			} else if (head == "jobtitle") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".JobTitle")) variable.Value = ssJobTitle; else variable.Optimized = true;
			} else if (head == "phone") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Phone")) variable.Value = ssPhone; else variable.Optimized = true;
			} else if (head == "email") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Email")) variable.Value = ssEmail; else variable.Optimized = true;
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdName) {
				return ssName;
			} else if (key == IdJobTitle) {
				return ssJobTitle;
			} else if (key == IdPhone) {
				return ssPhone;
			} else if (key == IdEmail) {
				return ssEmail;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssName = (string) other.AttributeGet(IdName);
			ssJobTitle = (string) other.AttributeGet(IdJobTitle);
			ssPhone = (string) other.AttributeGet(IdPhone);
			ssEmail = (string) other.AttributeGet(IdEmail);
		}
	} // STExcel_ContactsStructure
	/// <summary>
	/// Structure <code>RCExcel_ContactsRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCExcel_ContactsRecord: ISerializable, ITypedRecord<RCExcel_ContactsRecord> {
		private static readonly GlobalObjectKey IdExcel_Contacts = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*6XRh7Abk6qnvR0iT6tENWg");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Excel_Contacts")]
		public STExcel_ContactsStructure ssSTExcel_Contacts;


		public static implicit operator STExcel_ContactsStructure(RCExcel_ContactsRecord r) {
			return r.ssSTExcel_Contacts;
		}

		public static implicit operator RCExcel_ContactsRecord(STExcel_ContactsStructure r) {
			RCExcel_ContactsRecord res = new RCExcel_ContactsRecord(null);
			res.ssSTExcel_Contacts = r;
			return res;
		}

		public BitArray OptimizedAttributes;

		public RCExcel_ContactsRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssSTExcel_Contacts = new STExcel_ContactsStructure(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = null;
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
				} else {
					ssSTExcel_Contacts.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = null;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssSTExcel_Contacts.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCExcel_ContactsRecord r) {
			this = r;
		}


		public static bool operator == (RCExcel_ContactsRecord a, RCExcel_ContactsRecord b) {
			if (a.ssSTExcel_Contacts != b.ssSTExcel_Contacts) return false;
			return true;
		}

		public static bool operator != (RCExcel_ContactsRecord a, RCExcel_ContactsRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCExcel_ContactsRecord)) return false;
			return (this == (RCExcel_ContactsRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssSTExcel_Contacts.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCExcel_ContactsRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssSTExcel_Contacts = new STExcel_ContactsStructure(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssSTExcel_Contacts", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssSTExcel_Contacts' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssSTExcel_Contacts = (STExcel_ContactsStructure) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssSTExcel_Contacts.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssSTExcel_Contacts.InternalRecursiveSave();
		}


		public RCExcel_ContactsRecord Duplicate() {
			RCExcel_ContactsRecord t;
			t.ssSTExcel_Contacts = (STExcel_ContactsStructure) this.ssSTExcel_Contacts.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssSTExcel_Contacts.ToXml(this, recordElem, "Excel_Contacts", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "excel_contacts") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Excel_Contacts")) variable.Value = ssSTExcel_Contacts; else variable.Optimized = true;
				variable.SetFieldName("excel_contacts");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdExcel_Contacts) {
				return ssSTExcel_Contacts;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssSTExcel_Contacts.FillFromOther((IRecord) other.AttributeGet(IdExcel_Contacts));
		}
	} // RCExcel_ContactsRecord
	/// <summary>
	/// RecordList type <code>RLExcel_ContactsRecordList</code> that represents a record list of
	///  <code>Excel_Contacts</code>
	/// </summary>
	[Serializable()]
	public partial class RLExcel_ContactsRecordList: GenericRecordList<RCExcel_ContactsRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCExcel_ContactsRecord GetElementDefaultValue() {
			return new RCExcel_ContactsRecord("");
		}

		public T[] ToArray<T>(Func<RCExcel_ContactsRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLExcel_ContactsRecordList recordlist, Func<RCExcel_ContactsRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLExcel_ContactsRecordList(RCExcel_ContactsRecord[] array) {
			RLExcel_ContactsRecordList result = new RLExcel_ContactsRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLExcel_ContactsRecordList ToList<T>(T[] array, Func <T, RCExcel_ContactsRecord> converter) {
			RLExcel_ContactsRecordList result = new RLExcel_ContactsRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLExcel_ContactsRecordList FromRestList<T>(RestList<T> restList, Func <T, RCExcel_ContactsRecord> converter) {
			RLExcel_ContactsRecordList result = new RLExcel_ContactsRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLExcel_ContactsRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLExcel_ContactsRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLExcel_ContactsRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLExcel_ContactsRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = null;
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCExcel_ContactsRecord> NewList() {
			return new RLExcel_ContactsRecordList();
		}


	} // RLExcel_ContactsRecordList
	/// <summary>
	/// RecordList type <code>RLExcel_ContactsList</code> that represents a record list of
	///  <code>Excel_Contacts</code>
	/// </summary>
	[Serializable()]
	public partial class RLExcel_ContactsList: GenericRecordList<STExcel_ContactsStructure>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override STExcel_ContactsStructure GetElementDefaultValue() {
			return new STExcel_ContactsStructure("");
		}

		public T[] ToArray<T>(Func<STExcel_ContactsStructure, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLExcel_ContactsList recordlist, Func<STExcel_ContactsStructure, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLExcel_ContactsList(STExcel_ContactsStructure[] array) {
			RLExcel_ContactsList result = new RLExcel_ContactsList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLExcel_ContactsList ToList<T>(T[] array, Func <T, STExcel_ContactsStructure> converter) {
			RLExcel_ContactsList result = new RLExcel_ContactsList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLExcel_ContactsList FromRestList<T>(RestList<T> restList, Func <T, STExcel_ContactsStructure> converter) {
			RLExcel_ContactsList result = new RLExcel_ContactsList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLExcel_ContactsList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLExcel_ContactsList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLExcel_ContactsList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLExcel_ContactsList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[0];
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<STExcel_ContactsStructure> NewList() {
			return new RLExcel_ContactsList();
		}


	} // RLExcel_ContactsList
}

namespace ssContactManager {
	[XmlType("Excel_Contacts")]
	public class WORCExcel_ContactsRecord {
		[System.Xml.Serialization.XmlElement("Name")]
		public string varWSName;

		[System.Xml.Serialization.XmlElement("JobTitle")]
		public string varWSJobTitle;

		[System.Xml.Serialization.XmlElement("Phone")]
		public string varWSPhone;

		[System.Xml.Serialization.XmlElement("Email")]
		public string varWSEmail;

		public WORCExcel_ContactsRecord() {
			varWSName = (string) "";
			varWSJobTitle = (string) "";
			varWSPhone = (string) "";
			varWSEmail = (string) "";
		}

		public WORCExcel_ContactsRecord(STExcel_ContactsStructure r) {
			varWSName = BaseAppUtils.RemoveControlChars(r.ssName);
			varWSJobTitle = BaseAppUtils.RemoveControlChars(r.ssJobTitle);
			varWSPhone = BaseAppUtils.RemoveControlChars(r.ssPhone);
			varWSEmail = BaseAppUtils.RemoveControlChars(r.ssEmail);
		}

		public static RLExcel_ContactsList ToRecordList(WORCExcel_ContactsRecord[] array) {
			RLExcel_ContactsList rl = new RLExcel_ContactsList();
			if (array != null) {
				foreach(WORCExcel_ContactsRecord val in array) {
					rl.Append(val);
				}
			}
			return rl;
		}

		public static WORCExcel_ContactsRecord[] FromRecordList(RLExcel_ContactsList rl) {
			WORCExcel_ContactsRecord[] array = new WORCExcel_ContactsRecord[rl == null ? 0: rl.Length];
			for (int i = 0; i < array.Length; i++) {
				array[i] = rl.Data[i];
			}
			return array;
		}
	}
}

namespace ssContactManager {
	partial struct RCExcel_ContactsRecord {
		public static implicit operator WORCExcel_ContactsRecord(RCExcel_ContactsRecord r) {
			return new WORCExcel_ContactsRecord(r.ssSTExcel_Contacts);
		}

		public static implicit operator RCExcel_ContactsRecord(WORCExcel_ContactsRecord w) {
			RCExcel_ContactsRecord r = new RCExcel_ContactsRecord("");
			if (w != null) {
				r.ssSTExcel_Contacts = w;
			}
			return r;
		}

	}

	partial struct STExcel_ContactsStructure {
		public static implicit operator WORCExcel_ContactsRecord(STExcel_ContactsStructure r) {
			return new WORCExcel_ContactsRecord(r);
		}

		public static implicit operator STExcel_ContactsStructure(WORCExcel_ContactsRecord w) {
			STExcel_ContactsStructure r = new STExcel_ContactsStructure("");
			if (w != null) {
				r.ssName = ((string) w.varWSName ?? "");
				r.ssJobTitle = ((string) w.varWSJobTitle ?? "");
				r.ssPhone = ((string) w.varWSPhone ?? "");
				r.ssEmail = ((string) w.varWSEmail ?? "");
			}
			return r;
		}

	}
}


namespace ssContactManager {
	[Serializable()]
	public partial class WORLExcel_ContactsRecordList {
		public WORCExcel_ContactsRecord[] Array;


		public WORLExcel_ContactsRecordList(WORCExcel_ContactsRecord[] r) {
			if (r == null)
			Array = new WORCExcel_ContactsRecord[0];
			else
			Array = r;
		}
		public WORLExcel_ContactsRecordList() {
			Array = new WORCExcel_ContactsRecord[0];
		}

		public WORLExcel_ContactsRecordList(RLExcel_ContactsRecordList rl) {
			rl=(RLExcel_ContactsRecordList) rl.Duplicate();
			Array = new WORCExcel_ContactsRecord[rl.Length];
			while (!rl.Eof) {
				Array[rl.CurrentRowNumber] = new WORCExcel_ContactsRecord(rl.CurrentRec);
				rl.Advance();
			}
		}

	}
}

namespace ssContactManager {
	partial class RLExcel_ContactsRecordList {
		public static implicit operator RLExcel_ContactsRecordList(WORCExcel_ContactsRecord[] array) {
			RLExcel_ContactsRecordList rl = new RLExcel_ContactsRecordList();
			if (array != null) {
				foreach(WORCExcel_ContactsRecord val in array) {
					rl.Append((RCExcel_ContactsRecord) val);
				}
			}
			return rl;
		}
		public static implicit operator WORCExcel_ContactsRecord[](RLExcel_ContactsRecordList rl) {
			WORCExcel_ContactsRecord[] array = new WORCExcel_ContactsRecord[rl == null ? 0: rl.Length];
			for (int i = 0; i < array.Length; i++) {
				array[i] = (RCExcel_ContactsRecord) rl.Data[i];
			}
			return array;
		}
	}
}

namespace ssContactManager {
	partial class WORLExcel_ContactsRecordList {
		public static implicit operator RLExcel_ContactsRecordList(WORLExcel_ContactsRecordList w) {
			return w.Array;
		}
		public static implicit operator WORLExcel_ContactsRecordList(RLExcel_ContactsRecordList rl) {
			return new WORLExcel_ContactsRecordList(rl);
		}
		public static implicit operator WORCExcel_ContactsRecord[](WORLExcel_ContactsRecordList w) {
			if (w != null) {
				return w.Array;
			}
			return null;
		}
		public static implicit operator WORLExcel_ContactsRecordList(WORCExcel_ContactsRecord[] array) {
			return new WORLExcel_ContactsRecordList(array);
		}
	}
}

namespace ssContactManager {
	[Serializable()]
	public partial class WORLExcel_ContactsList {
		public WORCExcel_ContactsRecord[] Array;


		public WORLExcel_ContactsList(WORCExcel_ContactsRecord[] r) {
			if (r == null)
			Array = new WORCExcel_ContactsRecord[0];
			else
			Array = r;
		}
		public WORLExcel_ContactsList() {
			Array = new WORCExcel_ContactsRecord[0];
		}

		public WORLExcel_ContactsList(RLExcel_ContactsList rl) {
			rl=(RLExcel_ContactsList) rl.Duplicate();
			Array = new WORCExcel_ContactsRecord[rl.Length];
			while (!rl.Eof) {
				Array[rl.CurrentRowNumber] = rl.CurrentRec.Duplicate();
				rl.Advance();
			}
		}

	}
}

namespace ssContactManager {
	partial class RLExcel_ContactsList {
		public static implicit operator RLExcel_ContactsList(WORCExcel_ContactsRecord[] array) {
			RLExcel_ContactsList rl = new RLExcel_ContactsList();
			if (array != null) {
				foreach(WORCExcel_ContactsRecord val in array) {
					rl.Append((STExcel_ContactsStructure) val);
				}
			}
			return rl;
		}
		public static implicit operator WORCExcel_ContactsRecord[](RLExcel_ContactsList rl) {
			WORCExcel_ContactsRecord[] array = new WORCExcel_ContactsRecord[rl == null ? 0: rl.Length];
			for (int i = 0; i < array.Length; i++) {
				array[i] = (STExcel_ContactsStructure) rl.Data[i];
			}
			return array;
		}
	}
}

namespace ssContactManager {
	partial class WORLExcel_ContactsList {
		public static implicit operator RLExcel_ContactsList(WORLExcel_ContactsList w) {
			return w.Array;
		}
		public static implicit operator WORLExcel_ContactsList(RLExcel_ContactsList rl) {
			return new WORLExcel_ContactsList(rl);
		}
		public static implicit operator WORCExcel_ContactsRecord[](WORLExcel_ContactsList w) {
			if (w != null) {
				return w.Array;
			}
			return null;
		}
		public static implicit operator WORLExcel_ContactsList(WORCExcel_ContactsRecord[] array) {
			return new WORLExcel_ContactsList(array);
		}
	}
}

