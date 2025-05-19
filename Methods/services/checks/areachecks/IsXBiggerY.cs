using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Methods.services.checks
{
    public class IsXBiggerY : Check
    {
        public void Check(ref double x, ref double y)
        {
            if (x < y){
                double t = x;
                x = y;
                y = t;
                System.Console.WriteLine("Swapped Values of Length and Width");
            }
        }
    }
}