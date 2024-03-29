/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using OutSystems.RuntimeCommon;
using OutSystems.HubEdition.RuntimePlatform.Web;

namespace OutSystems.HubEdition.WebWidgets {
    public class OSDataGridItem : ViewStateSpecializations.ViewStateLessDataGridItem, IOSControl {

        public OSDataGridItem(int itemIndex, int dataSetIndex, ListItemType itemType) : base(itemIndex, dataSetIndex, itemType) {
        }

        private bool _isEmptyMessageItem = false;
        public bool IsEmptyMessageItem {
            get {
                return _isEmptyMessageItem;
            }
            set {
                _isEmptyMessageItem = value;
            }
        }

        public void PrepareRendering() {
            // Hide dummy column from non empty items, otherwise rendering of a single row will have an extra column
            if (!_isEmptyMessageItem) {
                Controls[Controls.Count - 1].Visible = false;
            }
        }

        protected override void Render(HtmlTextWriter writer) {
            PrepareRendering();
            base.Render(writer);
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer) {
            // add all attributes, excluding the id attribute
            using (var w = new HtmlTextWriterWithAttributeFilter(writer, new[] { "id" })) {
                base.AddAttributesToRender(w);
            }
        }

        public static string FormatId(int id, bool enableLegacyRendering) {
            if (enableLegacyRendering)
                return "_ctl" + id.ToString();
            else
                return "ctl" + ((id < 10) ? "0" + id.ToString() : id.ToString());
        }

        public static int GetIntegerId(string itemId, bool enableLegacyRendering) {
            if (enableLegacyRendering)
                return Int32.Parse(itemId.Substring(4));
            else
                return Int32.Parse(itemId.Substring(3));
        }

        private int _itemIndex = -1;
        public void SetItemIndex(int index) {
            _itemIndex = index;
        }

        public override int ItemIndex {
            get {
                if (_itemIndex == -1)
                    return base.ItemIndex;
                else
                    return _itemIndex;
            }
        }

        public override int DataSetIndex {
            get {
                if (_itemIndex == -1)
                    return base.DataSetIndex;
                else
                    return _itemIndex;
            }
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
        string IOSControl.TagName { get { return this.TagName; } }
        string[] IOSControl.CssClass { get { return this.CssClass.Split(' '); } }
        #endregion
    }
}