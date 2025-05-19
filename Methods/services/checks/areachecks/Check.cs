using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Methods.services.checks
{
    public interface Check
    {
        void Check(ref double x, ref double y);
    }
}