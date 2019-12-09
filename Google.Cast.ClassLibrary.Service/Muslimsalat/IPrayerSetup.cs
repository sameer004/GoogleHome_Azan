using Quartz;

namespace Google.Cast.ClassLibrary.Service.Muslimsalat
{
    public interface IPrayerSetup<T, TOnce> where T: IJob
                                            where TOnce:IJob
    {
        bool SetUp(string _url, string cron, string player);
    }
}