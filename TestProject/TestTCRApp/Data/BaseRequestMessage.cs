using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geidea.TCR.Model.Data
{
    public class BaseRequestMessage
    {
        public string ClientID { get; set; }
        public string Command { get; set; }
    }
}
