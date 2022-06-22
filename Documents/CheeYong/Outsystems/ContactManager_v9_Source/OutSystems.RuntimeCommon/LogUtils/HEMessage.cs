/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Linq;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Security;
using System.Text;
using System.Xml;
using System.Collections.Generic;

namespace OutSystems.RuntimeCommon {
	/// <summary>
	/// Maintains all the messages generated by the compiler
	/// </summary>
	[Flags, Serializable()]
	public enum HEMessageType {
		Info = 0x01,
		Warning = 0x02,
		Error = 0x4,
		DevWarn = 0x08,
        OK = 0x10,
        Question = 0x20,
        StepX = 0x40,
        StepSub = 0x80
    };  // add new levels? several errors levels, etc.

    [Serializable()]
	public class HEMessage: IMessageObject {
		public string Id;
		public string Message;
		public string Detail;
		public int HelpRef;
		public string ExtraInfo;
		public HEMessageType Type;
		public bool Submitable;

        string IMessageObject.Id => Id;
        MessageType IMessageObject.Type => Type.ToMessageType();
        string IMessageObject.Message => Message;
        string IMessageObject.Detail => Detail;

        string IMessageObject.ExtraInfo => ExtraInfo;
        int IMessageObject.HelpRef => HelpRef;

        // Old API
        public HEMessage(HEMessageType type, string message, string detail, string module) {
			Id = "";
			Message = message;
			Detail = detail;
			HelpRef = 0;
			if (module != null) {
				ExtraInfo = "Module : " + module;
			}
			Type = type;
			Submitable = true;
		}

		public HEMessage(string id, string message, string detail, int helpRef, string extraInfo, HEMessageType type, bool submitable) {
			Id = id;
			Message = message;
			Detail = detail;
			HelpRef = helpRef;
			ExtraInfo = extraInfo;
			Type = type;
			Submitable = submitable;
		}
        
		public HEMessage(XmlElement element) {
			if (element != null) {
				Load(element);
			}
		}

		public HEMessage() {
			Id = "";
			Message = "";
			Detail = "";
			HelpRef = 0;
			ExtraInfo = "";
			Type = HEMessageType.Error;
			Submitable = true;
		}

		private void Load(XmlElement elem) {
			if (elem == null) return;
			Id = GetAttributeValue(elem, "Id");
			Message = GetAttributeValue(elem, "Message");
			Detail = GetAttributeValue(elem, "Detail");
			Type = (HEMessageType)Enum.Parse( typeof(HEMessageType), GetAttributeValue(elem, "Type"), true);
			string ot = GetAttributeValue(elem, "Submitable");
			if (ot != null) ot = ot.ToLower();
			if ((ot == "true") || (ot == "yes")) {
				Submitable = true;
			} else if ((ot == "false") || (ot == "no")) {
				Submitable = false;
			}
			try {
				HelpRef = int.Parse(GetAttributeValue(elem, "HelpRef"), CultureInfo.InvariantCulture);
			} catch {
				HelpRef = 0;
			}
			try {
				ExtraInfo = GetAttributeValue(elem, "ExtraInfo");
			} catch {
				ExtraInfo = null;
			}
		}

		public void Save(XmlElement elm) {
			XmlAttribute attr;
			XmlDocument xmldoc = elm.OwnerDocument;
			attr = xmldoc.CreateAttribute("Id");
			if (Id == null) { attr.Value = ""; } else {
				attr.Value = Id.ToString();
			}
			elm.Attributes.Append(attr);

			attr = xmldoc.CreateAttribute( "Message" );
			if (Message == null) { attr.Value = ""; } else {
				attr.Value = Message.ToString();
			}
			elm.Attributes.Append(attr);

			attr = xmldoc.CreateAttribute( "Detail" );
			if (Detail == null) { attr.Value = ""; } else {
				attr.Value = Detail.ToString();
			}
			elm.Attributes.Append(attr);

			attr = xmldoc.CreateAttribute( "Type" );
			attr.Value = Type.ToString();
			elm.Attributes.Append(attr);

			attr = xmldoc.CreateAttribute("Submitable");
			if (Id == null) { attr.Value = ""; } else {
				if (Submitable) {
					attr.Value = "Yes";
				} else {
					attr.Value = "No";
				}
			}
			elm.Attributes.Append(attr);

			if (HelpRef != 0) {
				attr = xmldoc.CreateAttribute("HelpRef");
				attr.Value = HelpRef.ToString();
				elm.Attributes.Append(attr);
			}

			if ((ExtraInfo != null) && (ExtraInfo.Length > 0)) {
				attr = xmldoc.CreateAttribute( "ExtraInfo" );
				attr.Value = ExtraInfo.ToString();
				elm.Attributes.Append(attr);
			}
		}

