using Geidea.TCR.Service.Data.Enum;
//using MoniTellerAPINative.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geidea.TCR.Service.Data.Support
{
    public class OverflowCassette
    {
        public List<Cash> Cash { get; set; }
        public CASSETTE_STATUS Status { get; set; }
    }
}
