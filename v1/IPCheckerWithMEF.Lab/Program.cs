using IPCheckerWithMEF.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            Console.WriteLine($"{app.IpCheckerList.Count} plugin(s) loaded..");
            Console.WriteLine("Executing all plugins...");

            foreach (var ipChecker in app.IpCheckerList)
            {
                Console.WriteLine(ObfuscateIP(ipChecker.GetExternalIp()));
            }
        }

        private static string ObfuscateIP(string actualIp)
        {
            return Regex.Replace(actualIp, "[0-9]", "*");
        }
    }
}
