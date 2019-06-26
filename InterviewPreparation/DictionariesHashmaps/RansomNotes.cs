using System;
using System.Collections.Generic;
using System.Linq;

namespace DictionariesHashmaps
{
    //https://www.hackerrank.com/challenges/ctci-ransom-note/problem
    public class RansomNotes
    {
        public static void Main()
        {
            var firstLineData = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var magazineCount = firstLineData[0];
            var noteCount = firstLineData[1];

            var magazine = new List<string>(Console.ReadLine().Split());
            var note = new List<string>(Console.ReadLine().Split());

            var magazineDict = new Dictionary<string, int>();
            foreach (var word in magazine)
            {
                magazineDict.TryGetValue(word, out var current);

                magazineDict[word] = current + 1;
            }

            var result = true;
            foreach (var word in note)
            {
                if (magazineDict.TryGetValue(word, out var count))
                {
                    if (count == 0)
                    {
                        result = false;
                    }
                    else
                    {
                        magazineDict[word]--;
                    }
                }
                else
                {
                    result = false;
                }
            }

            Console.WriteLine(result ? "Yes" : "No");
        }
    }
}
