/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections;
using System.Collections.Specialized;
using System.Text;
using System.Runtime.Serialization;
using System.Web;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.RuntimePlatform
{
	internal class OSHttpValueCollection : System.Collections.Specialized.NameValueCollection {
		internal OSHttpValueCollection() : base() {} 
		internal OSHttpValueCollection(int capacity) : base(capacity) {} 
		internal OSHttpValueCollection(int capacity, string str) : this(capacity, str, false, false, Constants.DefaultEncoding) {} 
		internal OSHttpValueCollection(int capacity, string str, bool readOnly) : this(capacity, str, readOnly, false, Constants.DefaultEncoding) {} 
		internal OSHttpValueCollection(int capacity, string str, bool readOnly, bool urlencoded, Encoding encoding) : base(capacity) {
			if ((str != null) && (str.Length > 0)) {
				FillFromString(str, urlencoded, encoding);
			}
			IsReadOnly = readOnly;
		} 
		protected OSHttpValueCollection(SerializationInfo info, StreamingContext context) : base(info, context) {} 
		internal OSHttpValueCollection(string str) : this(str, false, false, Constants.DefaultEncoding) {} 
		internal OSHttpValueCollection(string str, bool readOnly) : this(str, readOnly, false, Constants.DefaultEncoding) {} 
		internal OSHttpValueCollection(string str, bool readOnly, bool urlencoded, Encoding encoding) : base() {
			if ((str != null) && (str.Length > 0)) {
				FillFromString(str, urlencoded, encoding);
			}
			IsReadOnly = readOnly;
		} 
		internal void Add(HttpCookieCollection c) {
			int num1;
			int num2;
			HttpCookie cookie1;
			num1 = c.Count;
			for (num2 = 0; (num2 < num1); num2 = (num2 + 1)) {
				cookie1 = c.Get(num2);
				base.Add(cookie1.Name, cookie1.Value);
			}
		} 
		internal void FillFromString(string s) {
			FillFromString(s, false, null);
		} 
		internal void FillFromEncodedBytes(byte[] bytes, Encoding encoding) {
			int num1;
			int num2;
			int num3;
			int num4;
			byte num5;
			string text1;
			string text2;
			num1 = ((bytes != null) ? bytes.Length : 0);
			num2 = 0;
			while (num2 < num1) {
				num3 = num2;
				num4 = -1;
				while (num2 < num1) {
					num5 = bytes[num2];
					if (num5 == 61) {
						if (num4 >= 0) {
						} else {
							num4 = num2;
						}
					} else {
						if (num5 == 38) {
							break;
						}
					}
					num2 = (num2 + 1);
				}
				if (num4 >= 0) {
					text1 = HttpUtility.UrlDecode(bytes, num3, (num4 - num3), encoding);
					text2 = HttpUtility.UrlDecode(bytes, (num4 + 1), ((num2 - num4) - 1), encoding);
				} else {
					text1 = null;
					text2 = HttpUtility.UrlDecode(bytes, num3, (num2 - num3), encoding);
				}
				Add(text1, text2);
				if ((num2 == (num1 - 1)) && (bytes[num2] == 38)) {
					base.Add(null, "");
				}
				num2 = (num2 + 1);
			}
		}
		internal void FillFromString(string s, bool urlencoded, Encoding encoding) { 
			int num1;
			int num2;
			int num3;
			int num4;
			char ch1;
			string text1;
			string text2;
			num1 = ((s != null) ? s.Length : 0);
			num2 = 0;
 
			while(num2 < num1){
				num3 = num2;
				num4 = -1;
				while ((num2 < num1)) {
					ch1 = s[num2];
					if (ch1 == '=') {
						if (num4 >= 0) {
						} else {
							num4 = num2;
						}
					} else {
						if (ch1 == '&') {
							break;
						}
					}
					num2 = (num2 + 1);
				}
 
				text1 = null;
				text2 = null;
				if (num4 >= 0) {
					text1 = s.Substring(num3, (num4 - num3));
					text2 = s.Substring((num4 + 1), ((num2 - num4) - 1));
				} else {
					text2 = s.Substring(num3, (num2 - num3));
				}
				if (urlencoded) {
					Add(HttpUtility.UrlDecode(text1, encoding), HttpUtility.UrlDecode(text2, encoding));
				} else {
					Add(text1, text2);
				}
				if ((num2 == (num1 - 1)) && (s[num2] == '&')) {
					Add(null, "");
				}
				num2 = (num2 + 1);
			}
		}
		internal void MakeReadOnly() {
			IsReadOnly = true;
		} 
		internal void MakeReadWrite() {
			IsReadOnly = false;
		} 
		internal void Reset() {
			Clear();
		} 
		public override string ToString() {
			return ToString(true); 
		} 
		internal virtual string ToString(bool urlencoded) {
			StringBuilder local0; //builder1
			int local1;	// num1
			string local2; // text1
			string local3; // text2
			string local4; // text3
			int local5;	// num2
			ArrayList local6; // list1
			int local7;	// num3
			int local8; // num4

			local0 = new StringBuilder();
			local1 = this.Count;
			local5 = 0;
			while (local5 < local1) {
				local2 = this.GetKey(local5);
				if (urlencoded)
					local2 = HttpUtility.UrlEncode(local2);
				local3 = (((local2 != null) && (local2.Length > 0)) ? string.Concat(local2, "=") : "");
				local6 = ((ArrayList) base.BaseGet(local5));
				local7 = ((local6 != null) ? local6.Count : 0);
				if (local5 > 0)
					local0.Append('&');
				if (local7 == 1) {
					local0.Append(local3);
					local4 = (String) local6[0];
					if (urlencoded)
						local4 = HttpUtility.UrlEncode(local4);
					local0.Append(local4);
				}
				else {
					if (local7 == 0)
						local0.Append(local3);
					else {
						local8 = 0;
						while (local8 < local7) {
							if (local8 > 0)
								local0.Append('&');
							local0.Append(local3);
							local4 = (String) local6[local8];
							if (urlencoded)
								local4 = HttpUtility.UrlEncode(local4);
							local0.Append(local4);
							local8++;
						}
					}
				}
				local5++;
			}
			return local0.ToString();
		}
	}
}
