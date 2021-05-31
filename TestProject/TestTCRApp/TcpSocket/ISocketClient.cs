
using TCRServiceTestClient.Models;
using System.Threading.Tasks;
//using TCRServiceTestClient.Models;

namespace TCRServiceTestClient.TcpSocket
{
    public interface ISocketClient
    {
        Task<bool> Connect(Tcr tcr);
        void Disconnect(Tcr tcr);
        bool IsConnected(Tcr tcr);

        void Send(Tcr tcr, string message);
    }
}
