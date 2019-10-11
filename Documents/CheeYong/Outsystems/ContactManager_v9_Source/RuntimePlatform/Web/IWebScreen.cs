/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.ObjectKeys;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.RuntimePlatform.Web {
    public interface IWebScreen : IScreen {
        ObjectKey Key {
            get;
        }

        bool isSecure {
            get;
        }

		LocalState PushStack ();

        void doRefreshScreen(HeContext heContext);

        void doAJAXRefreshScreen(HeContext heContext);

        void OnSubmit(string parentEditRecord, bool validate);

        void CheckPermissions(HeContext heContext);
    }
}