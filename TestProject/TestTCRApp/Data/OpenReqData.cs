using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geidea.TCR.Model.Data
{
    public class OpenReqData : BaseReqData
    {
        public string IPAddress { get; set; }
        public string PortNumber { get; set; }
        public string BranchNo { get; set; }
        public string DeviceNo { get; set; }
        public string TellerID { get; set; }
        public string Password { get; set; }
        public string Side { get; set; } 
    }
}
