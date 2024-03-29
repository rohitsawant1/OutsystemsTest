/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.Linq;
using System.Security.Principal;

namespace OutSystems.HubEdition.DatabaseProvider.SqlServer.Platform.Configuration {

    internal class WindowsUser {

        internal class UserInfo {
            public readonly string Username;
            public readonly string Domain;
            public readonly SecurityIdentifier Sid;

            public UserInfo(string username, string domain, SecurityIdentifier sid) {
                this.Username = username;
                this.Domain = domain;
                this.Sid = sid;
            }
        }

        private static SecurityIdentifier UsernameToSid(string username) {
            if (!string.IsNullOrEmpty(username)) {
                try {
                    return new NTAccount(username).Translate(typeof(SecurityIdentifier)) as SecurityIdentifier;
                } catch {
                    // Invalid User
                }
            }
            return null;
        }

        private static string SidToUserName(SecurityIdentifier sid) {
            if (sid != null) {
                return ((NTAccount)sid.Translate(typeof(NTAccount))).Value;
            }
            return null;
        }

        private static UserInfo GetUserInfoByUsername(string username) {
            if (string.IsNullOrEmpty(username)) {
                return null;
            }

            try {
                // This is the cleaner way to know if a username is valid
                // The translate to SecurityIdentifier fails if it doesn't exist, and at the same time we get the username in a standard Domain\Username format
                SecurityIdentifier sid = UsernameToSid(username);
                if (sid == null) {
                    return null;
                }

                var castUsername = SidToUserName(sid);
                if (castUsername == null) {
                    return null;
                }

                var userSplit = castUsername.Split('\\');
                var usernameFormated = userSplit.Last();
                var domainFormated = userSplit.First();

                return new UserInfo(usernameFormated, usernameFormated == domainFormated ? "" : domainFormated, sid);
            } catch {
                // Invalid User
            }

            return null;
        }

        internal static string Normalize(string username) {
            var userInfo = GetUserInfoByUsername(username);

            if (userInfo == null) {
                return username;
            }

            if (string.IsNullOrEmpty(userInfo.Domain)) {
                return userInfo.Username;
            }

            return userInfo.Domain + "\\" + userInfo.Username;
        }
    }
}