using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTCRApp.Models
{
    public class TestTCRModel
    {
        public long Id { get; set; }
        public string machineName { get; set; }
        public string machineIp { get; set; }
        public string machinePort { get; set; }
        public string command { get; set; }
    }
}
