﻿using Geidea.TCR.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geidea.TCR.Service.Data
{
    public class DepositAcceptReqData : BaseReqData
    {
        public int AcceptTimeout { get; set; }
    }
}
