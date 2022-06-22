/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace OutSystems.HubEdition.RuntimePlatform.Internal.Cache {
    class FileWatcherMonitor : ChangeMonitor {
        public List<string> FilePaths { get; }
        private readonly List<FileSystemWatcher> watchers = new List<FileSystemWatcher>();
        public FileWatcherMonitor(IEnumerable<string> filePaths) : base() {
            try {
                this.FilePaths = new List<string>(filePaths).Distinct().ToList();
                foreach (var filename in this.FilePaths) {
                    var watcher = new FileSystemWatcher();
                    var fileInfo = new FileInfo(filename);

                    watcher.Path = fileInfo.DirectoryName;
                    watcher.Filter = fileInfo.Name;
                    watcher.NotifyFilter = NotifyFilters.LastWrite;
                    watcher.Changed += new FileSystemEventHandler((source, e) => {
                        OnChanged(e);
                    });
                    watcher.EnableRaisingEvents = true;
                    watchers.Add(watcher);
                }
            } catch {
                InitializationComplete();
                Dispose();
                throw;
            }
            InitializationComplete();
        }

        public override string UniqueId => string.Join("/",FilePaths);

        protected override void Dispose(bool disposing) {
        }
    }
}