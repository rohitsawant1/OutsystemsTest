/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using OutSystems.HubEdition.RuntimePlatform.Log;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.RuntimePlatform {
    public class RequestEventsGenerator {
        public Func<bool> IsPerformanceMonitorEnabled;
        public Func<RequestTracerEventType, int> EventCreationThreshold;
        public Func<bool> IsExposedIntegrationExecutedEnabled = () => RuntimePlatformSettings.Misc.RequestTracerExposedIntegrationExecuted.GetValue();
        public Func<bool> IsInternalCallExecutedEnabled = () => false;
        public Func<bool> IsServiceActionExecutedEnabled = () => RuntimePlatformSettings.Misc.RequestTracerServiceActionExecuted.GetValue();

        private RequestTracer tracer;
        private IList<RequestEvent> _requestEvents = new List<RequestEvent>();

        public IEnumerable<RequestEvent> RequestEvents { get { return _requestEvents; } }

        public RequestEventsGenerator(RequestTracer tracer) {
            this.tracer = tracer;

            AppInfo info = AppInfo.GetAppInfo();

            IsPerformanceMonitorEnabled = () => (info == null) ? false : info.Properties.PerformanceMonitoringEnabled;
            EventCreationThreshold = (type) => GetEventThreshold(type);
        }

        public IEnumerable<RequestEvent> CreateEvents() {
            try {
                _requestEvents.Clear();

                if (tracer.MainEventType == RequestTracerEventType.Undefined) {
                    return _requestEvents;
                }

                CreateEvent(tracer.MainEventType, tracer.RequestStartInstant, tracer.MainRequestEventDetails);

                foreach (ESpaceExternalCallTracer exec in tracer.ESpaceExternalCalls) {
                    CreateEvent(exec.EventType, exec.StartInstant, exec.Details);
                }

                foreach (ESpaceInternalCallTracer exec in tracer.ESpaceInternalCalls) {
                    CreateEvent(exec.EventType, exec.StartInstant, exec.Details);
                }

            } catch (Exception e) {
                HandleException(e);
            }
            return RequestEvents;
        }

        public void CreateEvent(RequestEvent requestEvent) {
            try {
                _requestEvents.Add(requestEvent);
            } catch (Exception e) {
                HandleException(e);
            }
        }

        public void CreateEvent(RequestTracerEventType eventType, DateTime startInstant, RequestEventDetails details) {
            try {
                if (!IsPerformanceMonitorEnabled() ||
                    (EventCreationThreshold(eventType) != 0 && Convert.ToInt32(details[RequestEventDetails.DURATION]) < EventCreationThreshold(eventType)) ||
                    (tracer.MainEventType == RequestTracerEventType.ExposedIntegrationExecuted && !IsExposedIntegrationExecutedEnabled()) ||
                    (eventType == RequestTracerEventType.ActionExecuted && !IsInternalCallExecutedEnabled()) ||
                    (eventType == RequestTracerEventType.ServiceActionExecuted && !IsServiceActionExecutedEnabled())) {
                    return;
                }

                RequestEvent newEvent = new RequestEvent(
                    startInstant,
                    tracer.RequestKey,
                    eventType.ToString(),
                    tracer.ModuleKey,
                    tracer.ModuleName,
                    tracer.ApplicationKey,
                    tracer.ApplicationName,
                    details.ToString()
                );
                _requestEvents.Add(newEvent);
            } catch (Exception e) {
                HandleException(e);
            }
        }

        private void HandleException(Exception e) {
            OSTrace.Error("", e);
        }

        public void GetPerformanceMonitorStatusFrom(Func<bool> isPerformanceMonitorEnabled) {
            this.IsPerformanceMonitorEnabled = isPerformanceMonitorEnabled;
        }

        private int GetEventThreshold(RequestTracerEventType type) {
            switch (type) {
                case RequestTracerEventType.QueryExecuted: return RuntimePlatformSettings.Queries.SlowQueryInMs.GetValue();
                case RequestTracerEventType.ExtensionExecuted: return RuntimePlatformSettings.Misc.SlowExtensionCallInMs.GetValue();
                case RequestTracerEventType.ConsumedIntegrationExecuted: return RuntimePlatformSettings.Misc.SlowIntegrationInMs.GetValue();
                case RequestTracerEventType.ServiceActionExecuted: return RuntimePlatformSettings.Misc.SlowServiceActionInMs.GetValue();
                default: return 0;
            }
        }

        public int CountEventsOfType(RequestTracerEventType eventType) {
            return _requestEvents.Where(reqEvent => reqEvent.RequestEventName == eventType.ToString()).Count();
        }

        public void ClearRequestEvents() {
            _requestEvents.Clear();
        }
    }
}