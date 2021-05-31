using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCRServiceTestClient.Models;

namespace TCRServiceTestClient.FrameworkInterface
{
    public interface IConnectionManager
    {
        IConnectionClient Register(Tcr tcr);
        IConnectionClient Unregister(Tcr tcr);
        IConnectionClient GetConnectionClient(Tcr tcr);
    }
}
