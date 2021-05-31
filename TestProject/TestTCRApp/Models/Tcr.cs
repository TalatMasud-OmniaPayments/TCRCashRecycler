using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCRServiceTestClient.Models
{
    public class Tcr
    {
        public String TcrId { get; set; }
        public String Ip { get; set; }
        public int Port { get; set; }
        public bool UseSSL { get; set; }
        public int ReconnectValue { get; set; }
        public String Certificate { get; set; }
    }
}
