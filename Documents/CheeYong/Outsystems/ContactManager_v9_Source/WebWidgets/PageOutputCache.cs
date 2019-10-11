/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.WebWidgets {
    public sealed class PageOutputCache {

        public string Content;
        public object ChildViewState;
        public object ViewState;
        public DownloadNodeCache DownloadNodeCache;

        public PageOutputCache(string Content, object ViewState, object ChildViewState) {
            this.Content = Content;
            this.ChildViewState = ChildViewState;
            this.ViewState = ViewState;
            DownloadNodeCache = new DownloadNodeCache();
        }
    }
}