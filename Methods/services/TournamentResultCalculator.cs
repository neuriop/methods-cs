using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Methods.services
{
    // Завдання 2.2
    public class TournamentResultCalculator
    {

        public TournamentResultCalculator()
        {

        }

        public void AnaliseTournament(in int[] time,
        out int less60, out int between60n120, out int more120,
        out int min, out int max, out int average)
        {
            (less60, between60n120, more120) = GetSpecificTime(time);
            GetMinMax(time, out min, out max);
            average = GetAverage(time);
        }

        private (int less60, int between60n120, int more120) GetSpecificTime(in int[] time)
        {
            int less60 = 0;
            int between60n120 = 0;
            int more120 = 0;
            foreach (var i in time)
            {
                if (i <= 60)
                {
                    less60++;
                }
                else
                if (i > 60 && i <= 120)
                {
                    between60n120++;
                }
                else
                {
                    more120++;
                }
            }
            return (less60, between60n120, more120);
        }

        private void GetMinMax(in int[] time, out int min, out int max)
        {
            min = time[0];
            max = time[0];
            foreach (var i in time)
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
        }

        private int GetAverage(in int[] time)
        {
            int sum = 0;
            foreach (var i in time)
            {
                sum += i;
            }
            return sum / time.Length;
        }
    }
}