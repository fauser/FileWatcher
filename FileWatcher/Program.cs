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
            Watcher w = new Watcher();

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        return;
                    default:
                        break;
                }
            }
        }


    }
}
