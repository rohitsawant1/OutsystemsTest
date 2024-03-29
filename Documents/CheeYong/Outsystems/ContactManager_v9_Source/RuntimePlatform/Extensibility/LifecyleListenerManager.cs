/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace OutSystems.HubEdition.RuntimePlatform.Extensibility {
    /// <summary>
    /// Provides methods for plugins to register in Page LifeCycle events
    /// </summary>
    public sealed class LifecyleListenerManager {
        private static readonly ReaderWriterLockSlim readWriteLock = new ReaderWriterLockSlim();
        private static readonly OrderRespectingDictionary<string, LifecyleListener> listeners = new OrderRespectingDictionary<string, LifecyleListener>();

        private class ReadLock : IDisposable {
            public ReadLock() {
                readWriteLock.EnterReadLock();
            }
            public void Dispose() {
                readWriteLock.ExitReadLock();
            }
        }

        private class WriteLock : IDisposable {
            public WriteLock() {
                readWriteLock.EnterWriteLock();
            }
            public void Dispose() {
                readWriteLock.ExitWriteLock();
            }
        }


        /// <summary>
        /// Notify all plugins registered in the OnApplicationStart event
        /// </summary>
        public static void OnApplicationStart() {
            using (new ReadLock()) {
                foreach (var listener in listeners.Values) {
                    listener.OnApplicationStart();
                }
            }
        }

        /// <summary>
        /// Register a new LifecycleListener
        /// </summary>
        /// <param name="className">The full class name</param>
        /// <param name="assemblyName">The asssembly name</param>
        public static void RegisterListener(string className, AssemblyName assemblyName) {
            string listenerFullname = className + "," + assemblyName.ToString();
            RegisterListener(Type.GetType(listenerFullname));
        }

        private static void RegisterListener(Type listenerClass) {
            string assemblyQualifiedName = listenerClass.AssemblyQualifiedName;
            using (new WriteLock()) {
                if (!listeners.ContainsKey(assemblyQualifiedName)) {
                    listeners.Add(assemblyQualifiedName, (LifecyleListener)Activator.CreateInstance(listenerClass));
                }
            }
        }

        public static void RegisterListener(LifecyleListener listener) {
            string assemblyQualifiedName = listener.GetType().AssemblyQualifiedName;
            using (new WriteLock()) {
                if (!listeners.ContainsKey(assemblyQualifiedName)) {
                    listeners.Add(assemblyQualifiedName, listener);
                }
            }
        }
    }
}