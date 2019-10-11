/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OutSystems.HubEdition.RuntimePlatform.Processes {
    public class ActivityHandlerFactory: IActivityHandlerFactory {
        private class ActivityHandlerProxy: IActivityHandler {
            ActivityHandler actHandler;

            public ActivityHandlerProxy(string url, int tenantId, int userId, string consumerKey, string producerKey) {
                actHandler = new ActivityHandler(url, tenantId, userId, consumerKey, producerKey);
            }

            public void ExecuteOnEvent(string ssKey, int activityId, int processId, int tenantId, string dataId, bool advanceProcess) {
                actHandler.ExecuteOnEvent(ssKey, activityId, processId, tenantId, dataId, advanceProcess);
            }

            public int Timeout { set { actHandler.Timeout = value; } }

            public void Dispose() {
                actHandler.Dispose();
            }
        }
        
        private static IActivityHandlerFactory instance = new ActivityHandlerFactory();

        public IActivityHandler GetActivityHandler(string url, int tenantId, int userId, string consumerKey, string producerKey) {
            return new ActivityHandlerProxy(url, tenantId, userId, consumerKey, producerKey);
        }

        public static IActivityHandlerFactory Current { 
            get { 
                return instance; 
            } 
            set { 
                instance = value;
            }
        }
    }
}
