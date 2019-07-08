using System;
using System.Linq;

namespace Greedy
{
    //https://www.hackerrank.com/challenges/luck-balance/problem
    public class LuckBalance
    {
        public static void Main()
        {
            var firstLineData = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var n = firstLineData[0];
            var k = firstLineData[1];

            var luck = new int[n];
            var importance = new int[n];

            for (int i = 0; i < n; i++)
            {
                var data = Console.ReadLine().Split().Select(int.Parse).ToArray();

                luck[i] = data[0];
                importance[i] = data[1];
            }

            var maxLuck = 0;

            var importants = luck.Where((value, index) => importance[index] == 1).OrderByDescending(l => l).ToList();
            var nonImportants = luck.Where((value, index) => importance[index] == 0).ToList();

            maxLuck += nonImportants.Sum();
            maxLuck += importants.Take(k).Sum();
            maxLuck -= importants.Skip(k).Sum();

            Console.WriteLine(maxLuck);
        }
    }
}
