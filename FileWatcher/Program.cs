using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace FileWatcher
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                // Create a new FileSystemWatcher and set its properties.
                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.Path = @"C:\Users\daniel\Documents";

                // Watch both files and subdirectories.
                watcher.IncludeSubdirectories = true;

                // Watch for all changes specified in the NotifyFilters
                //enumeration.
                watcher.NotifyFilter = NotifyFilters.Attributes |
                NotifyFilters.DirectoryName |
                NotifyFilters.FileName |
                NotifyFilters.LastAccess |
                NotifyFilters.LastWrite |
                NotifyFilters.Security |
                NotifyFilters.Size;

                // Watch all files.
                watcher.Filter = "*.*";

                // Add event handlers.
                watcher.Changed += new FileSystemEventHandler(watcher_Changed);
                watcher.Created += new FileSystemEventHandler(watcher_Created);
                watcher.Deleted += new FileSystemEventHandler(watcher_Deleted);
                watcher.Renamed += new RenamedEventHandler(watcher_Renamed);

                //Start monitoring.
                watcher.EnableRaisingEvents = true;



                // Wait for user to quit program.
                Console.WriteLine("Press \'q\' to quit the sample.");
                Console.WriteLine();

                //Make an infinite loop till 'q' is pressed.
                while (Console.Read() != 'q') ;
            }
            catch (IOException e)
            {
                Console.WriteLine("A Exception Occurred :" + e);
            }

            catch (Exception oe)
            {
                Console.WriteLine("An Exception Occurred :" + oe);
            }
        }

        static void watcher_Renamed(object sender, RenamedEventArgs e)
        {
            // Specify what is done when a file is renamed.
            Console.WriteLine("{0} renamed to {1}", e.OldFullPath, e.FullPath);
        }

        static void watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed.
            Console.WriteLine(@"{0} has been {1}", e.FullPath, e.ChangeType);
        }

        static void watcher_Created(object sender, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed.
            Console.WriteLine(@"{0} has been {1}", e.FullPath, e.ChangeType);
        }

        static void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed.
            Console.WriteLine(@"{0} has been {1}", e.FullPath, e.ChangeType);
        }
    }
}
