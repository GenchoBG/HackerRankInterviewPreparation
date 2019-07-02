using System;
using System.Linq;

namespace StringManipulations
{
    //https://www.hackerrank.com/challenges/sherlock-and-valid-string/problem
    public class ValidStrings
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var occurences = input.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

            var values = occurences.Values.Distinct().ToList();

            // if all the characters occur equaly
            var isValid = values.Count == 1;

            if (values.Count == 2)
            {
                var first = values[0];
                var firstChars = occurences.Count(kvp => kvp.Value == first);
                var second = values[1];
                var secondChars = occurences.Count(kvp => kvp.Value == second);

                // if there is exactly 1 character occuring exactly 1 time more than the rest of the character
                if ((Math.Abs(first - second) == 1 && (firstChars == 1 || secondChars == 1)))
                {
                    isValid = true;
                }

                // if there is exactly 1 character occuring 1 time we can remove it
                if ((firstChars == 1 && first == 1) || (secondChars == 1 && second == 1))
                {
                    isValid = true;
                }
            }

            Console.WriteLine(isValid ? "YES" : "NO");
        }
    }
}
