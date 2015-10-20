using IPCheckerWithMEF.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPCheckerWithMEF.Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting the main application");

            string pluginFolder = @"..\..\..\Plugins\";

            var app = new MainApplication(pluginFolder);

            Console.WriteLine($"{app.Plugins.Count} plugin(s) loaded..");
            Console.WriteLine("Displaying plugin info...");
            Console.WriteLine();

            foreach (var ipChecker in app.Plugins)
            {
                Console.WriteLine($"Name: {ipChecker.Metadata.DisplayName}");
                Console.WriteLine($"Description: {ipChecker.Metadata.Description}" );
                Console.WriteLine($"Version: {ipChecker.Metadata.Version}");
                Console.WriteLine("----------------------------------------");
            }

        }


    }
}
