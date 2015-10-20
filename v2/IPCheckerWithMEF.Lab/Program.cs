using IPCheckerWithMEF.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPCheckerWithMEF.Lab
{
    class Program
    {
        private static readonly string _pluginFolder = @"..\..\..\Plugins\";
        private static FileSystemWatcher _pluginWatcher;
        private static MainApplication _app;

        static void Main(string[] args)
        {
            Console.WriteLine("Starting the main application");

            // string pluginFolder = @"..\..\..\Plugins\";

            _pluginWatcher = new FileSystemWatcher();
            _pluginWatcher.Path = _pluginFolder;
            _pluginWatcher.Created += PluginWatcher_Created;
            _pluginWatcher.EnableRaisingEvents = true;

            _app = new MainApplication(_pluginFolder);

            PrintPluginInfo();

            Console.ReadLine();
        }

        private static void PrintPluginInfo()
        {
            Console.WriteLine($"{_app.Plugins.Count} plugin(s) loaded..");
            Console.WriteLine("Displaying plugin info...");
            Console.WriteLine();

            foreach (var ipChecker in _app.Plugins)
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"Name: {ipChecker.Metadata.DisplayName}");
                Console.WriteLine($"Description: {ipChecker.Metadata.Description}");
                Console.WriteLine($"Version: {ipChecker.Metadata.Version}");
            }
        }

        private static void PluginWatcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Folder changed. Reloading plugins...");
            Console.WriteLine();
            
            _app.LoadPlugins();

            PrintPluginInfo();
        }
    }
}
