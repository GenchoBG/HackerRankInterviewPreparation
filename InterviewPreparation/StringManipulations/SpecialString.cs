using System;
using System.Collections.Generic;
using System.Linq;

namespace StringManipulations
{
    //https://www.hackerrank.com/challenges/special-palindrome-again/problem
    public class SpecialString
    {
        private class Occurence
        {
            public Occurence(char character, int count)
            {
                this.Character = character;
                this.Count = count;
            }

            public char Character { get; set; }

            public int Count { get; set; }
        }

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var input = Console.ReadLine();

            var occurencies = new List<Occurence>();

            var count = 0;

            for (int i = 0; i < n; i++)
            {
                var current = input[i];

                if (i == 0 || current != input[i - 1])
                {
                    occurencies.Add(new Occurence(current, 1));
                }
                else
                {
                    occurencies.Last().Count++;
                }

                count += occurencies.Last().Count;
            }

            for (int i = 1; i < occurencies.Count - 1; i++)
            {
                if (occurencies[i].Count == 1 && occurencies[i - 1].Character == occurencies[i + 1].Character)
                {
                    count += Math.Min(occurencies[i - 1].Count, occurencies[i + 1].Count);
                }
            }

            Console.WriteLine(count);
        }
    }
}
