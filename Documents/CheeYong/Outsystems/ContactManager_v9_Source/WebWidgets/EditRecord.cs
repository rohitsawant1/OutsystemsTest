/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.WebWidgets {
    public sealed class EditRecord : Table, IValidationParent {

        protected override void OnPreRender(EventArgs e) {
            base.OnPreRender(e);
            foreach (HtmlTableRow row in Rows) {
                for (int i = 0; i < row.Cells.Count - 1; i = i + 2) {
                    // caption on left, input on right
                    HtmlTableCell captionCell = row.Cells[i];
                    if (captionCell.ColSpan == 2) {
                        i--;
                        continue;
                    }
                    
                    HtmlTableCell inputCell = row.Cells[i + 1];
                    if (HasMandatoryInput(inputCell)) {
                        AddCssClass(captionCell, "MandatoryCaption");
                        AddCssClass(inputCell, "MandatoryValue");
                        continue;
                    }

                    // caption on right, input on left
                    captionCell = row.Cells[i + 1];
                    inputCell = row.Cells[i];
                    if (HasMandatoryInput(inputCell)) {
                        AddCssClass(captionCell, "MandatoryCaption");
                        AddCssClass(inputCell, "MandatoryValue");
                    }
                }
            }
        }

        private static bool HasMandatoryInput(Control outer_control) {
            foreach (Control control in outer_control.Controls) {
                TextBox textBox = control as TextBox;
                if (textBox != null && textBox.Mandatory) {
                    return true;
                }

                DropDownList dropDown = control as DropDownList;
                if (dropDown != null && dropDown.Mandatory) {
                    return true;
                }
                
                if (HasMandatoryInput(control)) {
                    return true;
                }
            }
            return false;
        }

        private static void AddCssClass(HtmlControl control, string cssClass) {
            string previousCssClass = control.Attributes[HtmlTextWriterAttribute.Class.ToString()];
            if (previousCssClass == null || previousCssClass == string.Empty) {
                control.Attributes[HtmlTextWriterAttribute.Class.ToString()] = cssClass;
            } else if (!previousCssClass.Contains(" " + cssClass)) {
                control.Attributes[HtmlTextWriterAttribute.Class.ToString()] = previousCssClass + " " + cssClass;
            }
        }
    }
}