		protected string GetAttributeValue(XmlElement elem, string attribute) {
			if (elem.Attributes[attribute] == null)
				return null;
			else
				return elem.Attributes[attribute].Value;
		}

		public override string ToString() {
			string s = "";
			s += "Id : " + Id + "\r\n";
			s += "Type : " + Type.ToString() + "\r\n";
			if (Message != null) {
				s += "Message : " + Message + "\r\n";
			}
			if (Detail != null) {
				s += "Detail : " + Detail + "\r\n";
			}
			s += "HelpRef : " + HelpRef.ToString() + "\r\n";
			if (ExtraInfo != null) {
				s += "ExtraInfo : " + ExtraInfo + "\r\n";
			}
			s += "Submitable : " + (Submitable ? "Yes" : "No") + "\r\n";
			return s;
		}

        public HEMessage(IMessageObject message) {
            Id = message.Id;
            Message = message.Message;
            Detail = message.Detail;
            Type = message.Type.ToHEMessageType();
            ExtraInfo = message.ExtraInfo;
            HelpRef = message.HelpRef;
        }

        public static HEMessageType GetTypeFromString(string type) {
            switch (type.ToLowerInvariant()) {
            case "info":
                return HEMessageType.Info;
            case "warning":
                return HEMessageType.Warning;
            case "error":
                return HEMessageType.Error;
            case "devwarn":
                return HEMessageType.DevWarn;
            case "question":
                return HEMessageType.Question;
            default:
                return HEMessageType.OK;
            }
        }
	}

	[Serializable()]
	public class HEMessageArrayList : ArrayList {
        private bool isReadOnly;

		public HEMessageArrayList() {}

		// For now we need this constructor from XML...
		public HEMessageArrayList( string xml ) : base() {
			try {
				XmlDocument doc = new XmlDocument();
				doc.LoadXml(xml);

				foreach (XmlElement elem in doc.SelectNodes("//Msg")) {
					HEMessage msg = new HEMessage(elem);
					this.Add( msg );
				}
			} catch (Exception ex) {
				throw new IOException("Error loading message list\r\nOriginal Xml : "+xml+"\r\nException : " + ex.ToString(), ex);
			}
		}

        public HEMessageArrayList(params HEMessage[] messages) {
            foreach (var message in messages) {
                Add(message);
            }
        }

		public new HEMessage this[int index] {
			get {
				return (HEMessage)(base[index]);
			}
			
			set {
				base[index] = value;
			}
		}

        public void SetReadOnly(bool value) {
            isReadOnly = value;
        }

		public override int Add(object val) {
            throw new ArgumentException("HEMessageArrayList only stores HEMessage objects");
		}

		public int Add( HEMessage val ) {
            if (isReadOnly) {
                throw new InvalidOperationException("Cannot add messages to the list because it is read-only");
            } else {
                return base.Add(val);
            }
		}

        public void AddRange(IEnumerable<IMessageObject> messages) {
            messages.Select(msg => new HEMessage(msg)).Apply(msg => Add(msg));
        }

