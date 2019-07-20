using System;
using System.Linq;

namespace Search
{
    //https://www.hackerrank.com/challenges/ctci-ice-cream-parlor/problem
    public class IceCreamParlor
    {
        public static void Main()
        {
            var t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                var money = int.Parse(Console.ReadLine());
                var n = int.Parse(Console.ReadLine());
                var costsList = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                var costsDict = costsList.GroupBy(num => num).ToDictionary(g => g.Key, g => g.Count());

                foreach (var costKvp in costsDict)
                {
                    var cost = costKvp.Key;
                    var count = costKvp.Value;

                    var leftover = money - cost;
                    if (leftover == cost && count > 1 || leftover != cost && costsDict.TryGetValue(leftover, out var _))
                    {
                        var costIndex = costsList.IndexOf(cost);
                        var leftoverIndex = costsList.IndexOf(leftover, costIndex + 1);

                        var bigger = Math.Max(costIndex, leftoverIndex);
                        var smaller = Math.Min(costIndex, leftoverIndex);

                        Console.WriteLine($"{smaller + 1} {bigger + 1}");

                        break;
                    }
                }
            }
        }
    }
}
