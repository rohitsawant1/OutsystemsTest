/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using System.Web.UI;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.WebWidgets {

	/// <summary>
	/// HtmlTextWriter that implements a filter in the AddAttribute method to overwrite attributes added more than once
	/// </summary>
	public sealed class HtmlTextWriterWithAttributeFilter : HtmlTextWriter, IDisposable {

        #region IAddAttributeCommand and implementations
        private interface IAddAttributeCommand {
            string AttributeName { get; }
			void AddAttribute(HtmlTextWriter writer);
		}

		private class AddAttributeStringString : IAddAttributeCommand {
			private string _name;
			private string _value;

			public AddAttributeStringString(string name, string value) {
				_name = name;
				_value = value;
			}

            public string AttributeName { get { return _name; } }

			public void AddAttribute(HtmlTextWriter writer) {
				writer.AddAttribute(_name, _value);
			}
		}
		
		private class AddAttributeKeyString : IAddAttributeCommand {
			private HtmlTextWriterAttribute _key;
			private string _value;

			public AddAttributeKeyString(HtmlTextWriterAttribute key, string value) {
				_key = key;
				_value = value;
			}

            public string AttributeName { get { return _key.ToString(); } }

			public void AddAttribute(HtmlTextWriter writer) {
				writer.AddAttribute(_key, _value);
			}
		}

		private class AddAttributeStringStringBoolean : IAddAttributeCommand {
			private string _name;
			private string _value;
			private bool _fEncode;

			public AddAttributeStringStringBoolean(string name, string value, bool fEncode) {
				_name = name;
				_value = value;
				_fEncode = fEncode;
			}

            public string AttributeName { get { return _name; } }

			public void AddAttribute(HtmlTextWriter writer) {
				writer.AddAttribute(_name, _value, _fEncode);
			}
		}

		private class AddAttributeKeyStringBoolean : IAddAttributeCommand {
			private HtmlTextWriterAttribute _key;
			private string _value;
			private bool _fEncode;

			public AddAttributeKeyStringBoolean(HtmlTextWriterAttribute key, string value, bool fEncode) {
				_key = key;
				_value = value;
				_fEncode = fEncode;
			}

            public string AttributeName { get { return _key.ToString(); } }

			public void AddAttribute(HtmlTextWriter writer) {
				writer.AddAttribute(_key, _value, _fEncode);
			}
        }

        private class AddStyleAttributeStringString : IAddAttributeCommand {
            private string _name;
            private string _value;

            public AddStyleAttributeStringString(string name, string value) {
                _name = name;
                _value = value;
            }

            public string AttributeName {
                get { return _name; }
            }

            public void AddAttribute(HtmlTextWriter writer) {
                writer.AddStyleAttribute(_name, _value);
            }
        }

        private class AddStyleAttributeKeyString : IAddAttributeCommand {
            private HtmlTextWriterStyle _key;
            private string _value;

            public AddStyleAttributeKeyString(HtmlTextWriterStyle key, string value) {
                _key = key;
                _value = value;
            }

            public string AttributeName {
                get { return _key.ToString(); }
            }

            public void AddAttribute(HtmlTextWriter writer) {
                writer.AddStyleAttribute(_key, _value);
            }
        }

        #endregion



        private HtmlTextWriter _innerWriter;

        private IEnumerable<string> _exclusion;

		private IList<IAddAttributeCommand> _attributesList = new List<IAddAttributeCommand>();
		private IDictionary<string, int> _attributes = new Dictionary<string, int>();


        public HtmlTextWriterWithAttributeFilter(HtmlTextWriter writer) : this(writer, EmptyArray<string>.Instance) {
        }

		public HtmlTextWriterWithAttributeFilter(HtmlTextWriter writer, IEnumerable<string> attributeExclusionList) : base(writer) {
			_innerWriter = writer;
            _exclusion = attributeExclusionList;
		}

		private void AddAttributeCommand(string name, IAddAttributeCommand cmd) {
            int prevIndex;
			if (_attributes.TryGetValue(name, out prevIndex)) {
				// this attribute has already been added
				// overwrite the previous command
				_attributesList[prevIndex] = cmd;
			} else {
				// this is a new attribute
                // add to the end of the list
				_attributesList.Add(cmd);
				_attributes[name] = _attributesList.Count - 1;
			}
        }

        #region Façade for API
        public override void AddAttribute(string name, string value) {
			AddAttributeCommand(name.ToLower(), new AddAttributeStringString(name, value));
		}

		public override void AddAttribute(HtmlTextWriterAttribute key, string value) {
			AddAttributeCommand(key.ToString().ToLower(), new AddAttributeKeyString(key, value));
		}

		public override void AddAttribute(string name, string value, bool fEncode) {
			AddAttributeCommand(name.ToLower(), new AddAttributeStringStringBoolean(name, value, fEncode));
		}
		
		public override void AddAttribute(HtmlTextWriterAttribute key, string value, bool fEncode) {
			AddAttributeCommand(key.ToString().ToLower(), new AddAttributeKeyStringBoolean(key, value, fEncode));
		}

        public override void AddStyleAttribute(HtmlTextWriterStyle key, string value) {
            AddAttributeCommand(key.ToString().ToLower(), new AddStyleAttributeKeyString(key, value));;
        }

        public override void AddStyleAttribute(string name, string value) {
            AddAttributeCommand(name.ToLower(), new AddStyleAttributeStringString(name, value));
        }

        protected override void AddAttribute(string name, string value, HtmlTextWriterAttribute key) {
            throw new InvalidOperationException();
        }

        protected override void AddStyleAttribute(string name, string value, HtmlTextWriterStyle key) {
            throw new InvalidOperationException();
        }
        #endregion


        /// <summary>
		/// Flushes the current writer to the inner HtmlTextWriter
		/// </summary>
        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
            foreach (var cmd in _attributesList) {
                bool any = false;
                foreach (var attr in _exclusion) {
                    if (attr.Equals(cmd.AttributeName, StringComparison.OrdinalIgnoreCase)) {
                        any = true;
                        break;
                    }
                }
                if (!any) {
                    cmd.AddAttribute(_innerWriter);
                }
            }
        }
	}
}
