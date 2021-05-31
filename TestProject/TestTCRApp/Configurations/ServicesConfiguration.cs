using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Geidea.TCR.Service.Configuration
{
    public sealed class ServicesConfiguration
    {
        private static readonly Lazy<ServicesConfiguration> lazy = new Lazy<ServicesConfiguration>(() => new ServicesConfiguration());

        public static ServicesConfiguration Instance { get { return lazy.Value; } }

        private const string SECTION = "serviceParameters";

        private ServicesConfiguration()
        {
        }

        /*public string DateFormatParameter
        {
            get { return GetNodeValue(SECTION, "DATE_FORMAT_PARAMETER"); }
            set { SetNodeValue(SECTION, "DATE_FORMAT_PARAMETER", value); }
        }

        public string HostIp
        {
            get { return GetNodeValue(SECTION, "HOST_IP"); }
            set { SetNodeValue(SECTION, "HOST_IP", value); }
        }
        
        
        public string DeviceStatusMethod
        {
            get { return GetNodeValue(SECTION, "DEVICE_STATUS_METHOD"); }
            set { SetNodeValue(SECTION, "DEVICE_STATUS_METHOD", value); }
        }

        public string DeviceEventsMethod
        {
            get { return GetNodeValue(SECTION, "DEVICE_EVENTS_METHOD"); }
            set { SetNodeValue(SECTION, "DEVICE_EVENTS_METHOD", value); }
        }*/
        
    }
}
