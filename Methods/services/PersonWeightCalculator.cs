using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Methods.services
{
    // Завдання 2.4
    public class PersonWeightCalculator
    {
        public struct PersonWeights
        {
            public double[] weights { get; set; }
            public int increased { get; set; }
            public int decreased { get; set; }
            public int notChanged { get; set; }
            public double maxIncrease { get; set; }
            public double maxDecrease { get; set; }
            public double average { get; set; }
        }
        public void CalculateWeight(in double[] weights, out PersonWeights personWeights)
        {
            int increased, decreased, notChanged;
            double maxIncrease, maxDecrease, average;
            CalculateChanges(weights, out increased, out decreased, out notChanged);
            CalculateMaxChanges(weights, out maxIncrease, out maxDecrease);
            CalculateAverage(weights, out average);
            personWeights = new PersonWeights
            {
                weights = weights,
                increased = increased,
                decreased = decreased,
                notChanged = notChanged,
                maxIncrease = maxIncrease,
                maxDecrease = maxDecrease,
                average = average
            };
        }

        private void CalculateChanges(in double[] weights, out int increased, out int decreased, out int notChanged)
        {
            increased = 0;
            decreased = 0;
            notChanged = 0;
            for (int i = 1; i < weights.Length; i++)
            {
                if (weights[i] > weights[i - 1])
                {
                    increased++;
                }
                else if (weights[i] < weights[i - 1])
                {
                    decreased++;
                }
                else
                {
                    notChanged++;
                }
            }
        }

        private void CalculateMaxChanges(in double[] weights, out double maxIncrease, out double maxDecrease)
        {
            maxIncrease = 0;
            maxDecrease = 0;
            for (int i = 1; i < weights.Length; i++)
            {
                if (weights[i] - weights[i - 1] < maxIncrease)
                {
                    maxIncrease = weights[i] - weights[i - 1];
                }
                else if (weights[i] - weights[i - 1] > maxDecrease)
                {
                    maxDecrease = weights[i] - weights[i - 1];
                }
            }
            maxIncrease = -maxIncrease;
            maxDecrease = -maxDecrease;
        }

        private void CalculateAverage(in double[] weights, out double average)
        {
            double sum = 0;
            Array.ForEach(weights, (i) => sum += i);
            average = sum / weights.Length;
        }
    }
}