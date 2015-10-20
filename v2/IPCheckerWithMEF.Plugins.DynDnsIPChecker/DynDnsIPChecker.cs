using IPCheckerWithMEF.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IPCheckerWithMEF.Plugins.DynDnsIPChecker
{
    [Export(typeof(IIpChecker))]
    public class DynDnsIPChecker : IIpChecker
    {
        public string GetExternalIp()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://checkip.dyndns.org");
                HttpResponseMessage response = client.GetAsync("/").Result;
                return ExtractIPAddress(response.Content.ReadAsStringAsync().Result);
            }
        }

        private string ExtractIPAddress(string fullText)
        {
            string regExPattern = @"\b(?:[0-9]{1,3}\.){3}[0-9]{1,3}\b";

            Regex regex = new Regex(regExPattern);
            Match match = regex.Match(fullText);
            if (match != null && match.Success)
            {
                return match.Value;
            }

            throw new ArgumentException("Provided text does not contain an IP address");
        }
    }
}
