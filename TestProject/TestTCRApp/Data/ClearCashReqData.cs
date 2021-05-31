using Geidea.TCR.Model.Data;
using Geidea.TCR.Service.Data.Enum;
//using MoniTellerAPINative.Contracts;
using Geidea.TCR.Service.Data.Support;
using System.Collections.Generic;
//using CLEARCASH_TYPE = MoniTellerAPINative.Contracts.CLEARCASH_TYPE;

namespace Geidea.TCR.Service.Data
{
    public class ClearCashReqData : BaseReqData
    {
        public List<Target> ClearCashTarget { get; set; }
        public CLEARCASH_TYPE ClearCashType { get; set; }
        
    }
}
