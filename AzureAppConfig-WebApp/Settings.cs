using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureAppConfig_WebApp
{
    public class Settings
    {
        public string AppName { get; set; }
        public string BackgroundColor { get; set; }
        public int FontSize { get; set; }
        public string Language { get; set; }
        public string Message { get; set; }
        public int RefreshRate { get; set; }
        public double Version { get; set; }
    }
}
