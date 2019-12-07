using Google.Cast.ClassLibrary.Service.Models;
using Google.Cast.ClassLibrary.Service.Muslimsalat;
using Quartz;
using Quartz.Spi;
using System.Windows;

namespace Google.Cast.Desktop.Installer
{
    public class Azan : IJob
    {

        public void Execute(IJobExecutionContext context)
        {   
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            string jobSays = dataMap.GetString("job_name");
            string playerName = dataMap.GetString("player");

            if (!string.IsNullOrEmpty(playerName))
            {
                // Play The Azan
                // MessageBox.Show(jobSays);
                var mediaInfo = new ChromeCastMediaInfo();
                mediaInfo.FriendlyName = playerName;

                if (jobSays.ToLower().Equals("testPrayer_1"))
                {
                    mediaInfo.MediaUrl = "http://remote.khanzone.com:8181/audio/Fajar.mp3";
                }
                else
                {
                    mediaInfo.MediaUrl = "http://remote.khanzone.com:8181/audio/Azan.mp3";
                }
                
                var p = new AzanPlayer(mediaInfo).Play((s)=> { MainWindow.UpdateStatus(s); });

               
            }
        }


    }
}


//FriendlyName= "Office Ustairs speaker",
//MediaUrl= "http://dight310.byu.edu/media/audio/FreeLoops.com/2/2/Chair%20on%20Wood%20Sound-14736-Free-Loops.com.mp3
//https://www.islamcan.com/audio/adhan/azan10.mp3