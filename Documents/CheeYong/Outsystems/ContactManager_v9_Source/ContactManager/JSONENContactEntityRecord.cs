﻿/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Linq;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Db;
using OutSystems.Internal.Db;
using OutSystems.RuntimeCommon;
using OutSystems.RuntimeCommon.Caching;

using System.Text;
using System.Data;
using System.Collections.Generic;
using Newtonsoft.Json;
using OutSystems.RESTService;
using OutSystems.RESTService.Behaviors;
using OutSystems.RESTService.Controllers;
using OutSystems.ObjectKeys;
using OutSystems.HubEdition.RuntimePlatform.NewRuntime;


namespace ssContactManager.RestRecords {

	public class JSONENContactEntityRecord: AbstractRESTStructure<ENContactEntityRecord> {
		[JsonProperty("Id")]
		public int? AttrId;

		[JsonProperty("Name")]
		public string AttrName;

		[JsonProperty("JobTitle")]
		public string AttrJobTitle;

		[JsonProperty("Phone")]
		public string AttrPhone;

		[JsonProperty("Email")]
		public string AttrEmail;

		[JsonProperty("Notes")]
		public string AttrNotes;

		public JSONENContactEntityRecord() {}

		public JSONENContactEntityRecord(ENContactEntityRecord s, IBehaviorsConfiguration config) {
			if (config.DefaultValuesBehavior == DefaultValuesBehavior.DontSend) {
				AttrId = (int?) s.ssId;
				AttrName = s.ssName;
				AttrJobTitle = ConvertToRestWithoutDefaults(s.ssJobTitle, "");
				AttrPhone = ConvertToRestWithoutDefaults(s.ssPhone, "");
				AttrEmail = ConvertToRestWithoutDefaults(s.ssEmail, "");
				AttrNotes = ConvertToRestWithoutDefaults(s.ssNotes, "");
			} else {
				AttrId = (int?) s.ssId;
				AttrName = s.ssName;
				AttrJobTitle = s.ssJobTitle;
				AttrPhone = s.ssPhone;
				AttrEmail = s.ssEmail;
				AttrNotes = s.ssNotes;
			}
		}

		public static Func<ssContactManager.RestRecords.JSONENContactEntityRecord, ENContactEntityRecord> ToStructureDelegate(IBehaviorsConfiguration config) {
			return (ssContactManager.RestRecords.JSONENContactEntityRecord s) => ToStructure(s, config);
		}
		public static ENContactEntityRecord ToStructure(ssContactManager.RestRecords.JSONENContactEntityRecord obj, IBehaviorsConfiguration config) {
			ENContactEntityRecord s = new ENContactEntityRecord(null);
			if (obj != null) {
				s.ssId = obj.AttrId == null ? 0: obj.AttrId.Value;
				s.ssName = obj.AttrName == null ? "": obj.AttrName;
				s.ssJobTitle = obj.AttrJobTitle == null ? "": obj.AttrJobTitle;
				s.ssPhone = obj.AttrPhone == null ? "": obj.AttrPhone;
				s.ssEmail = obj.AttrEmail == null ? "": obj.AttrEmail;
				s.ssNotes = obj.AttrNotes == null ? "": obj.AttrNotes;
			}
			return s;
		}

		public static Func<ENContactEntityRecord, ssContactManager.RestRecords.JSONENContactEntityRecord> FromStructureDelegate(IBehaviorsConfiguration config) {
			return (ENContactEntityRecord s) => FromStructure(s, config);
		}
		public static ssContactManager.RestRecords.JSONENContactEntityRecord FromStructure(ENContactEntityRecord s, IBehaviorsConfiguration config) {
			return new ssContactManager.RestRecords.JSONENContactEntityRecord(s, config);
		}

	}



}