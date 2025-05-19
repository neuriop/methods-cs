using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Methods.services
{
    // Завдання 1.6
    public class TaxiPriceCalculator
    {
        public double CalculateTaxiPrice(ref double distance, ref double pricePerKm, ref double nightMultiplier)
        {
            nightMultiplier = nightMultiplier < 1 ? 1 : nightMultiplier;
            double[] d = [distance, pricePerKm, nightMultiplier];
            CheckPositive(d);
            distance = d[0];
            pricePerKm = d[1];
            nightMultiplier = d[2];
            return distance * pricePerKm * nightMultiplier;
        }

        private void CheckPositive(params double[] d)
        {
            for (int i = 0; i < d.Length; i++)
            {
                CheckPositive(x: ref d[i]);
            }
        }

        private void CheckPositive(ref double x)
        {
            if (x < 0)
            {
                System.Console.WriteLine($"Value {x} has been negated");
                x = -x;
            }
            else if (x == 0)
            {
                EnterPositiveValue(ref x);
            }
        }

        private void EnterPositiveValue(ref double x)
        {
            while (x <= 0)
            {
                try
                {
                    System.Console.WriteLine($"Entered value {x} is negative or zero. Enter new positive value:");
                    x = double.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    x = 0;
                }
            }
        }
    }
}