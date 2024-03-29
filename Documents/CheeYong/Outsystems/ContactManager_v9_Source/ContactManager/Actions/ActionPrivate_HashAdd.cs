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
		public class lcvPrivate_HashAdd: VarsBag {
			public string inParamHash;
			public string inParamKey;
			public string inParamValue;
			/// <summary>
			/// Variable <code>varLcIndex</code> that represents the Service Studio local variable
			///  <code>Index</code> <p>Description: </p>
			/// </summary>
			public int varLcIndex = 0;

			/// <summary>
			/// Variable <code>varLcPrefix</code> that represents the Service Studio local variable
			///  <code>Prefix</code> <p>Description: </p>
			/// </summary>
			public string varLcPrefix = "";

			/// <summary>
			/// Variable <code>varLcSuffix</code> that represents the Service Studio local variable
			///  <code>Suffix</code> <p>Description: </p>
			/// </summary>
			public string varLcSuffix = "";

			public lcvPrivate_HashAdd(string inParamHash, string inParamKey, string inParamValue) {
				this.inParamHash = inParamHash;
				this.inParamKey = inParamKey;
				this.inParamValue = inParamValue;
			}
		}
		public class lcoPrivate_HashAdd: VarsBag {
			public string outParamNewHash = "";

			public lcoPrivate_HashAdd() {
			}
		}
		/// <summary>
		/// Action <code>ActionPrivate_HashAdd</code> that represents the Service Studio user action
		///  <code>Private_HashAdd</code> <p> Description: </p>
		/// </summary>
		public static void ActionPrivate_HashAdd(HeContext heContext, string inParamHash, string inParamKey, string inParamValue, out string outParamNewHash) {
			lcoPrivate_HashAdd result = new lcoPrivate_HashAdd();
			lcvPrivate_HashAdd localVars = new lcvPrivate_HashAdd(inParamHash, inParamKey, inParamValue);
			if (heContext != null && heContext.RequestTracer != null) {
				heContext.RequestTracer.RegisterInternalCall("wgfzUbyGoU2pz4dHanoeJg", "Private_HashAdd", "X0RMeX3yYU+0eg2nFEDfaA", "ContactManager");
			}
			try {
				// Index
				// Index = Index
				localVars.varLcIndex = BuiltInFunction.IndexSC(localVars.inParamHash, localVars.inParamKey, 0, false, false);
				// Found Key?
				if (((localVars.varLcIndex!=(-1)))) {
					// Update
					// Prefix = Substr
					localVars.varLcPrefix = BuiltInFunction.SubstrSC(localVars.inParamHash, 0, localVars.varLcIndex);
					// Suffix = Substr
					localVars.varLcSuffix = BuiltInFunction.SubstrSC(localVars.inParamHash, ((localVars.varLcIndex+BuiltInFunction.LengthSC(localVars.inParamKey)) +1), ((BuiltInFunction.LengthSC(localVars.inParamHash) -localVars.varLcIndex) -BuiltInFunction.LengthSC(localVars.inParamKey)));
					// Suffix = Substr
					localVars.varLcSuffix = BuiltInFunction.SubstrSC(localVars.varLcSuffix, (BuiltInFunction.IndexSC(localVars.varLcSuffix, ";", 0, false, false) +1), (BuiltInFunction.LengthSC(localVars.varLcSuffix) -BuiltInFunction.IndexSC(localVars.varLcSuffix, ";", 0, false, false)));
				} else {
					// Append
					// Prefix = Hash
					localVars.varLcPrefix = localVars.inParamHash;
					// Suffix = ""
					localVars.varLcSuffix = "";
				}

				// Update Session
				// NewHash = Prefix + Key + "=" + Value + ";" + Suffix
				result.outParamNewHash = (((((localVars.varLcPrefix+localVars.inParamKey) + "=") +localVars.inParamValue) + ";") +localVars.varLcSuffix);
			} // try

			finally {
				outParamNewHash = result.outParamNewHash;
			}
		}

		public static class FuncActionPrivate_HashAdd {



		}


	}

}