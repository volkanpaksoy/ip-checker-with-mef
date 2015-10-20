using IPCheckerWithMEF.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IPCheckerWithMEF.Plugins.CustomIpChecker
{
    [Export(typeof(IIpChecker))]
    [ExportMetadata("DisplayName", "Custom IP Checker")]
    [ExportMetadata("Description", "Uses homebrew service developed with Node.js nad hosted on Heroku")]
    [ExportMetadata("Version", "2.1")]
    public class CustomIpChecker : IIpChecker
    {
        public string GetExternalIp()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://check-ip.herokuapp.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("").Result;
                string json = response.Content.ReadAsStringAsync().Result;
                dynamic ip = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                string result = ip.ipAddress;
                return result;
            }
        }
    }
}
