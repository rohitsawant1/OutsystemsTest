/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.WebWidgets {
	public enum AjaxEventType {
		onAjaxClick,
		onAjaxChange,
        onAjaxNotify
	}
	
	public interface IAjaxHandler {
		void RegisterAjaxEvent( AjaxEventType eventType, Array controlIdsToSend );
		Hashtable GetRegisteredAjaxEvents();
	}
}
