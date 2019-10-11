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
		public class lcvList_Navigation_ResetStartIndex: VarsBag {
			public string inParamListWidget;
			public lcvList_Navigation_ResetStartIndex(string inParamListWidget) {
				this.inParamListWidget = inParamListWidget;
			}
		}
		/// <summary>
		/// Action <code>ActionList_Navigation_ResetStartIndex</code> that represents the Service Studio user
		///  action <code>List_Navigation_ResetStartIndex</code> <p> Description: Clears the session variabl
		/// e used to remember the index of the first row to show in the page.</p>
		/// </summary>
		public static void ActionList_Navigation_ResetStartIndex(HeContext heContext, string inParamListWidget) {
			lcvList_Navigation_ResetStartIndex localVars = new lcvList_Navigation_ResetStartIndex(inParamListWidget);
			if (heContext != null && heContext.RequestTracer != null) {
				heContext.RequestTracer.RegisterInternalCall("inMSGnuBQUWkSL6uZHOrIw", "List_Navigation_ResetStartIndex", "X0RMeX3yYU+0eg2nFEDfaA", "ContactManager");
			}
			// Private_List_Navigation_SaveStartIndex
			Actions.ActionPrivate_List_Navigation_SaveStartIndex(heContext, localVars.inParamListWidget, Convert.ToString(0));

		}

		public static class FuncActionList_Navigation_ResetStartIndex {



		}


	}

}