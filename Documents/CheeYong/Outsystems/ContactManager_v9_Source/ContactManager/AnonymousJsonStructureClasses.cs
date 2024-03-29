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

	public class JSONRCFeedback_MessageRecord: AbstractRESTStructure<RCFeedback_MessageRecord> {
		[JsonProperty("Feedback_Message")]
		public ssContactManager.RestRecords.JSONSTFeedback_MessageStructure AttrFeedback_Message;

		public JSONRCFeedback_MessageRecord() {}

		public JSONRCFeedback_MessageRecord(RCFeedback_MessageRecord s, IBehaviorsConfiguration config) {
			if (config.DefaultValuesBehavior == DefaultValuesBehavior.DontSend) {
				AttrFeedback_Message = ConvertToRestWithoutDefaults(s.ssSTFeedback_Message, new STFeedback_MessageStructure(null), ssContactManager.RestRecords.JSONSTFeedback_MessageStructure.FromStructureDelegate(config));
			} else {
				AttrFeedback_Message = ssContactManager.RestRecords.JSONSTFeedback_MessageStructure.FromStructure(s.ssSTFeedback_Message, config);
			}
		}

		public static Func<ssContactManager.RestRecords.JSONRCFeedback_MessageRecord, RCFeedback_MessageRecord> ToStructureDelegate(IBehaviorsConfiguration config) {
			return (ssContactManager.RestRecords.JSONRCFeedback_MessageRecord s) => ToStructure(s, config);
		}
		public static RCFeedback_MessageRecord ToStructure(ssContactManager.RestRecords.JSONRCFeedback_MessageRecord obj, IBehaviorsConfiguration config) {
			RCFeedback_MessageRecord s = new RCFeedback_MessageRecord(null);
			if (obj != null) {
				s.ssSTFeedback_Message = ssContactManager.RestRecords.JSONSTFeedback_MessageStructure.ToStructure(obj.AttrFeedback_Message, config);
			}
			return s;
		}

		public static Func<RCFeedback_MessageRecord, ssContactManager.RestRecords.JSONRCFeedback_MessageRecord> FromStructureDelegate(IBehaviorsConfiguration config) {
			return (RCFeedback_MessageRecord s) => FromStructure(s, config);
		}
		public static ssContactManager.RestRecords.JSONRCFeedback_MessageRecord FromStructure(RCFeedback_MessageRecord s, IBehaviorsConfiguration config) {
			return new ssContactManager.RestRecords.JSONRCFeedback_MessageRecord(s, config);
		}

	}

	public class JSONRCUserRecord: AbstractRESTStructure<RCUserRecord> {
		[JsonProperty("User")]
		public ssContactManager.RestRecords.JSONENUserEntityRecord AttrUser;

		public JSONRCUserRecord() {}

		public JSONRCUserRecord(RCUserRecord s, IBehaviorsConfiguration config) {
			if (config.DefaultValuesBehavior == DefaultValuesBehavior.DontSend) {
				AttrUser = ConvertToRestWithoutDefaults(s.ssENUser, new ENUserEntityRecord(null), ssContactManager.RestRecords.JSONENUserEntityRecord.FromStructureDelegate(config));
			} else {
				AttrUser = ssContactManager.RestRecords.JSONENUserEntityRecord.FromStructure(s.ssENUser, config);
			}
		}

		public static Func<ssContactManager.RestRecords.JSONRCUserRecord, RCUserRecord> ToStructureDelegate(IBehaviorsConfiguration config) {
			return (ssContactManager.RestRecords.JSONRCUserRecord s) => ToStructure(s, config);
		}
		public static RCUserRecord ToStructure(ssContactManager.RestRecords.JSONRCUserRecord obj, IBehaviorsConfiguration config) {
			RCUserRecord s = new RCUserRecord(null);
			if (obj != null) {
				s.ssENUser = ssContactManager.RestRecords.JSONENUserEntityRecord.ToStructure(obj.AttrUser, config);
			}
			return s;
		}

		public static Func<RCUserRecord, ssContactManager.RestRecords.JSONRCUserRecord> FromStructureDelegate(IBehaviorsConfiguration config) {
			return (RCUserRecord s) => FromStructure(s, config);
		}
		public static ssContactManager.RestRecords.JSONRCUserRecord FromStructure(RCUserRecord s, IBehaviorsConfiguration config) {
			return new ssContactManager.RestRecords.JSONRCUserRecord(s, config);
		}

	}

	public class JSONRCRecentItemRecord: AbstractRESTStructure<RCRecentItemRecord> {
		[JsonProperty("RecentItem")]
		public ssContactManager.RestRecords.JSONENRecentItemEntityRecord AttrRecentItem;

		public JSONRCRecentItemRecord() {}

		public JSONRCRecentItemRecord(RCRecentItemRecord s, IBehaviorsConfiguration config) {
			if (config.DefaultValuesBehavior == DefaultValuesBehavior.DontSend) {
				AttrRecentItem = ConvertToRestWithoutDefaults(s.ssENRecentItem, new ENRecentItemEntityRecord(null), ssContactManager.RestRecords.JSONENRecentItemEntityRecord.FromStructureDelegate(config));
			} else {
				AttrRecentItem = ssContactManager.RestRecords.JSONENRecentItemEntityRecord.FromStructure(s.ssENRecentItem, config);
			}
		}

		public static Func<ssContactManager.RestRecords.JSONRCRecentItemRecord, RCRecentItemRecord> ToStructureDelegate(IBehaviorsConfiguration config) {
			return (ssContactManager.RestRecords.JSONRCRecentItemRecord s) => ToStructure(s, config);
		}
		public static RCRecentItemRecord ToStructure(ssContactManager.RestRecords.JSONRCRecentItemRecord obj, IBehaviorsConfiguration config) {
			RCRecentItemRecord s = new RCRecentItemRecord(null);
			if (obj != null) {
				s.ssENRecentItem = ssContactManager.RestRecords.JSONENRecentItemEntityRecord.ToStructure(obj.AttrRecentItem, config);
			}
			return s;
		}

		public static Func<RCRecentItemRecord, ssContactManager.RestRecords.JSONRCRecentItemRecord> FromStructureDelegate(IBehaviorsConfiguration config) {
			return (RCRecentItemRecord s) => FromStructure(s, config);
		}
		public static ssContactManager.RestRecords.JSONRCRecentItemRecord FromStructure(RCRecentItemRecord s, IBehaviorsConfiguration config) {
			return new ssContactManager.RestRecords.JSONRCRecentItemRecord(s, config);
		}

	}

	public class JSONRCListNavigation_PageNumberRecord: AbstractRESTStructure<RCListNavigation_PageNumberRecord> {
		[JsonProperty("ListNavigation_PageNumber")]
		public ssContactManager.RestRecords.JSONSTListNavigation_PageNumberStructure AttrListNavigation_PageNumber;

		public JSONRCListNavigation_PageNumberRecord() {}

		public JSONRCListNavigation_PageNumberRecord(RCListNavigation_PageNumberRecord s, IBehaviorsConfiguration config) {
			if (config.DefaultValuesBehavior == DefaultValuesBehavior.DontSend) {
				AttrListNavigation_PageNumber = ConvertToRestWithoutDefaults(s.ssSTListNavigation_PageNumber, new STListNavigation_PageNumberStructure(null), ssContactManager.RestRecords.JSONSTListNavigation_PageNumberStructure.FromStructureDelegate(config));
			} else {
				AttrListNavigation_PageNumber = ssContactManager.RestRecords.JSONSTListNavigation_PageNumberStructure.FromStructure(s.ssSTListNavigation_PageNumber, config);
			}
		}

		public static Func<ssContactManager.RestRecords.JSONRCListNavigation_PageNumberRecord, RCListNavigation_PageNumberRecord> ToStructureDelegate(IBehaviorsConfiguration config) {
			return (ssContactManager.RestRecords.JSONRCListNavigation_PageNumberRecord s) => ToStructure(s, config);
		}
		public static RCListNavigation_PageNumberRecord ToStructure(ssContactManager.RestRecords.JSONRCListNavigation_PageNumberRecord obj, IBehaviorsConfiguration config) {
			RCListNavigation_PageNumberRecord s = new RCListNavigation_PageNumberRecord(null);
			if (obj != null) {
				s.ssSTListNavigation_PageNumber = ssContactManager.RestRecords.JSONSTListNavigation_PageNumberStructure.ToStructure(obj.AttrListNavigation_PageNumber, config);
			}
			return s;
		}

		public static Func<RCListNavigation_PageNumberRecord, ssContactManager.RestRecords.JSONRCListNavigation_PageNumberRecord> FromStructureDelegate(IBehaviorsConfiguration config) {
			return (RCListNavigation_PageNumberRecord s) => FromStructure(s, config);
		}
		public static ssContactManager.RestRecords.JSONRCListNavigation_PageNumberRecord FromStructure(RCListNavigation_PageNumberRecord s, IBehaviorsConfiguration config) {
			return new ssContactManager.RestRecords.JSONRCListNavigation_PageNumberRecord(s, config);
		}

	}

	public class JSONRCMenuItemRecord: AbstractRESTStructure<RCMenuItemRecord> {
		[JsonProperty("MenuItem")]
		public ssContactManager.RestRecords.JSONENMenuItemEntityRecord AttrMenuItem;

		public JSONRCMenuItemRecord() {}

		public JSONRCMenuItemRecord(RCMenuItemRecord s, IBehaviorsConfiguration config) {
			if (config.DefaultValuesBehavior == DefaultValuesBehavior.DontSend) {
				AttrMenuItem = ConvertToRestWithoutDefaults(s.ssENMenuItem, new ENMenuItemEntityRecord(null), ssContactManager.RestRecords.JSONENMenuItemEntityRecord.FromStructureDelegate(config));
			} else {
				AttrMenuItem = ssContactManager.RestRecords.JSONENMenuItemEntityRecord.FromStructure(s.ssENMenuItem, config);
			}
		}

		public static Func<ssContactManager.RestRecords.JSONRCMenuItemRecord, RCMenuItemRecord> ToStructureDelegate(IBehaviorsConfiguration config) {
			return (ssContactManager.RestRecords.JSONRCMenuItemRecord s) => ToStructure(s, config);
		}
		public static RCMenuItemRecord ToStructure(ssContactManager.RestRecords.JSONRCMenuItemRecord obj, IBehaviorsConfiguration config) {
			RCMenuItemRecord s = new RCMenuItemRecord(null);
			if (obj != null) {
				s.ssENMenuItem = ssContactManager.RestRecords.JSONENMenuItemEntityRecord.ToStructure(obj.AttrMenuItem, config);
			}
			return s;
		}

		public static Func<RCMenuItemRecord, ssContactManager.RestRecords.JSONRCMenuItemRecord> FromStructureDelegate(IBehaviorsConfiguration config) {
			return (RCMenuItemRecord s) => FromStructure(s, config);
		}
		public static ssContactManager.RestRecords.JSONRCMenuItemRecord FromStructure(RCMenuItemRecord s, IBehaviorsConfiguration config) {
			return new ssContactManager.RestRecords.JSONRCMenuItemRecord(s, config);
		}

	}

	public class JSONRCApplicationRecord: AbstractRESTStructure<RCApplicationRecord> {
		[JsonProperty("Application")]
		public ssContactManager.RestRecords.JSONENApplicationEntityRecord AttrApplication;

		public JSONRCApplicationRecord() {}

		public JSONRCApplicationRecord(RCApplicationRecord s, IBehaviorsConfiguration config) {
			if (config.DefaultValuesBehavior == DefaultValuesBehavior.DontSend) {
				AttrApplication = ConvertToRestWithoutDefaults(s.ssENApplication, new ENApplicationEntityRecord(null), ssContactManager.RestRecords.JSONENApplicationEntityRecord.FromStructureDelegate(config));
			} else {
				AttrApplication = ssContactManager.RestRecords.JSONENApplicationEntityRecord.FromStructure(s.ssENApplication, config);
			}
		}

		public static Func<ssContactManager.RestRecords.JSONRCApplicationRecord, RCApplicationRecord> ToStructureDelegate(IBehaviorsConfiguration config) {
			return (ssContactManager.RestRecords.JSONRCApplicationRecord s) => ToStructure(s, config);
		}
		public static RCApplicationRecord ToStructure(ssContactManager.RestRecords.JSONRCApplicationRecord obj, IBehaviorsConfiguration config) {
			RCApplicationRecord s = new RCApplicationRecord(null);
			if (obj != null) {
				s.ssENApplication = ssContactManager.RestRecords.JSONENApplicationEntityRecord.ToStructure(obj.AttrApplication, config);
			}
			return s;
		}

		public static Func<RCApplicationRecord, ssContactManager.RestRecords.JSONRCApplicationRecord> FromStructureDelegate(IBehaviorsConfiguration config) {
			return (RCApplicationRecord s) => FromStructure(s, config);
		}
		public static ssContactManager.RestRecords.JSONRCApplicationRecord FromStructure(RCApplicationRecord s, IBehaviorsConfiguration config) {
			return new ssContactManager.RestRecords.JSONRCApplicationRecord(s, config);
		}

	}

	public class JSONRCMessageTypeRecord: AbstractRESTStructure<RCMessageTypeRecord> {
		[JsonProperty("MessageType")]
		public ssContactManager.RestRecords.JSONENMessageTypeEntityRecord AttrMessageType;

		public JSONRCMessageTypeRecord() {}

		public JSONRCMessageTypeRecord(RCMessageTypeRecord s, IBehaviorsConfiguration config) {
			if (config.DefaultValuesBehavior == DefaultValuesBehavior.DontSend) {
				AttrMessageType = ConvertToRestWithoutDefaults(s.ssENMessageType, new ENMessageTypeEntityRecord(null), ssContactManager.RestRecords.JSONENMessageTypeEntityRecord.FromStructureDelegate(config));
			} else {
				AttrMessageType = ssContactManager.RestRecords.JSONENMessageTypeEntityRecord.FromStructure(s.ssENMessageType, config);
			}
		}

		public static Func<ssContactManager.RestRecords.JSONRCMessageTypeRecord, RCMessageTypeRecord> ToStructureDelegate(IBehaviorsConfiguration config) {
			return (ssContactManager.RestRecords.JSONRCMessageTypeRecord s) => ToStructure(s, config);
		}
		public static RCMessageTypeRecord ToStructure(ssContactManager.RestRecords.JSONRCMessageTypeRecord obj, IBehaviorsConfiguration config) {
			RCMessageTypeRecord s = new RCMessageTypeRecord(null);
			if (obj != null) {
				s.ssENMessageType = ssContactManager.RestRecords.JSONENMessageTypeEntityRecord.ToStructure(obj.AttrMessageType, config);
			}
			return s;
		}

		public static Func<RCMessageTypeRecord, ssContactManager.RestRecords.JSONRCMessageTypeRecord> FromStructureDelegate(IBehaviorsConfiguration config) {
			return (RCMessageTypeRecord s) => FromStructure(s, config);
		}
		public static ssContactManager.RestRecords.JSONRCMessageTypeRecord FromStructure(RCMessageTypeRecord s, IBehaviorsConfiguration config) {
			return new ssContactManager.RestRecords.JSONRCMessageTypeRecord(s, config);
		}

	}

	public class JSONRCExcel_ContactsRecord: AbstractRESTStructure<RCExcel_ContactsRecord> {
		[JsonProperty("Excel_Contacts")]
		public ssContactManager.RestRecords.JSONSTExcel_ContactsStructure AttrExcel_Contacts;

		public JSONRCExcel_ContactsRecord() {}

		public JSONRCExcel_ContactsRecord(RCExcel_ContactsRecord s, IBehaviorsConfiguration config) {
			if (config.DefaultValuesBehavior == DefaultValuesBehavior.DontSend) {
				AttrExcel_Contacts = ConvertToRestWithoutDefaults(s.ssSTExcel_Contacts, new STExcel_ContactsStructure(null), ssContactManager.RestRecords.JSONSTExcel_ContactsStructure.FromStructureDelegate(config));
			} else {
				AttrExcel_Contacts = ssContactManager.RestRecords.JSONSTExcel_ContactsStructure.FromStructure(s.ssSTExcel_Contacts, config);
			}
		}

		public static Func<ssContactManager.RestRecords.JSONRCExcel_ContactsRecord, RCExcel_ContactsRecord> ToStructureDelegate(IBehaviorsConfiguration config) {
			return (ssContactManager.RestRecords.JSONRCExcel_ContactsRecord s) => ToStructure(s, config);
		}
		public static RCExcel_ContactsRecord ToStructure(ssContactManager.RestRecords.JSONRCExcel_ContactsRecord obj, IBehaviorsConfiguration config) {
			RCExcel_ContactsRecord s = new RCExcel_ContactsRecord(null);
			if (obj != null) {
				s.ssSTExcel_Contacts = ssContactManager.RestRecords.JSONSTExcel_ContactsStructure.ToStructure(obj.AttrExcel_Contacts, config);
			}
			return s;
		}

		public static Func<RCExcel_ContactsRecord, ssContactManager.RestRecords.JSONRCExcel_ContactsRecord> FromStructureDelegate(IBehaviorsConfiguration config) {
			return (RCExcel_ContactsRecord s) => FromStructure(s, config);
		}
		public static ssContactManager.RestRecords.JSONRCExcel_ContactsRecord FromStructure(RCExcel_ContactsRecord s, IBehaviorsConfiguration config) {
			return new ssContactManager.RestRecords.JSONRCExcel_ContactsRecord(s, config);
		}

	}

	public class JSONRCContactRecord: AbstractRESTStructure<RCContactRecord> {
		[JsonProperty("Contact")]
		public ssContactManager.RestRecords.JSONENContactEntityRecord AttrContact;

		public JSONRCContactRecord() {}

		public JSONRCContactRecord(RCContactRecord s, IBehaviorsConfiguration config) {
			if (config.DefaultValuesBehavior == DefaultValuesBehavior.DontSend) {
				AttrContact = ConvertToRestWithoutDefaults(s.ssENContact, new ENContactEntityRecord(null), ssContactManager.RestRecords.JSONENContactEntityRecord.FromStructureDelegate(config));
			} else {
				AttrContact = ssContactManager.RestRecords.JSONENContactEntityRecord.FromStructure(s.ssENContact, config);
			}
		}

		public static Func<ssContactManager.RestRecords.JSONRCContactRecord, RCContactRecord> ToStructureDelegate(IBehaviorsConfiguration config) {
			return (ssContactManager.RestRecords.JSONRCContactRecord s) => ToStructure(s, config);
		}
		public static RCContactRecord ToStructure(ssContactManager.RestRecords.JSONRCContactRecord obj, IBehaviorsConfiguration config) {
			RCContactRecord s = new RCContactRecord(null);
			if (obj != null) {
				s.ssENContact = ssContactManager.RestRecords.JSONENContactEntityRecord.ToStructure(obj.AttrContact, config);
			}
			return s;
		}

		public static Func<RCContactRecord, ssContactManager.RestRecords.JSONRCContactRecord> FromStructureDelegate(IBehaviorsConfiguration config) {
			return (RCContactRecord s) => FromStructure(s, config);
		}
		public static ssContactManager.RestRecords.JSONRCContactRecord FromStructure(RCContactRecord s, IBehaviorsConfiguration config) {
			return new ssContactManager.RestRecords.JSONRCContactRecord(s, config);
		}

	}



}