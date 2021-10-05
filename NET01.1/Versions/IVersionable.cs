using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._1.Versions
{
    interface IVersionable
    {
        byte [] GetVersion();
        void SetVersion(byte [] version);
    }
}
