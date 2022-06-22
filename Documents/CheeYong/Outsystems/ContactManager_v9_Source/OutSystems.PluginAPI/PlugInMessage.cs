/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.RuntimeCommon;

namespace OutSystems.PluginAPI {

    public class PluginMessage: IMessageObject {
        public string Id { get; }
        public MessageType Type { get; }
        public string Message { get; }
        public string Detail { get; }
        public string ExtraInfo { get; }
        public int HelpRef { get; }

        public PluginMessage(MessageType level, string message, string detail) : this("", level, message, detail) { }

        public PluginMessage(string id, MessageType level, string message, string detail, string extraInfo = "") {
            // Id is needed 
            Id = id;
            Type = level;
            Message = message;
            Detail = detail;
            ExtraInfo = extraInfo;
        }
    }
}