/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.RuntimeCommon;
using OutSystems.WidgetsRuntimeAPI;

namespace OutSystems.HubEdition.WebWidgets.Behaviors {
    public class RepeaterBehavior : WidgetBehavior {

        private readonly Func<Iterator> getIterator;

        public RepeaterBehavior(Func<Iterator> getIterator) {
            this.getIterator = getIterator;
        }

        public override void OnPostback() {
            int index;
            int.TryParse(BuiltInFunction.NotifyWidgetGetMessage(), out index);
            var iterator = (IRepeaterControl) getIterator();
            if (iterator != null) {
                iterator.CurrentIndex = index;
            }
        }

        public override void OnLoad() {
            base.OnLoad();
            var iterator = getIterator();
            iterator.EnsureChildControlsOnPostback();
        }
    }
}
