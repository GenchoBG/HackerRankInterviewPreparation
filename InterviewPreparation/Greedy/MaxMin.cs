using System;
using System.Linq;

namespace Greedy
{
    //https://www.hackerrank.com/challenges/angry-children/problem
    public class MaxMin
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());
            var arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            arr = arr.OrderBy(num => num).ToArray();

            var minUnfairness = int.MaxValue;
            for (int i = 0; i <= n - k; i++)
            {
                var max = arr[i + k - 1];
                var min = arr[i];
                var unfairness = max - min;
                if (unfairness < minUnfairness)
                {
                    minUnfairness = unfairness;
                }
            }

            Console.WriteLine(minUnfairness);
        }
    }
}
