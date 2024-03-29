/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using OutSystems.RuntimeCommon;

namespace OutSystems.RESTService.Formatters {

    public class TextMediaTypeFormatter : MediaTypeFormatter {
        
        private static readonly string[] mainMediaTypes = new string[] { "application/json", "text/plain", "text/html", "application/x-www-form-urlencoded" };
        private static readonly Encoding DefaulRequestEncoding = Encoding.GetEncoding("ISO-8859-1");

        public static readonly TextMediaTypeFormatter Instance = new TextMediaTypeFormatter();

        private readonly ConcurrentDictionary<string, bool> registeredMimeTypes = new ConcurrentDictionary<string, bool>();

	    public TextMediaTypeFormatter() {
            //Register the main types
            foreach (var type in mainMediaTypes) {
                SupportedMediaTypes.Add(new MediaTypeHeaderValue(type));
                registeredMimeTypes[type] = true;
            }

            SupportedEncodings.Add(new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: false));
            SupportedEncodings.Add(new UnicodeEncoding(bigEndian: false, byteOrderMark: true, throwOnInvalidBytes: false));
	    }

	    public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger) {
		    var taskCompletionSource = new TaskCompletionSource<object>();
		    try {
                using (StreamReader reader = new StreamReader(readStream, GetRequestEncoding(content.Headers))) {
                    taskCompletionSource.SetResult(reader.ReadToEnd());
                }
		    } catch (Exception e) {
			    taskCompletionSource.SetException(e);
		    }
		    return taskCompletionSource.Task;
	    }

	    public override bool CanReadType(Type type) {
            if (type == typeof(string)) {
                // #REST-105 (rmf): Register the current request content-type, if not yet registed, so we can handle application/x-www-form-urlencoded or text/* content types in this Text formatter.
                var mimeType = RestServiceHttpUtils.GetRequestContentType(HttpContext.Current.Request).MediaType;

                if ((mimeType.StartsWith("application/json") || mimeType.StartsWith("text/") || mimeType.StartsWith("application/x-www-form-urlencoded")) && !registeredMimeTypes.ContainsKey(mimeType)) {
                    SupportedMediaTypes.Add(new MediaTypeHeaderValue(mimeType));
                    registeredMimeTypes[mimeType] = true;
                }
                return true;
            } else {
                return false;
            }
	    }

	    public override bool CanWriteType(Type type) {
		    return false;
	    }

        [System.Diagnostics.DebuggerNonUserCode]
        private Encoding GetRequestEncoding(HttpContentHeaders contentHeaders) {
            MediaTypeHeaderValue contentType = contentHeaders.ContentType;
            if (contentType != null) {
                String charsetFromContentType = contentType.CharSet;
                if (!charsetFromContentType.IsEmpty()) {
                    try {
                        return Encoding.GetEncoding(charsetFromContentType);
                    } catch (ArgumentException) {
                        // return the default encoding
                    }
                }
            }
            return DefaulRequestEncoding;
        }
    }

}
