using Google.Cast.ClassLibrary.Service.Muslimsalat;
using Google.Cast.Data;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google.Cast.Desktop.Installer
{
    public class SetAzanSchedule : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            StartUp();
        }

        private static void StartUp()
        {
            IDal _dal = new Dal();

            var a = new PrayerSetup<Azan, SetAzanSchedule>().SetUp(string.Format("https://muslimsalat.com/{0}/daily/{1}/false.json", "newyork", DateTime.Now.ToString("dd-MM-yyyy"))
    , "0 1 0 1/1 * ? *"
    , _dal.GetPlayer());
        }
    }
}
