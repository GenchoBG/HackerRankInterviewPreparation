using System;
using System.Linq;

namespace Greedy
{
    //https://www.hackerrank.com/challenges/reverse-shuffle-merge/problem
    public class ReverseShuffleMerge
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var originalIndex = input.Length - 1;
            var found = 0;

            var resultSize = input.Length / 2;
            var result = new char[resultSize];

            var dict = input.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count() / 2);

            while (originalIndex >= 0 && found < resultSize)
            {
                var best = (char)('z' + 1);
                var bestIndex = -1;
                var i = originalIndex;

                for (; i >= resultSize - found - 1 && i >= 0; i--)
                {
                    var current = input[i];
                    //check if it is smaller & if i need that character
                    if (current < best && dict[current] > 0)
                    {
                        //check if i can construct the string from the characters left
                        var dictCopy = dict.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                        for (int j = 0; j <= i; j++)
                        {
                            dictCopy[input[j]]--;
                        }
                        if (dictCopy.Values.Any(v => v > 0))
                        {
                            break;
                        }

                        best = current;
                        bestIndex = i;
                    }
                }

                result[found] = best;
                dict[best]--;
                found++;
                originalIndex = bestIndex - 1;
            }

            Console.WriteLine($"{string.Join("", result)}");
        }
    }
}
