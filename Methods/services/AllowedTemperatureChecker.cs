using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Methods.services
{
    // Завдання 1.3
    public class AllowedTemperatureChecker
    {
        public bool CheckTemp(double currentTemp, ref double minTemp, ref double maxTemp)
        {
            CheckCorrectMinMaxVal(ref minTemp, ref maxTemp);
            CheckValuesNegative(ref minTemp, ref maxTemp);
            CheckValueZero(ref currentTemp);
            CheckValueZero(ref minTemp);
            CheckValueZero(ref maxTemp);
            bool result = CheckInRange(currentTemp, minTemp, maxTemp);
            if (result)
            {
                System.Console.WriteLine("Temperature is in acceptable range");
                return result;
            }
            System.Console.WriteLine("Temperature is beyond accepatble range");
            return result;
        }

        private bool CheckInRange(double val, double min, double max)
        {
            CheckCorrectMinMaxVal(ref min, ref max);
            return val > min && val < max;
        }

        private void CheckCorrectMinMaxVal(ref double min, ref double max)
        {
            if (Math.Abs(min) > Math.Abs(max))
            {
                double t = min;
                min = max;
                max = t;
                System.Console.WriteLine("Min and max values has been swapped");
            }
        }

        private void CheckValuesNegative(ref double x, ref double y)
        {
            if (x < 0)
            {
                x = -x;
                System.Console.WriteLine("Made value of min positive");
            }
            if (y < 0)
            {
                y = -y;
                System.Console.WriteLine("Made value of max positive");
            }
        }

        private void CheckValueZero(ref double x)
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