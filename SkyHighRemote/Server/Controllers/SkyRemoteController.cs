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
using System.Text.RegularExpressions;

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

        Dictionary<char, string> LetterKeyRef = new Dictionary<char, string>(){
            {'1', "1"}, {'a', "2"}, {'b', "22"}, {'c', "222"} , {'2', "2222"}, {'d', "3"}, {'e', "33"}, {'f', "333"}, {'3', "3333"}, {'g', "4"}, {'h', "44"}, {'i', "444"}, {'4', "4444"}, {'j', "5"}, {'k', "55"}, {'l', "555"}, {'5', "5555"}, {'m', "6"}, {'n', "66"}, {'o', "666"}, {'6', "6666"}, {'p', "7"}, {'q', "77"}, {'r', "777"}, {'s', "7777"}, {'7', "77777"}, {'t', "8"}, {'u', "88"}, {'v', "888"}, {'8', "8888"}, {'w', "9"}, {'x', "99"}, {'y', "999"}, {'z', "9999"}, {'9', "99999"}, {' ', "0"}, {'0', "00"}
        };

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

            command = command.Trim();

            // Check this is a legit command
            if (SkyCommands.Contains(command))
            {
                // Send command
                bool result = await nodeServices.InvokeAsync<bool>("./SkyRemoteNode", command, ipAddress);
                return Content(result.ToString());
            }
            else
            {
                return BadRequest("Command missing or not permitted.");
            }

        }

        /// <summary>
        /// Sends a 4 digit pin to the Sky Box.
        /// </summary>
        /// <param name="nodeServices">Node Services.</param>
        /// <param name="ipAddress">The ip address of the box to send to.</param>
        /// <param name="pin">The pin.</param>
        /// <returns>The response</returns>
        [HttpPost, Route("sendpin/{ipAddress}/{pin}")]
        public async Task<IActionResult> SendPIN([FromServices] INodeServices nodeServices, string ipAddress, string pin)
        {

            if (ipAddress == null || ipAddress == "0.0.0.0")
            {
                return StatusCode(500, "No ip address");
            }

            pin = pin.Trim();

            if (pin.Length != 4)
            {
                return StatusCode(500, $"{pin} must be 4 digits.");
            }

            if (!Regex.IsMatch(pin, @"^[0-9]+$"))
            {
                return StatusCode(500, $"{pin} must be digits only.");
            }

            bool result = false;

            //Send each character to the box with a half second delay
            foreach (char c in pin)
            {
                result = await nodeServices.InvokeAsync<bool>("./SkyRemoteNode", c, ipAddress);
                await Task.Delay(500);

                if (result == false)
                {
                    return StatusCode(500, $"Error sending character '{c}' to box.");
                }

            }

            // If we've got this far it seems to have gone ok so return the last positive
            return Content(result.ToString());
        }


        /// <summary>
        /// Sends a text string to the Sky Box.
        /// </summary>
        /// <param name="nodeServices">Node Services.</param>
        /// <param name="ipAddress">The ip address of the box to send to.</param>
        /// <param name="text">The text.</param>
        /// <returns>The response</returns>
        [HttpPost, Route("sendtext/{ipAddress}/{text}")]
        public async Task<IActionResult> SendText([FromServices] INodeServices nodeServices, string ipAddress, string text)
        {

            if (ipAddress == null || ipAddress == "0.0.0.0")
            {
                return StatusCode(500, "No ip address");
            }

            text = text.Trim().ToLower();

            // a-z, digits and space only
            Regex rx = new Regex(@"^[\d \w \s]+$");

            // Validate
            if (rx.IsMatch(text))
            {
                bool result = false;
                string sendString = "";

                //Convert to number format
                foreach (char c in text)
                {
                    sendString = sendString + LetterKeyRef[c] + '|';
                }

                //Send with an appropriate delay
                foreach (char c in sendString)
                {
                    if (c.Equals('|'))
                    {
                        //Send an additional delay to ensure we output a new letter in the Sky onscreen text box
                        await Task.Delay(1000);
                    }

                    result = await nodeServices.InvokeAsync<bool>("./SkyRemoteNode", c, ipAddress);

                    if (result == false)
                    {
                        // Somethings gone wrong so error and drop out
                        return StatusCode(500, $"Error sending character {c} to box.");
                    }
                    await Task.Delay(250);
                }

                return Content(result.ToString());
            }
            else
            {
                return StatusCode(500, "Non permitted characters.");
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
