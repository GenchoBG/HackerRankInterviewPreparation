using System;
using System.Collections.Generic;
using System.Linq;

namespace DictionariesHashmaps
{
    //https://www.hackerrank.com/challenges/two-strings/problem
    public class TwoStrings
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var first = new HashSet<char>(Console.ReadLine().ToCharArray());
                var second = new HashSet<char>(Console.ReadLine().ToCharArray());

                Console.WriteLine(first.Any(c => second.Contains(c)) ? "YES" : "NO");
            }
        }
    }
}
