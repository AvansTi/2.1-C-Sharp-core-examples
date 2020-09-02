using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace WatchForChanges
{
    class Program
    {
        static void Main(string[] args) {
            if (args.Length < 1) {
                Console.WriteLine("Usage: WatchForChanges [FolderToWatch]");
                return;
            }
            
            System.IO.FileSystemWatcher watcher = new System.IO.FileSystemWatcher();
            // de commandline argumenten kun je instellen bij project-properties-debug-start options
            watcher.Path = "c:\\";//args[0];
            watcher.IncludeSubdirectories = true;
            watcher.NotifyFilter = NotifyFilters.Size | NotifyFilters.FileName | 
                                   NotifyFilters.DirectoryName | NotifyFilters.CreationTime;
            watcher.Filter = "*.*";
            watcher.Changed += watcher_Change;
            watcher.Created += watcher_Change;
            watcher.Deleted += watcher_Change;
            watcher.Renamed += watcher_Renamed;

            Console.WriteLine("Manipulate files in {0} to see activity...", args[0]);

            watcher.EnableRaisingEvents = true;

            while (true) { Thread.Sleep(1000); }
        }
             
        static void watcher_Change(object sender, System.IO.FileSystemEventArgs e) {
            Console.WriteLine("{0} changed ({1})", e.Name, e.ChangeType);
        }

        static void watcher_Renamed(object sender, System.IO.RenamedEventArgs e) {
            Console.WriteLine("{0} renamed to {1}", e.OldName, e.Name);
        }
    }
}
