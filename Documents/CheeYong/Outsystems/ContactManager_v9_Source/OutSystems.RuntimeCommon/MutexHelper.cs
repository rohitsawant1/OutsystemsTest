/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;

namespace OutSystems.RuntimeCommon {
    
    public static class MutexHelper {

        private static MutexSecurity GetMutexSecurityDefaults() {
            SecurityIdentifier sid = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
            MutexSecurity mutexSecurity = new MutexSecurity();
            mutexSecurity.AddAccessRule(new MutexAccessRule(sid, MutexRights.FullControl, AccessControlType.Allow));
            mutexSecurity.AddAccessRule(new MutexAccessRule(sid, MutexRights.ChangePermissions, AccessControlType.Deny));
            mutexSecurity.AddAccessRule(new MutexAccessRule(sid, MutexRights.Delete, AccessControlType.Deny));
            return mutexSecurity;
        }
        
        public static Mutex CreateMutex(string mutexName, bool globalMutex) {
            return CreateMutex((globalMutex ? "Global\\" : "") + mutexName);
        }

        private static Mutex CreateMutex(string mutexName) {
            bool createdNew;
            return new Mutex(false, mutexName, out createdNew, GetMutexSecurityDefaults());
        }
    }
}
