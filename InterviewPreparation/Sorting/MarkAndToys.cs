using System;
using System.Linq;

namespace Sorting
{
    //https://www.hackerrank.com/challenges/mark-and-toys/problem
    public class MarkAndToys
    {
        public static void Main()
        {
            var firstLineData = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var n = firstLineData[0];
            var budget = firstLineData[1];

            var prices = Console.ReadLine().Split().Select(int.Parse).OrderBy(p => p).ToArray();

            var count = 0;
            while (budget > 0)
            {
                budget -= prices[count];
                count++;
            }

            Console.WriteLine(count - 1);
        }
    }
}
