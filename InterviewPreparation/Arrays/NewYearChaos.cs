using System;
using System.Linq;

namespace Arrays
{
    //https://www.hackerrank.com/challenges/new-year-chaos/problem
    public class NewYearChaos
    {
        public static void Main()
        {
            var t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                var n = int.Parse(Console.ReadLine());
                var people = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var chaotic = false;
                var swaps = 0;

                for (int index = people.Length - 1; index > 0; index--)
                {
                    var indexNumber = index + 1;
                    var current = people[index];

                    if (current != indexNumber)
                    {
                        if (index - 1 >= 0 && people[index - 1] == indexNumber)
                        {
                            Swap(people, index - 1, index);
                            swaps += 1;
                        }
                        else if (index - 2 >= 0 && people[index - 2] == indexNumber)
                        {
                            Swap(people, index - 2, index - 1);
                            Swap(people, index - 1, index );
                            swaps += 2;
                        }
                        else
                        {
                            chaotic = true;
                            break;
                        }
                    }
                }

                Console.WriteLine(chaotic ? "Too chaotic" : swaps.ToString());
            }
        }

        private static void Swap(int[] arr, int first, int second)
        {
            var temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }
    }
}
