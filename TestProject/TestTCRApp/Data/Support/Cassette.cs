﻿using Geidea.TCR.Service.Data.Enum;
//using MoniTellerAPINative.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geidea.TCR.Service.Data.Support
{
    public class Cassette
    {
        public int Count { get; set; }
        public string Currency { get; set; }
        public int Denomination { get; set; }
        public string PhysicalID { get; set; }
        public string PositionName { get; set; }
        public CASSETTE_STATUS Status { get; set; }
    }
}
