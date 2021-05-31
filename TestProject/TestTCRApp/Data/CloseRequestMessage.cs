using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geidea.TCR.Model.Data
{
    public class CloseRequestMessage : BaseRequestMessage
    {
        public CloseReqData Data { get; set; }
    }
}
