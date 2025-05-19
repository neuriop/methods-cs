using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Methods.services.checks;

namespace Methods.services
{
    // Завдання 1.1
    public class RectangleAreaService
    {
        private ValueChecker checker;
        public RectangleAreaService()
        {
            checker = new ValueChecker();
            AddChecks();
        }

        public double CalculateArea(ref double legth, ref double width)
        {
            checker.CheckAll(ref legth, ref width);
            return legth * width;
        }

        private void AddChecks()
        {
            checker.AddCheck(new IsValNegative());
            checker.AddCheck(new IsXBiggerY());
            checker.AddCheck(new IsXYZero());
        }
    }
}