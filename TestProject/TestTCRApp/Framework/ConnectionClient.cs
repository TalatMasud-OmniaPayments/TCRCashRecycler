using Geidea.TCR.Model.Data;
//using Geidea.TCR.Service.Implementation;
using Newtonsoft.Json;
using NLog;
using System.Threading.Tasks;
using TCRServiceTestClient.FrameworkInterface;
using TCRServiceTestClient.Models;
//using TCRServiceTestClient.Models;
using TCRServiceTestClient.TcpSocket;

namespace TCRServiceTestClient.Framework
{
    public class ConnectionClient : IConnectionClient
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        private Tcr tcr;
        public ConnectionClient(Tcr tcr)
        {
            this.tcr = tcr;
        }

        public void Close(CloseRequestMessage msg)
        {
            if (msg != null) SendMessage(msg);
        }

        public async Task<bool> Connect()
        {
            ISocketClient sc = SocketClient.GetInstance();
            bool result = await sc.Connect(tcr);
            return result;
        }

        /*public void DepositAccept(DepositAcceptRequestMessage msg)
        {
            if (msg != null) SendMessage(msg);
        }

        public void DepositCancel(DepositCancelRequestMessage msg)
        {
            if (msg != null) SendMessage(msg);
        }

        public void DepositEnd(DepositEndRequestMessage msg)
        {
            if (msg != null) SendMessage(msg);
        }

        public void DepositStart(DepositStartRequestMessage msg)
        {
            if (msg != null) SendMessage(msg);
        }

        public void DeviceStatus(DeviceStatusRequestMessage msg)
        {
            if (msg != null) SendMessage(msg);
        }*/

        public void Disconnect()
        {
            ISocketClient sc = SocketClient.GetInstance();
            sc.Disconnect(tcr);
        }
/*
        public void Dispense(DispenseRequestMessage msg)
        {
            if (msg != null) SendMessage(msg);
        }

        public void Inventory(InventoryRequestMessage msg)
        {
            if (msg != null) SendMessage(msg);
        }

        public void Lock(LockRequestMessage msg)
        {
            if (msg != null) SendMessage(msg);
        }*/

        public void Open(OpenRequestMessage msg)
        {
            if (msg != null) SendMessage(msg);
        }

        /*public void PurgeDispense(PurgeDispenseRequestMessage msg)
        {
            if (msg != null) SendMessage(msg);
        }

        public void Reset(ResetRequestMessage msg)
        {
            if (msg != null) SendMessage(msg);
        }

        public void RobberyDispense(RobberyDispenseRequestMessage msg)
        {
            if (msg != null) SendMessage(msg);
        }

        public void Unlock(UnlockRequestMessage msg)
        {
            if (msg != null) SendMessage(msg);
        }
        */
        private void SendMessage(BaseRequestMessage message)
        {
            string jsonStr = JsonConvert.SerializeObject(message);
            ISocketClient sc = SocketClient.GetInstance();

            //log.Debug("Sending Message: {0}", jsonStr);

            if (sc.IsConnected(tcr))
            {
                sc.Send(tcr, jsonStr);
            }
            else
            {
                log.Debug("Cannot send msg, {0} is not connected", tcr.TcrId);
            }
        }
    }
}
