/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.Web.UI;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.WidgetsRuntimeAPI;

namespace OutSystems.Plugin.Widgets {

    public partial class Form : IControlWithValidation, IValidationParent {

        // TODO JMN generate 
        public bool Valid() {
            return Validate(Owner);
        }

        private bool Validate(Control control) {
            if (control != Owner) {
                var controlWithValidation = control as IControlWithValidation;
                if (controlWithValidation != null && !controlWithValidation.Validate(this.GetSreenContext())) {
                    return false;
                }
            }
            foreach (Control child in control.Controls) {
                if (!Validate(child)) {
                    return false;
                }
            }
            return true;
        }

        bool IControlWithValidation.Validate(ScreenContext context) {
            return Validate(Owner);
        }

        public string GetReadOnlyClass() {
            return IsEditable() ? "" : " ReadOnly";
        }
    }
}
