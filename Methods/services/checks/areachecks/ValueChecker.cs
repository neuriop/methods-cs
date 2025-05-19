using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Methods.services.checks
{
    public class ValueChecker
    {
        private List<Check> checks = new List<Check>();

        public ValueChecker()
        {

        }

        public void CheckAll(ref double x, ref double y)
        {
            foreach (var i in checks)
            {
                i.Check(ref x, ref y);
            }
        }
        public void AddCheck(Check check)
        {
            checks.Add(check);
        }

        public void RemoveCheck(Check check)
        {
            checks.Remove(check);
        }

        public List<Check> GetAllChecks(){
            return checks;
        }
    }
}