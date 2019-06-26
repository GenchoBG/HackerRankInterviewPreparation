using System;
using System.Collections.Generic;
using System.Linq;

namespace DictionariesHashmaps
{
    //https://www.hackerrank.com/challenges/sherlock-and-anagrams/problem
    public class SherlockAnagrams
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var current = Console.ReadLine();

                var count = 0;

                for (int start = 0; start < current.Length; start++)
                {
                    for (int end = start + 1; end < current.Length; end++)
                    {
                        count += Anagrams(current, start, end);
                    }
                }

                Console.WriteLine(count);
            }
        }

        private static int Anagrams(string source, int start, int end)
        {
            var result = 0;

            var dict = new Dictionary<char, int>();
            for (char c = 'a'; c <= 'z'; c++)
            {
                dict[c] = 0;
            }

            for (int length = 0; end + length < source.Length; length++)
            {
                var left = source[start + length];
                var right = source[end + length];

                dict[left]++;
                dict[right]--;

                if (dict.Values.All(v => v == 0))
                {
                    result++;
                }
            }

            return result;
        }
    }
}
