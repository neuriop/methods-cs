using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Methods.services
{
    // Завдання 2.1
    public class TemperatureChecker
    {

        public TemperatureChecker()
        {

        }
        public void AnaliseTemaperature(in double[] temp,
        out double min, out double max,
        out int negative, out int positive, out double average)
        {
            (min, max) = GetMinMax(temp);
            (negative, positive) = GetNegPos(temp);
            average = CalculateAverage(temp);
        }

        private double CalculateAverage(in double[] temp)
        {
            double sum = 0;
            Array.ForEach(temp, (i) => sum += i);
            return sum / temp.Length;
        }

        private (int negative, int positive) GetNegPos(in double[] temp)
        {
            int negative = 0;
            int positive = 0;
            foreach (var i in temp)
            {
                if (i > 0)
                {
                    positive++;
                }
                if (i < 0)
                {
                    negative++;
                }
            }
            return (negative, positive);
        }

        private (double min, double max) GetMinMax(in double[] temp)
        {
            double min = temp[0];
            double max = temp[0];
            foreach (var i in temp)
            {
                if (i < min)
                {
                    min = i;
                }
                if (i > max)
                {
                    max = i;
                }
            }
            return (min, max);
        }
    }
}