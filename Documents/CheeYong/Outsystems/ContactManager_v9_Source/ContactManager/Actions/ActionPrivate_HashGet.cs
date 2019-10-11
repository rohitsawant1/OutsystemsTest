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
		public class lcvPrivate_HashGet: VarsBag {
			public string inParamHash;
			public string inParamKey;
			/// <summary>
			/// Variable <code>varLcIndex</code> that represents the Service Studio local variable
			///  <code>Index</code> <p>Description: </p>
			/// </summary>
			public int varLcIndex = 0;

			/// <summary>
			/// Variable <code>varLctmp</code> that represents the Service Studio local variable <code>tmp</code>
			///  <p>Description: </p>
			/// </summary>
			public string varLctmp = "";

			public lcvPrivate_HashGet(string inParamHash, string inParamKey) {
				this.inParamHash = inParamHash;
				this.inParamKey = inParamKey;
			}
		}
		public class lcoPrivate_HashGet: VarsBag {
			public string outParamValue = "";

			public lcoPrivate_HashGet() {
			}
		}
		/// <summary>
		/// Action <code>ActionPrivate_HashGet</code> that represents the Service Studio user action
		///  <code>Private_HashGet</code> <p> Description: </p>
		/// </summary>
		public static void ActionPrivate_HashGet(HeContext heContext, string inParamHash, string inParamKey, out string outParamValue) {
			lcoPrivate_HashGet result = new lcoPrivate_HashGet();
			lcvPrivate_HashGet localVars = new lcvPrivate_HashGet(inParamHash, inParamKey);
			if (heContext != null && heContext.RequestTracer != null) {
				heContext.RequestTracer.RegisterInternalCall("iDMk1w28PUC8Sv34YvikpQ", "Private_HashGet", "X0RMeX3yYU+0eg2nFEDfaA", "ContactManager");
			}
			try {
				// List_Key
				// Index = Index
				localVars.varLcIndex = BuiltInFunction.IndexSC(localVars.inParamHash, localVars.inParamKey, 0, false, false);
				// Found Key?
				if (((localVars.varLcIndex!=(-1)))) {
					// SetValue
					// tmp = Substr
					localVars.varLctmp = BuiltInFunction.SubstrSC(localVars.inParamHash, ((localVars.varLcIndex+BuiltInFunction.LengthSC(localVars.inParamKey)) +1), (BuiltInFunction.LengthSC(localVars.inParamHash) -BuiltInFunction.LengthSC(localVars.inParamKey)));
					// Value = Substr
					result.outParamValue = BuiltInFunction.SubstrSC(localVars.varLctmp, 0, BuiltInFunction.IndexSC(localVars.varLctmp, ";", 0, false, false));
				}

			} // try

			finally {
				outParamValue = result.outParamValue;
			}
		}

		public static class FuncActionPrivate_HashGet {



		}


	}

}