        public bool Contains(string messageId) {
            foreach (HEMessage msg in this) {
                if (msg.Id.Equals(messageId)) {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<HEMessage> ToHEMessageEnumerable() {
            return this.Cast<HEMessage>();
        }

        private IEnumerable<HEMessage> Where(HEMessageType type) {
            return this.Where(msg => (msg.Type & type) == type);
        }

        private IEnumerable<HEMessage> Where(Func<HEMessage, bool> predicate) {
            return this.Cast<HEMessage>().Where(predicate);
        }

        public HEMessageArrayList Filter(HEMessageType type) {
			HEMessageArrayList filtered = new HEMessageArrayList();
            this.Where(type).Apply(msg => filtered.Add(msg));
			return filtered;
		}        

        public bool HasErrors() {
            return this.Where(HEMessageType.Error).Any();
        }

        public string SerializeToXML() {
			XmlDocument xmldoc=new XmlDocument();
    		XmlElement msgElm;
			
			xmldoc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><Msgs/>");

			foreach (HEMessage msg in this) {
				msgElm = xmldoc.CreateElement( "Msg" );
				xmldoc.DocumentElement.AppendChild( msgElm );

				msg.Save(msgElm);
			}

			return xmldoc.OuterXml;
		}

		public override string ToString() {
			StringBuilder sb = new StringBuilder();
			
			foreach (HEMessage msg in this) {
				sb.Append(string.Format("{0}: {1}\n", msg.Message, msg.Detail));
            }
						
			return sb.ToString();
		}

        /// <summary>
        /// It creates a new HEMessageArrayList with the same elements
        /// </summary>
        /// <returns>
        /// A HEMessageList converted to object
        /// </returns>
        public override object Clone() {
            HEMessageArrayList res = new HEMessageArrayList();

            foreach (HEMessage msg in this) {
                res.Add(msg);
            }

            return res;
        }
	}

    public static class HEMessageArrayListExtensions {
        public static HEMessageArrayList CloneIfNotNull(this HEMessageArrayList list) {
            return (HEMessageArrayList)list?.Clone();
        }
    }

	[Serializable()]
	public class HEMessageException : Exception 
	{
		public HEMessage @HEMessage;

		private static string getStackStraceExceptTop(int n)
        {
            StackTrace st = new StackTrace(n, true);
            return st.ToString().Replace("\t", "   ").Trim();      
        }

        protected HEMessageException(HEMessage message, Exception innerException, int extraStack, bool supressStack, bool startWithInnerException)
            : base(message.Message + (string.IsNullOrEmpty(message.Detail) ? "" : ": " + message.Detail), innerException) {
            
            StringBuilder sb = new StringBuilder(message.ExtraInfo);

            if (message.ExtraInfo != "") {
                sb.Append("\r\n"); 
            }

            if (!supressStack) {
                var cnt = 1;
                sb.Append("Exception Details:\r\n"); 
                if(!startWithInnerException) {
                    sb.Append("[1] {0}{1}\r\n{2}\r\n".F(message.Message, (string.IsNullOrEmpty(message.Detail) ? "" : ": " + message.Detail), getStackStraceExceptTop(2 + extraStack))); 
                    cnt = 2;
                }

                if (innerException != null) {
                    Exception ex = innerException;
                    while (ex != null) {
                        string stack = GetProperStackInfo(ex);
                        sb.Append("[{0}] {1}".F(cnt, stack)); 
                        ex = ex.InnerException;
                        cnt++;
                    }
                }
            }
	        message.ExtraInfo = sb.ToString();
            @HEMessage = message;
        }

	    private string GetProperStackInfo(Exception ex) {
            return ex.ToString();
	    }

        public HEMessageException(HEMessage message, Exception innerException)
            : this(message, innerException, 1, /* supressStack */ false) {
        }

        public HEMessageException(HEMessage message, Exception innerException, bool startWithInnerException)
            : this(message, innerException, 1, /* supressStack */ false, startWithInnerException) {
        }

        public HEMessageException(HEMessage message, bool supressStack)
            : this(message, /* innerException */ null, 1, supressStack) {
        }

        public HEMessageException(HEMessage message)
            : this(message, /* supressStack */ false) {
        }

	    protected HEMessageException(HEMessage message, Exception innerException, int extraStack, bool supressStack)
            : this(message, innerException, extraStack, supressStack, /* startWithInnerException */ false) {
	    }
 
        [SecurityCritical]
        public HEMessageException(SerializationInfo info, StreamingContext context) 
		    : base(info, context) {
			@HEMessage = (@HEMessage)info.GetValue("HEMessage", typeof(HEMessage));
		}

        [SecurityCritical]
        public override void GetObjectData(SerializationInfo info, StreamingContext context) {
			base.GetObjectData(info, context);
			info.AddValue("HEMessage", @HEMessage);
		}

		public override string ToString() {
			return @HEMessage.ToString();
		}
	}

	[Serializable()]
	public class HENotImplementedException : HEMessageException {
		public HENotImplementedException(HEMessage message) : base(message, null, 1, false) {
		}

        [SecurityCritical]
        public HENotImplementedException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
		}
	}
}