using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Methods.services.checks
{
    public class IsValNegative : Check
    {
        public void Check(ref double x, ref double y)
        {
            if (x < 0)
            {
                x = Math.Abs(x);
                System.Console.WriteLine("Got absolute value of length");
            }
            if (y < 0)
            {
                y = Math.Abs(y);
                System.Console.WriteLine("Got absolute value of width");
            }
        }
    }
}