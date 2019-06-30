using System;
using System.Linq;

namespace Sorting
{
    //https://www.hackerrank.com/challenges/fraudulent-activity-notifications/problem
    public class FraudulentActivityNotifications
    {
        public static void Main()
        {
            var firstLineData = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var n = firstLineData[0];
            var trailing = firstLineData[1];

            var days = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var count = 0;

            var countingSort = new int[201];
            for (int i = 0; i < trailing; i++)
            {
                countingSort[days[i]]++;
            }

            var middleIndex = (trailing / 2) + 1;

            for (int day = trailing; day < days.Length; day++)
            {
                var median = FindAtIndex(countingSort, middleIndex);
                if (trailing % 2 == 0)
                {
                    median += FindAtIndex(countingSort, middleIndex - 1);
                    median /= 2;
                }

                var current = days[day];
                var last = days[day - trailing];

                if (current >= median * 2)
                {
                    count++;
                }

                countingSort[current]++;
                countingSort[last]--;
            }

            Console.WriteLine(count);
        }

        private static double FindAtIndex(int[] frequencies, int index)
        {
            var count = 0;

            for (int i = 0; ; i++)
            {
                count += frequencies[i];
                if (count >= index)
                {
                    return i;
                }
            }
        }
    }
}
