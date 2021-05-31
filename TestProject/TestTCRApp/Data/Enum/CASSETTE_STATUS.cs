using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geidea.TCR.Service.Data.Enum
{
    public enum CASSETTE_STATUS
    {
        CST_OK,
        CST_FULL,
        CST_HIGH,
        CST_LOW,
        CST_EMPTY,
        CST_MISSING,
        CST_FATAL,
        CST_NOVALUE,
        CST_NOREFERENCE,
        CST_MANIP,
        CST_UNKNOWN
    }
}
