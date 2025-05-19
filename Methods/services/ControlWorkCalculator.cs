using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Methods.services
{
    // Завдання 2.5
    public class ControlWorkCalculator
    {
        public void CalculateControlWork(in int[] grades,
        out int maxResults, out int midResults, out int minResults,
        out int max, out int min, out int average)
        {
            CheckArrayLenght(grades);
            CalculateAverage(grades, out average);
            FindResults(grades, out maxResults, out midResults, out minResults);
            FindMinMaxValueParallel(grades, out max, out min);
        }

        private bool IsValInRange(int val)
        {
            return val >= 0 && val <= 100;
        }

        private void CheckArrayLenght(in int[] arr)
        {
            if (arr.Length == 0)
            {
                throw new ArgumentException("Array has invalid leght");
            }
        }

        private void CalculateAverage(int[] arr, out int average)
        {
            int sum = 0;
            Array.ForEach(arr, i => sum += i);
            average = sum / arr.Length;
        }

        private void FindResults(int[] arr, out int max, out int mid, out int min)
        {
            max = 0;
            mid = 0;
            min = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= 90)
                {
                    max++;
                }
                else if (arr[i] >= 60)
                {
                    mid++;
                }
                else
                {
                    min++;
                }
            }
        }
        private void FindMinMaxValueParallel(int[] arr, out int max, out int min)
        {
            max = FindMinMaxValueParallel(arr, false);
            min = FindMinMaxValueParallel(arr, true);
        }

        private int FindMinMaxValueParallel(int[] arr, bool isMin)
        {
            if (arr.Length == 1)
            {
                return arr[0];
            }

            int numTasks = (arr.Length + 1) / 2;
            Task[] tasks = new Task[numTasks];

            int[] results = new int[numTasks];

            for (int i = 0; i < tasks.Length; i++)
            {
                int j = i;
                tasks[i] = Task.Run(() =>
                {
                    try
                    {
                        int first = arr[j * 2];
                        int second = (j * 2 + 1 < arr.Length) ? arr[j * 2 + 1] : first;
                        if (isMin)
                        {
                            results[j] = FindMin(first, second);
                        }
                        else
                        {
                            results[j] = FindMax(first, second);
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                });
            }

            Task.WaitAll(tasks);

            return FindMinMaxValueParallel(results, isMin);
        }

        private int FindMin(int a, int b)
        {
            return a < b ? a : b;
        }

        private int FindMax(int a, int b)
        {
            return a > b ? a : b;
        }
    }
}