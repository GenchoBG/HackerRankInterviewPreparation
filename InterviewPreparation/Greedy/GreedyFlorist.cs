using System;
using System.Linq;

namespace Greedy
{
    //https://www.hackerrank.com/challenges/greedy-florist/problem
    public class GreedyFlorist
    {
        public static void Main()
        {
            var firstLineData = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var flowers = firstLineData[0];
            var friends = firstLineData[1];

            var prices = Console.ReadLine().Split().Select(int.Parse).OrderBy(p => p).ToArray();

            var price = 0;
            var bought = 0;
            for (int i = flowers - 1; i >= 0;)
            {
                var currentlyBuying = friends;

                while (currentlyBuying > 0 && i >= 0)
                {
                    price += (bought + 1) * prices[i];
                    i--;
                    currentlyBuying--;
                }

                bought++;
            }

            Console.WriteLine(price);
        }
    }
}
