using Blazored.LocalStorage;
using System;
using System.Threading.Tasks;

namespace SkyHighRemote.Client
{
    public interface IAppConfiguration
    {
        public String SkyBoxIP { get; set; }
        public bool Vibrate { get; set; }
        public bool PlaySound { get; set; }
        public bool ShowVisual { get; set; }
        public void Save();
    }
}
