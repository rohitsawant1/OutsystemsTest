/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.RuntimeCommon;
using System.Web.UI;
using OutSystems.HubEdition.RuntimePlatform.Web;

namespace OutSystems.HubEdition.WebWidgets {
    public sealed class Body : ViewStateSpecializations.ViewStateLessHtmlGenericControl, IOSControl {

        public Body() : base("body") { }
        public Body(string tagName) : base("body") { }
        
        protected override void Render( HtmlTextWriter writer ) {
			RenderBeginTag(writer);
			RenderChildren(writer);
			RenderEndTag(writer);
		}

        // Fix for stackoverflow on exceptions during DataBind
        protected override void DataBindChildren() {
            if (!this.HasControls())
                return;

            int count = this.Controls.Count;
            for (int index = 0; index < count; ++index)
                this.Controls[index].DataBind();
        }

        #region IOSControl members
        string[] IOSControl.CssClass { get { return (this.Attributes["class"] ?? string.Empty).Split(' '); }}
        #endregion
    }
}
