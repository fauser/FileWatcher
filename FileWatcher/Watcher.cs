using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileWatcher
{
    class Watcher
    {
        public Watcher()
        {
            FileSystemWatcher m_Watcher = new FileSystemWatcher();
            m_Watcher.Path = @"C:\Users\daniel\Documents";
            m_Watcher.Filter = @"*.*";

            m_Watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            m_Watcher.IncludeSubdirectories = true;

            m_Watcher.Changed += new FileSystemEventHandler(m_Watcher_Changed);
            m_Watcher.Created += new FileSystemEventHandler(m_Watcher_Created);
            m_Watcher.Deleted += new FileSystemEventHandler(m_Watcher_Deleted);
            m_Watcher.Renamed += new RenamedEventHandler(m_Watcher_Renamed);

            m_Watcher.WaitForChanged(WatcherChangeTypes.All);
        }

        static void m_Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine("{0} was renamed", e.Name);
        }

        static void m_Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("{0} was deleted", e.Name);
        }

        static void m_Watcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("{0} was created", e.Name);
        }

        static void m_Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("{0} was changed", e.Name);
        }
    }
}
