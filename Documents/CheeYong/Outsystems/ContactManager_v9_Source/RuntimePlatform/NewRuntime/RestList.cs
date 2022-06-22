/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using Newtonsoft.Json;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.RuntimePlatform.NewRuntime {
    public class RestList<T> {
        [JsonProperty("List")]
        public T[] list;

        [JsonProperty("EmptyListItem")]
        public T emptyListItem;

        public RestList() { }

        public RestList(T[] list, T emptyListItem) {
            this.list = list;
            this.emptyListItem = emptyListItem;
        }
    }

    public static class RtRestList {
        public static string ClassName { get { return "RestList"; } }
    }
}