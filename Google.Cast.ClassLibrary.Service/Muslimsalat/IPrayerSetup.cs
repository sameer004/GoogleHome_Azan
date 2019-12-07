using Quartz;

namespace Google.Cast.ClassLibrary.Service.Muslimsalat
{
    public interface IPrayerSetup<T> where T:IJob
    {
        bool SetUp(string _url, string cron, string player);
    }
}