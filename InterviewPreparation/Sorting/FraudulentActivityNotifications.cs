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

            var days = Console.ReadLine().Split().Select(double.Parse).ToArray();

            var orderedDays = days.OrderBy(d => d).ToArray();

            var count = 0;

            for (int day = trailing; day < days.Length; day++)
            {
                if (days[day] < orderedDays[day])
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
