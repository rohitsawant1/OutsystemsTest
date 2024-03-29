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

	public class JSONENMenuItemEntityRecord: AbstractRESTStructure<ENMenuItemEntityRecord> {
		[JsonProperty("Id")]
		public int? AttrId;

		[JsonProperty("Order")]
		public int? AttrOrder;

		[JsonProperty("Caption")]
		public string AttrCaption;

		public JSONENMenuItemEntityRecord() {}

		public JSONENMenuItemEntityRecord(ENMenuItemEntityRecord s, IBehaviorsConfiguration config) {
			if (config.DefaultValuesBehavior == DefaultValuesBehavior.DontSend) {
				AttrId = (int?) s.ssId;
				AttrOrder = (int?) s.ssOrder;
				AttrCaption = s.ssCaption;
			} else {
				AttrId = (int?) s.ssId;
				AttrOrder = (int?) s.ssOrder;
				AttrCaption = s.ssCaption;
			}
		}

		public static Func<ssContactManager.RestRecords.JSONENMenuItemEntityRecord, ENMenuItemEntityRecord> ToStructureDelegate(IBehaviorsConfiguration config) {
			return (ssContactManager.RestRecords.JSONENMenuItemEntityRecord s) => ToStructure(s, config);
		}
		public static ENMenuItemEntityRecord ToStructure(ssContactManager.RestRecords.JSONENMenuItemEntityRecord obj, IBehaviorsConfiguration config) {
			ENMenuItemEntityRecord s = new ENMenuItemEntityRecord(null);
			if (obj != null) {
				s.ssId = obj.AttrId == null ? 0: obj.AttrId.Value;
				s.ssOrder = obj.AttrOrder == null ? 0: obj.AttrOrder.Value;
				s.ssCaption = obj.AttrCaption == null ? "": obj.AttrCaption;
			}
			return s;
		}

		public static Func<ENMenuItemEntityRecord, ssContactManager.RestRecords.JSONENMenuItemEntityRecord> FromStructureDelegate(IBehaviorsConfiguration config) {
			return (ENMenuItemEntityRecord s) => FromStructure(s, config);
		}
		public static ssContactManager.RestRecords.JSONENMenuItemEntityRecord FromStructure(ENMenuItemEntityRecord s, IBehaviorsConfiguration config) {
			return new ssContactManager.RestRecords.JSONENMenuItemEntityRecord(s, config);
		}

	}



}