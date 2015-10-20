using IPCheckerWithMEF.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IPCheckerWithMEF.Plugins.AwsIPChecker
{
    [Export(typeof(IIpChecker))]
    [ExportMetadata("DisplayName", "AWS IP Checker")]
    [ExportMetadata("Description", "Uses AWS's service to get the external IP address")]
    [ExportMetadata("Version", "1.1")]
    public class AwsIPChecker : IIpChecker
    {
        public string GetExternalIp()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://checkip.amazonaws.com/");
                string result = client.GetStringAsync("").Result;
                return result.TrimEnd('\n');
            }
        }
    }
}
