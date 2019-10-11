﻿/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Log;
using OutSystems.HubEdition.RuntimePlatform.Db;
using OutSystems.Internal.Db;
using OutSystems.HubEdition.RuntimePlatform.Email;
using OutSystems.HubEdition.RuntimePlatform.Web;
using OutSystems.HubEdition.RuntimePlatform.NewRuntime;
using OutSystems.RuntimeCommon;
using OutSystems.RuntimeCommon.Caching;
using OutSystems.ObjectKeys;
using System.Resources;

namespace ssContactManager {

	public partial class Actions {
		public class lcvPrivate_List_Navigation_SaveStartIndex: VarsBag {
			public string inParamListWidget;
			public string inParamStartIndex;
			public lcvPrivate_List_Navigation_SaveStartIndex(string inParamListWidget, string inParamStartIndex) {
				this.inParamListWidget = inParamListWidget;
				this.inParamStartIndex = inParamStartIndex;
			}
		}
		/// <summary>
		/// Action <code>ActionPrivate_List_Navigation_SaveStartIndex</code> that represents the Service Studio
		///  user action <code>Private_List_Navigation_SaveStartIndex</code> <p> Description: </p>
		/// </summary>
		public static void ActionPrivate_List_Navigation_SaveStartIndex(HeContext heContext, string inParamListWidget, string inParamStartIndex) {
			lcvPrivate_List_Navigation_SaveStartIndex localVars = new lcvPrivate_List_Navigation_SaveStartIndex(inParamListWidget, inParamStartIndex);
			if (heContext != null && heContext.RequestTracer != null) {
				heContext.RequestTracer.RegisterInternalCall("bIcQm9J0lkmrNyNMOmmreA", "Private_List_Navigation_SaveStartIndex", "X0RMeX3yYU+0eg2nFEDfaA", "ContactManager");
			}
			// Hash Set Session.ListNavigation_StartIndices
			// ListNavigation_StartIndices = Private_HashAdd(ListNavigation_StartIndices, GetPageName() + ":" + ListWidget, StartIndex)
			Global.App.OsContext.Session["ContactManager.ListNavigation_StartIndices"] = Functions.ActionPrivate_HashAdd(heContext, ((string) Global.App.OsContext.Session["ContactManager.ListNavigation_StartIndices"]), ((Functions.rssextensionhttprequesthandler_ActionGetPageName(heContext) + ":") +localVars.inParamListWidget), localVars.inParamStartIndex);
		}

		public static class FuncActionPrivate_List_Navigation_SaveStartIndex {



		}


	}

}