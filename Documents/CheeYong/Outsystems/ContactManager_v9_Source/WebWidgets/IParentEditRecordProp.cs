/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Web.UI;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Web;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.WebWidgets
{
    public enum ParentEditRecordPropType {
        NEEDS_VALIDATION,
        PERFORMS_VALIDATION,
        AGGREGATOR
    }

	/// <summary>
	/// Summary description for IParentEditRecord.
	/// </summary>	
	public interface IParentEditRecordProp
	{
		string ParentEditRecord {
			get;
			set;
		}
		
		ParentEditRecordPropType ValidatorType { get; }
        Control Parent { get; }
	}

    public static class ParentEditRecordPropUtils {   
        private static Control GetParentEditRecord(IParentEditRecordProp control) {
            string parentEditRecord = control.ParentEditRecord;
            if (parentEditRecord.IsEmpty()) {
                return GetParentValidationWidget(control);
            }

            // if the control is inside a block, check if it is using the special "declared in page"
            // edit record
            Control ownerControl;
            if (control is OSUserControl) {
                ownerControl = Utils.GetOwnerOfControl(control.Parent);
            } else {
                ownerControl = Utils.GetOwnerOfControl((Control)control);
            }
            OSUserControl block = ownerControl as OSUserControl;
            if (block != null && parentEditRecord == RuntimePlatformUtils.EditRecordDefinedInParentScreen) {
                return GetParentEditRecord(block);  
            }

            return ownerControl.FindControl(parentEditRecord);
        }
        
        private static Control GetParentValidationWidget(IParentEditRecordProp control) {
            var widget = control.Parent;
            while (widget != null) {
                var widgetWithBehaviors = widget as IWidgetWithBehaviors;
                if (widgetWithBehaviors != null && widgetWithBehaviors.BehavesAs<OutSystems.WidgetsRuntimeAPI.IControlWithValidation>()) {
                    break;
                }
                widget = widget.Parent;
            }
            return widget;
        }

        public static Control GetValidationParentWidget(this IParentEditRecordProp control) {
            var widget = control.Parent;
            while (widget != null) {
                var widgetWithBehaviors = widget as IWidgetWithBehaviors;
                if (widgetWithBehaviors != null &&
                        widgetWithBehaviors.BehavesAs<OutSystems.HubEdition.RuntimePlatform.IValidationParent>()) {
                    break;
                }
                widget = widget.Parent;
            }
            return widget;
        }

        public static string GetParentEditRecordClientId(this IParentEditRecordProp component) {
            Control parentEditRecord = GetParentEditRecord(component);

            if (parentEditRecord == null) {
                return String.Empty;
            } else {
                return parentEditRecord.ClientID;
            }
        }

        public static void VisitComponent(JavaScriptManager scriptManager, IParentEditRecordProp component, 
                bool componentIsVisible, Func<string> componentClientID) {

            if (component != null) {
				string parentEditRecordId = component.GetParentEditRecordClientId();

				// #99202 - its safe to add the input controls to this list even if they are not rendered,
				// since the OSPage_Validators variable controls the validation and is not including 
				// the invisible validators. This simplifies the case when an invisible input appears 
				// in the page via an Ajax refresh. 
                // However for buttons with validation we must skip the invisible ones, otherwise the
                // startup scripts to set the "elementsToValidate" attribute will fail since the element does not exist.
                // When hidden buttons appear in the page via Ajax refresh their elementsToValidate are updated automatically
                // (refer to "private void AddJavascriptIfNeeded()" in "Button.cs")
				if ((parentEditRecordId != null) && (parentEditRecordId != "")) {	
                    switch (component.ValidatorType) {
                    case ParentEditRecordPropType.AGGREGATOR:
                        break;
                    case ParentEditRecordPropType.NEEDS_VALIDATION:
                        scriptManager.addIdToParentEditRecord(componentClientID(), parentEditRecordId);
                        break;
                    case ParentEditRecordPropType.PERFORMS_VALIDATION:
                        // Only add the control to the script if it was rendered (it was visible) - #38772
                        scriptManager.addValidatorToParentEditRecord(componentClientID(), parentEditRecordId, componentIsVisible);
                        break;
                    }
				}
			}
        }
    }
}
