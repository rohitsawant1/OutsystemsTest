/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Web;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.WebWidgets {
	[ToolboxData("<{0}:DynamicImage runat=server></{0}:Condition>")]
    public sealed class DynamicImage : ViewStateSpecializations.ViewStateLessImage, IBreakPointControl, IAjaxHandler, IAjaxClickEvent, IGridWidget, IOSControl {

		private string _originalfilename = "";
        private string _staticOriginalfilename = "";
		private DynamicImageType _imageType = DynamicImageType.Static;
		private string _path = "";
        private string _staticPath = "";
		private string _entity = "";
		private string _attribute = "";
		private string _entityId = "";

		public string Source {
			get {
				return _originalfilename;
			}
			set {
				_originalfilename = value;
			}
		}

        public string StaticSource {
            get {
                return _staticOriginalfilename;
            }
            set {
                _staticOriginalfilename = value;
            }
        }

		public DynamicImageType ImageType {
			get {
				return _imageType;
			}
			set {
				_imageType = value;
			}
		}

		public string Entity {
			get {
				return _entity;
			}
			set {
				_entity = value;
			}
		}

		public string Attribute {
			get {
				return _attribute;
			}
			set {
				_attribute = value;
			}
		}


		public string EntityId {
			get {
				return _entityId;
			}
			set {
				_entityId = value;
			}
		}

		public string Path {
			get {
				return _path;
			}
			set {
				_path = value;
			}
		}

        public string StaticPath {
            get {
                return _staticPath;
            }
            set {
                _staticPath = value;
            }
        }

        protected override void OnInit(EventArgs e) {
            base.OnInit(e);
            this.AddGridClassesAttribute();
        }

		/// <summary>
		/// Generate the image in the render methed
		/// Rely on base class for rendering, set the imageurl here so 
		/// that generated ImageURL does not interfere with programatically set imageurl
		/// </summary>
		/// <param name="writer"></param>
		protected override void Render( HtmlTextWriter writer ) {
			if ( _imageType == DynamicImageType.External ) {
				this.ImageUrl = Source;
			} else if ( _imageType == DynamicImageType.Static) {
				this.ImageUrl = CalculateStaticImageUrl();
			} else if ( _imageType == DynamicImageType.Database) {
                if (string.IsNullOrEmpty(EntityId) || EntityId == "0") {
                    this.ImageUrl = CalculateStaticImageUrl();
                } else {
                    this.ImageUrl = CalculateDatabaseImageUrl();
                }
			} else {
				//throw new Exception("Unimplemented dynamic image type");
				throw new HEMessageException(MR.GetMessage(MessageId.UnimplementedImageType));
			}
			base.Render(writer);
		}

		#region Database Image Type Support
		private string CalculateDatabaseImageUrl() {
            return Path + RuntimePlatformUtils.Images.GetDatabaseImagePath(Entity, Attribute, EntityId, Source);
		}
		#endregion

		#region Static Image Type Support
		private string CalculateStaticImageUrl() {
			return StaticPath + StaticSource;
		}
		#endregion

		protected override void AddAttributesToRender( HtmlTextWriter writer ) {
            Utils.RemoveIdIfAnonymous(this, Attributes);

			if ( BorderWidth.IsEmpty ) {
				// base.AddAttributesToRender forces border-width style attribute.
				// Here we want to explicitly ignore it
				string[] exclude = new string[] { HtmlTextWriterAttribute.Border.ToString(), HtmlTextWriterStyle.BorderWidth.ToString() };
				using (HtmlTextWriter w = new HtmlTextWriterWithAttributeFilter(writer, exclude)) {
					base.AddAttributesToRender(w);
				}
			} else {
				string border = BorderWidth.Value.ToString();
				BorderWidth = Unit.Empty;

				if ( Attributes["border"] != null ) {
					border = Attributes["border"].ToString();
					Attributes.Remove("border");
				}
				BorderWidth = Unit.Parse(border);

                AjaxEventsHelper.AddAjaxEventAttribute(this, AjaxEventType.onAjaxClick, ClientID, UniqueID, "__OSVSTATE", Attributes);
				base.AddAttributesToRender(writer);
			}
		}

		private Hashtable events;
		public void RegisterAjaxEvent(AjaxEventType eventType, Array controlIdsToSend) {
			if (events == null) {
				events = new Hashtable();
			}

			events[eventType] = controlIdsToSend;
		}

		public Hashtable GetRegisteredAjaxEvents() {
			return events;
		}

        public string GridCssClasses { get; set; }

		#region IBreakPointControl implementation

		private String _BreakpointHookId;
		private bool _BreakpointHookIsExpressionlessWidget = false;

		public event BreakpointHook BreakpointHookEvent;

		public string BreakpointHookId {
			get { return _BreakpointHookId; }
			set { _BreakpointHookId = value; }
		}

		public bool BreakpointHookIsExpressionlessWidget {
			get { return _BreakpointHookIsExpressionlessWidget; }
			set { _BreakpointHookIsExpressionlessWidget = value; }
		}

		public override void DataBind() {
			if ( BreakpointHookEvent != null ) {					
			    BreakpointHookEvent(BreakpointHookId, BreakpointHookIsExpressionlessWidget);
			}
			base.DataBind();
		}
		
		#endregion

		#region IAjaxClickEvent implementation

		public event EventHandler AjaxClick;

		public void OnAjaxClick(EventArgs e) {
			AjaxEventsHelper.RaiseAjaxEvent(this, AjaxClick);
		}

		#endregion

        #region IOSControl members
        string IOSControl.TagName { get { return this.TagName; } }
        string[] IOSControl.CssClass { get { return this.CssClass.Split(' '); } }
        #endregion
	}
}
