using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Google.Cast.ClassLibrary.Service.Muslimsalat
{
    public class Muslimsalat
    {
        public PrayerResponse GetPrayers(string url)
        {
            var wc = new WebClient();
            wc.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.108 Safari/537.36");
            wc.Headers.Add("Content-Type", "text/html");
            var json = wc.DownloadString(url);
            return JsonConvert.DeserializeObject<PrayerResponse>(json);
        }
    }
}
