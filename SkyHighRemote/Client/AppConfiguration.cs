using System;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.Extensions.Configuration;

namespace SkyHighRemote.Client
{
    /// <summary>
    /// The apps config class
    /// </summary>
    public class AppConfiguration : IAppConfiguration
    {

        public String SkyBoxIP { get; set; }
        public bool Vibrate { get; set; }

        public bool PlaySound { get; set; }

        public bool ShowVisual { get; set; }

        public String SkyPIN { get; set; }

        private ISyncLocalStorageService _localStorage;

        public AppConfiguration()
        {

        }

        public AppConfiguration(ISyncLocalStorageService localStorage)
        {
            _localStorage = localStorage;

            var appConfig = localStorage.GetItem<AppConfiguration>("configuration");

            if (appConfig != null)
            {
                this.SkyBoxIP = appConfig.SkyBoxIP;
                this.Vibrate = appConfig.Vibrate;
                this.PlaySound = appConfig.PlaySound;
                this.ShowVisual = appConfig.ShowVisual;
                this.SkyPIN = appConfig.SkyPIN;
            }

        }

        /// <summary>
        /// Saves the config to local storage
        /// </summary>
        public void Save()
        {
            _localStorage.SetItem<AppConfiguration>("configuration", this);
        }
    }
}
