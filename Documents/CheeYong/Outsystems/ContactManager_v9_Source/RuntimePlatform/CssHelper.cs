/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.IO;

namespace OutSystems.HubEdition.RuntimePlatform {
    
    public static class CssHelper {

        public static string GetCssInclude(string url) {
            return "<link href=\"" + url + "\" type=\"text/css\" rel=\"stylesheet\" />";
        }

        public static void WriteCssInclude(TextWriter writer, string url) {
            writer.WriteLine(GetCssInclude(url));
        }
    }
}
