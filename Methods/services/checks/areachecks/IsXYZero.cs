using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Methods.services.checks
{
    public class IsXYZero : Check
    {
        public void Check(ref double x, ref double y)
        {
            if (x == 0)
            {
                throw new ArgumentException("Lengh value is 0");
            }
            else if (y == 0)
            {
                throw new ArgumentException("Wifht value is 0");
            }
        }
    }
}