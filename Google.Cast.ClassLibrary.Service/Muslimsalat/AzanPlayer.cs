using Google.Cast.ClassLibrary.Service.Models;
using GoogleCast;
using GoogleCast.Channels;
using GoogleCast.Models.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google.Cast.ClassLibrary.Service.Muslimsalat
{
    public class AzanPlayer
    {
        private IChromeCastMediaInfo _ChromeCastMediaInfo;
        public AzanPlayer(IChromeCastMediaInfo ChromeCastMediaInfo)
        {
            _ChromeCastMediaInfo = ChromeCastMediaInfo;
        }
        public AzanPlayer()
        {

        }

        public async Task<string> Play(Action<string> StatusMethod)
        {
            var players = await FindPlayers();
            var player = this.setPlayer(_ChromeCastMediaInfo.FriendlyName, players);
            var playMedia = await this.PlayMedia(player, _ChromeCastMediaInfo.MediaUrl);
            StatusMethod(playMedia.PlayerState);

            return "OK";
        }


        private async Task<IEnumerable<IReceiver>> FindPlayers()
        {
            try
            {
                return (await new DeviceLocator().FindReceiversAsync()).ToList();
            }
            catch (Exception)
            {

                throw;
            }
         

        }


        public async Task<List<string>> GoogleCastPlayers()
        {

            var players = await this.FindPlayers();
            var lst = new List<string>();
            foreach (var item in players)
            {
                lst.Add(item.FriendlyName);
            }

            return lst;
        }

        private IReceiver setPlayer(string playerName, IEnumerable<IReceiver> players)
        {
            return players.Where(p => p.FriendlyName == playerName).FirstOrDefault();
        }

        private async Task<MediaStatus> PlayMedia(IReceiver player, string media)
        {

            try
            {
                var sender = new Sender();
                // Connect to the Chromecast
                await sender.ConnectAsync(player);
                // Launch the default media receiver application
                var mediaChannel = sender.GetChannel<IMediaChannel>();
                await sender.LaunchAsync(mediaChannel);
                // Load and play Big Buck Bunny video
                var mediaStatus = await mediaChannel.LoadAsync(
                    new MediaInformation() { ContentId = media });

                sender.Disconnect();

                return mediaStatus;
            }
            catch (Exception  )
            {

                throw;
            }


        }


    }
}
