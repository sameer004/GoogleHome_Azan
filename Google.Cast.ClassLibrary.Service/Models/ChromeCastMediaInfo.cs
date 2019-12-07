using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Google.Cast.ClassLibrary.Service.Models
{
    public class ChromeCastMediaInfo : IChromeCastMediaInfo
    {
        public ChromeCastMediaInfo()
        {
            this.FriendlyName = "Kitchen display";//"Office Ustairs speaker";
            this.MediaUrl = "http://remote.khanzone.com:8181/audio/Azan.mp3";
        }
        public string FriendlyName { get; set; }
        public string MediaUrl { get; set; }

    }
}
