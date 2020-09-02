using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;
using ParkSquare.SkyTv;
using ParkSquare.SkyTv.Networking;
using ParkSquare.UPnP;
using SkyHighRemote.Shared;
using Microsoft.Extensions.Logging;

namespace SkyHighRemote.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkyRemoteController : ControllerBase
    {

        private readonly ILogger<SkyRemoteController> logger;
        private readonly Microsoft.Extensions.Configuration.IConfiguration configuration;

        public SkyRemoteController(ILogger<SkyRemoteController> logger, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration;
        }

        List<string> SkyCommands = new List<string>(41) { "sky", "power", "tvguide", "home", "boxoffice", "search", "interactive", "services", "up", "down", "left", "right", "select", "channelup", "channeldown", "i", "backup", "dismiss", "text", "help", "play", "pause", "rewind", "fastforward", "stop", "record", "red", "green", "yellow", "blue", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        /// <summary>
        /// Sends the command to the Sky Box.
        /// </summary>
        /// <param name="nodeServices">Node Services.</param>
        /// <param name="ipAddress">The ip address of the box to send to.</param>
        /// <param name="command">The command.</param>
        /// <returns>The response</returns>
        [HttpPost, Route("sendcommand/{ipAddress}/{command}")]
        public async Task<IActionResult> SendCommand([FromServices] INodeServices nodeServices, string ipAddress, string command)
        {

            if (ipAddress == null || ipAddress == "0.0.0.0")
            {
                return StatusCode(500, "No ip address");
            }

            // Check this is a legit command
            if (SkyCommands.Contains(command))
            {
                bool result = await nodeServices.InvokeAsync<bool>("./SkyRemoteNode", command, ipAddress);
                return Content(result.ToString());
            }
            else
            {
                return BadRequest("Command not permitted.");
            }

        }

        /// <summary>
        /// Finds all the sky boxes on the network.
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("findboxes")]
        public async Task<IEnumerable<SkyHDBox>> FindBoxes()
        {
            List<SkyHDBox> boxOutputList = new List<SkyHDBox>();

            await Task.Run(() =>
           {
               var config = new MapperConfiguration(cfg =>
               {
                   cfg.AddProfile<DtoMappingProfile>();
               });

               var mapper = config.CreateMapper();

               var service = new DeviceDiscovery(new Host(), new DeviceFactory(new SimpleHttpClient()));

               var boxes = service.FindSkyBoxes();

               foreach (var returnedBox in boxes)
               {
                   boxOutputList.Add(new SkyHDBox { IPAddress = returnedBox.IpAddress.ToString(), Manufacturer = returnedBox.Manufacturer, ModelName = returnedBox.ModelName, ModelNumber = returnedBox.ModelNumber });
               }
           });

            return boxOutputList;
        }

        /// <summary>
        /// Gets the server version no
        /// </summary>
        /// <returns>version no</returns>
        [HttpGet, Route("getversion")]
        public async Task<string> GetServerVersion()
        {
            string serverVersionNo = "";

            await Task.Run(() =>
            {
                serverVersionNo = configuration["Version:Server"];
            });

            return serverVersionNo;

        }

    }
}
