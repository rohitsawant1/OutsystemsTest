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
		/// <summary>
		/// Action <code>ActionRegex_Search</code> that represents the Service Studio reference action
		///  <code>Regex_Search</code> <p> Description: Searches the input string for an occurrence of a regula
		/// r expression.</p>
		/// </summary>
		public static void ActionRegex_Search(HeContext heContext, string inParamText, string inParamPattern, bool inParamIgnoreCase, bool inParamMultiLine, bool inParamSingleLine, out bool outParamFound, out string outParamPatternResult, out int outParamFirstIndex) {
			RssExtensionText.MssRegex_Search(heContext, inParamText, inParamPattern, inParamIgnoreCase, inParamMultiLine, inParamSingleLine, out outParamFound, out outParamPatternResult, out outParamFirstIndex);
		}

	}

}