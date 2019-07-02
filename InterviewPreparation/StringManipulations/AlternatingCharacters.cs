using System;

namespace StringManipulations
{
    //https://www.hackerrank.com/challenges/alternating-characters/problem
    public class AlternatingCharacters
    {
        public static void Main()
        {
            var q = int.Parse(Console.ReadLine());

            for (int i = 0; i < q; i++)
            {
                var input = Console.ReadLine();

                var count = 0;

                for (int j = 1; j < input.Length; j++)
                {
                    if (input[j] == input[j - 1])
                    {
                        count++;
                    }
                }

                Console.WriteLine(count);
            }
        }
    }
}
