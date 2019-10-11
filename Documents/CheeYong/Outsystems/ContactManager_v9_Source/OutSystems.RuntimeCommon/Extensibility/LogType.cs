/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/


namespace OutSystems.Extensibility {
    public enum LogType {
        // According to PJS, keep Dummy at end of list...
        // It seems like names MUST be 'the same' as the corresponding log tables (watch out for underscores, etc)
        // e.g.:    table physical name: "oslog_General_X" -> LogType.General
        // note 1:  'X' means 'cycle number' [0-9]
        // note 2:  for log rotation, if you don't have a special case in 'LogRotation.cs', 
        //          then the corresponding VIEW must have the same name as the table without the 'cycle' part and with a suffix "_previous"
        //          (e.g. table physical name: "oslog_General_X" -> views names: "oslog_General" and "oslog_General_previous")
        Cyclic_Job,
        Error,
        General,
        Screen,
        Web_Service,
        Web_Reference,
        Custom,
        Extension,
        Integration,
        Int_Detail,
        RequestEvent,
        Mobile_Request,
        MR_Detail,
        SrvAPI, // log table for Service APIs
        SrvAPI_Detail, // log table for Details of Service APIs
        Dummy
    }
}
