using System;
using System.Collections.Generic;
using System.Text;

namespace SkyHighRemote.Shared
{
    /// <summary>
    /// The definition of a Sky box
    /// </summary>
    public class SkyHDBox
    {
        public string IPAddress { get; set; }
        public string Manufacturer { get; set; }
        public string ModelName { get; set; }
        public string ModelNumber { get; set; }
    }
}
