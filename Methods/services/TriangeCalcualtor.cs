using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Methods.services
{
    // Завдання 1.4
    public class TriangeCalcualtor
    {
        public double CalculateTrianglePerimeter(ref double a, ref double b, ref double c)
        {
            double[] d = [a, b, c];
            CheckPositive(d);
            a = d[0];
            b = d[1];
            c = d[2];
            if (IsTrianglePossible(a, b, c))
            {
                System.Console.WriteLine("Perimeter of triangle: " + (a + b + c));
                return a + b + c;
            }
            System.Console.WriteLine("Triangle is impossible to build");
            return -1;
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
        private bool IsTrianglePossible(double a, double b, double c)
        {
            return
                a + b > c &&
                a + c > b &&
                b + c > a;
        }
    }
}