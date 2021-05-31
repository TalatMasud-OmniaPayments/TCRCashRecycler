using Geidea.TCR.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCRServiceTestClient.FrameworkInterface
{
    public interface IConnectionClient
    {
        Task<bool> Connect();
        void Disconnect();
        void Open(OpenRequestMessage msg);
        /*void Close(CloseRequestMessage msg);
        void DeviceStatus(DeviceStatusRequestMessage msg);
        void Reset(ResetRequestMessage msg);
        void Lock(LockRequestMessage msg);
        void Unlock(UnlockRequestMessage msg);
        void DepositStart(DepositStartRequestMessage msg);
        void DepositAccept(DepositAcceptRequestMessage msg);
        void DepositCancel(DepositCancelRequestMessage msg);
        void DepositEnd(DepositEndRequestMessage msg);
        void Dispense(DispenseRequestMessage msg);
        void PurgeDispense(PurgeDispenseRequestMessage msg);
        void RobberyDispense(RobberyDispenseRequestMessage msg);
        void Inventory(InventoryRequestMessage msg);*/

    }
}
