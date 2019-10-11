/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Web.UI;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.RuntimePlatform
{
	/// <summary>
	/// Summary description for INegotiateTabIndexes.
	/// </summary>
	public interface INegotiateTabIndexes
	{
		short NegotiateTabIndexes( short tabindex, bool dumpTabIndex);
		short NegotiateTabIndexesRecursively(short tabindex, Control rootCtrl, bool setTabIndex);
	}
}
