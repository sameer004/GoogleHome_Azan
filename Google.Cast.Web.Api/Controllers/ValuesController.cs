using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cast.Web.Api.Models;
using GoogleCast;
using GoogleCast.Channels;
using GoogleCast.Models.Media;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Google.Cast.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private GoogleCastPlayer _GoogleCastPlayer;
        public ValuesController(IOptions<GoogleCastPlayer> GoogleCastPlayer)
        {
            _GoogleCastPlayer = GoogleCastPlayer.Value;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("play")]
        public async Task<string> Play()
        {
            var players = await FindPlayers();
            var player = this.setPlayer(_GoogleCastPlayer.FriendlyName, players);
            //https://muslimsalat.com/11756/yearly.json?key=70d13adc5af09352484a31645c18b266
            var playMedia = await this.PlayMedia(player, _GoogleCastPlayer.MediaUrl);

            return "OK";
        }


        private async Task<IEnumerable<IReceiver>> FindPlayers()
        {
            return (await new DeviceLocator().FindReceiversAsync()).ToList();

        }
        private IReceiver setPlayer(string playerName, IEnumerable<IReceiver> players)
        {
            return players.Where(p => p.FriendlyName == playerName).FirstOrDefault();
        }

        private async Task<MediaStatus> PlayMedia(IReceiver player, string media)
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

            return mediaStatus;

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
