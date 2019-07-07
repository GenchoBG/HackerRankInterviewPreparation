using System;
using System.Linq;

namespace Greedy
{
    //https://www.hackerrank.com/challenges/minimum-absolute-difference-in-an-array/problem
    public class MinimumDifference
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var elements = Console.ReadLine().Split().Select(int.Parse).OrderBy(e => e).ToArray();

            var min = int.MaxValue;
            for (int i = 0; i < n - 1; i++)
            {
                var current = Math.Abs(elements[i] - elements[i + 1]);

                if (current < min)
                {
                    min = current;
                }
            }

            Console.WriteLine(min);
        }
    }
}
