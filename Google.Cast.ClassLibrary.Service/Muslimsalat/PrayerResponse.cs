using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google.Cast.ClassLibrary.Service.Muslimsalat
{


    public class TodayWeather
    {
        public string pressure { get; set; }
        public string temperature { get; set; }
    }

    public class Item
    {
        public string date_for { get; set; }
        public string fajr { get; set; }
        public string shurooq { get; set; }
        public string dhuhr { get; set; }
        public string asr { get; set; }
        public string maghrib { get; set; }
        public string isha { get; set; }
    }

    public class PrayerResponse
    {
        public string title { get; set; }
        public string query { get; set; }
        public string @for { get; set; }
        public int method { get; set; }
        public string prayer_method_name { get; set; }
        public string daylight { get; set; }
        public string timezone { get; set; }
        public string map_image { get; set; }
        public string sealevel { get; set; }
        public TodayWeather today_weather { get; set; }
        public string link { get; set; }
        public string qibla_direction { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postal_code { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
        public List<Item> items { get; set; }
        public int status_valid { get; set; }
        public int status_code { get; set; }
        public string status_description { get; set; }
    }


}
