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

	public class JSONENMessageTypeEntityRecord: AbstractRESTStructure<ENMessageTypeEntityRecord> {
		[JsonProperty("Id")]
		public int? AttrId;

		[JsonProperty("Label")]
		public string AttrLabel;

		public JSONENMessageTypeEntityRecord() {}

		public JSONENMessageTypeEntityRecord(ENMessageTypeEntityRecord s, IBehaviorsConfiguration config) {
			if (config.DefaultValuesBehavior == DefaultValuesBehavior.DontSend) {
				AttrId = (int?) s.ssId;
				AttrLabel = s.ssLabel;
			} else {
				AttrId = (int?) s.ssId;
				AttrLabel = s.ssLabel;
			}
		}

		public static Func<ssContactManager.RestRecords.JSONENMessageTypeEntityRecord, ENMessageTypeEntityRecord> ToStructureDelegate(IBehaviorsConfiguration config) {
			return (ssContactManager.RestRecords.JSONENMessageTypeEntityRecord s) => ToStructure(s, config);
		}
		public static ENMessageTypeEntityRecord ToStructure(ssContactManager.RestRecords.JSONENMessageTypeEntityRecord obj, IBehaviorsConfiguration config) {
			ENMessageTypeEntityRecord s = new ENMessageTypeEntityRecord(null);
			if (obj != null) {
				s.ssId = obj.AttrId == null ? 0: obj.AttrId.Value;
				s.ssLabel = obj.AttrLabel == null ? "": obj.AttrLabel;
			}
			return s;
		}

		public static Func<ENMessageTypeEntityRecord, ssContactManager.RestRecords.JSONENMessageTypeEntityRecord> FromStructureDelegate(IBehaviorsConfiguration config) {
			return (ENMessageTypeEntityRecord s) => FromStructure(s, config);
		}
		public static ssContactManager.RestRecords.JSONENMessageTypeEntityRecord FromStructure(ENMessageTypeEntityRecord s, IBehaviorsConfiguration config) {
			return new ssContactManager.RestRecords.JSONENMessageTypeEntityRecord(s, config);
		}

	}



}