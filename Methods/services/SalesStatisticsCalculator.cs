using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Methods.services
{
    // Завдання 2.3
    public class SalesStatisticsCalculator
    {
        public void CalculateWeeklySales(in double[] sales,
        out int maxSales, out int midSales, out int minSales,
        out double max, out double min, out double average)
        {
            CheckArrayValid(sales);
            FindSales(sales, out minSales, out midSales, out maxSales);
            FindMinMaxSale(sales, out min, out max);
            CalculateAverage(sales, out average);
        }

        private void CheckArrayValid(in double[] arr)
        {
            if (arr.Length != 7)
            {
                throw new ArgumentOutOfRangeException("Array length is not equal to 7");
            }
        }

        private void FindSales(in double[] arr, out int minSales, out int midSales, out int maxSales)
        {
            minSales = 0;
            midSales = 0;
            maxSales = 0;
            foreach (var i in arr)
            {
                if (i < 1000)
                {
                    minSales++;
                }
                else if (i <= 5000)
                {
                    midSales++;
                }
                else
                {
                    maxSales++;
                }
            }
        }

        private void FindMinMaxSale(in double[] arr, out double min, out double max)
        {
            min = arr[0];
            max = arr[0];
            foreach (var i in arr)
            {
                if (min > i)
                {
                    min = i;
                }
                if (max < i)
                {
                    max = i;
                }
            }
        }

        private void CalculateAverage(in double[] arr, out double average)
        {
            double sum = 0;
            Array.ForEach(arr, (i) => sum += i);
            average = sum / arr.Length;
        }
    }
}