/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;

namespace OutSystems.HubEdition.RuntimePlatform.Callbacks {
    public enum CallbackEvent {
        Unknown,

        ApplicationStart,
        InvalidateCache,
        PageRender,
        Login,
        Logout,
        SessionStart,
        ChangeLocale,
        GetHtmlForUser,
    }

    public static class CallbackEventUtils {
        public static bool AffectsApplication(this CallbackEvent evt) {
            return evt == CallbackEvent.ApplicationStart ||
                evt == CallbackEvent.InvalidateCache;
        }

        public static bool AffectsSession(this CallbackEvent evt) {
            return evt == CallbackEvent.Login ||
                evt == CallbackEvent.Logout ||
                evt == CallbackEvent.SessionStart ||
                evt == CallbackEvent.ChangeLocale;
        }

        public static bool AffectsNothing(this CallbackEvent evt) {
            return evt == CallbackEvent.PageRender;
        }
    }
}