using System;

namespace StringManipulations
{
    //https://www.hackerrank.com/challenges/common-child/problem
    public class CommonChild
    {
        public static void Main(string[] args)
        {
            var first = Console.ReadLine();
            var second = Console.ReadLine();

            Console.WriteLine(LongestCommonSubsequence(first, second));
        }

        private static int LongestCommonSubsequence(string first, string second)
        {
            var table = new int[first.Length][];
            for (int i = 0; i < table.Length; i++)
            {
                table[i] = new int[first.Length];
            }


            for (int i = 0; i < first.Length; i++)
            {
                for (int j = 0; j < first.Length; j++)
                {
                    if (first[i] == second[j])
                    {
                        if (i == 0 || j == 0)
                        {
                            table[i][j] = 1;
                        }
                        else
                        {
                            table[i][j] = table[i - 1][j - 1] + 1;
                        }
                    }
                    else
                    {
                        if (i == 0 && j == 0)
                        {
                            table[i][j] = 0;
                        }
                        else if (i == 0)
                        {
                            table[i][j] = table[i][j - 1];
                        }
                        else if (j == 0)
                        {
                            table[i][j] = table[i - 1][j];
                        }
                        else
                        {
                            table[i][j] = Math.Max(table[i][j - 1], table[i - 1][j]);
                        }
                    }
                }
            }

            return table[first.Length - 1][first.Length - 1];
        }
    }
}
