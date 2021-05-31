using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geidea.TCR.Model.Data.Enum
{
    public enum COMMAND_REQUEST
    {
        AddCashRequest,
        ClearCashRequest,
        CloseRequest,
        CountRequest,
        DepositAcceptRequest,
        DepositCancelRequest,
        DepositEndRequest,
        DepositStartRequest,
        DeviceStatusRequest,
        DispenseRequest,
        InventoryRequest,
        LockRequest,
        OpenRequest,
        PurgeDispenseRequest,
        ResetRequest,
        RobberyDispenseRequest,
        SetCassetteCountRequest,
        UnlockRequest,
        NETWORK_DISCONNECT
    }
}
