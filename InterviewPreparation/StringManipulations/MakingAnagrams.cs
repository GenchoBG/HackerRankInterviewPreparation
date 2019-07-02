using System;
using System.Collections.Generic;
using System.Linq;

namespace StringManipulations
{
    //https://www.hackerrank.com/challenges/ctci-making-anagrams/problem
    public class MakingAnagrams
    {
        public static void Main(string[] args)
        {
            var first = Console.ReadLine();
            var second = Console.ReadLine();

            var firstChars = first.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            var secondChars = second.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

            var count = 0;

            var chars = firstChars.Keys.ToList();
            chars.AddRange(secondChars.Keys);
            chars = chars.Distinct().ToList();

            for (int i = 0; i < chars.Count; i++)
            {
                var current = chars[i];

                if (firstChars.TryGetValue(current, out var firstCount) &&
                    secondChars.TryGetValue(current, out var secondCount))
                {
                    count += Math.Abs(firstCount - secondCount);
                }
                else if(firstChars.TryGetValue(current, out firstCount))
                {
                    count += firstCount;
                }
                else if (secondChars.TryGetValue(current, out secondCount))
                {
                    count += secondCount;
                }
            }

            Console.WriteLine(count);
        }
    }
}
