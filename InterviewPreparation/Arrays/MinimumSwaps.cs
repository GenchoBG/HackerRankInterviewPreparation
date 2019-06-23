using System;
using System.Collections.Generic;
using System.Linq;

namespace Arrays
{
    //https://www.hackerrank.com/challenges/minimum-swaps-2/problem
    public class MinimumSwaps
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var input = Console.ReadLine();

            var arr = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var sorted = arr.OrderBy(a => a).ToArray();


            var dict = new Dictionary<int, int>();

            for (int index = 0; index < arr.Length; index++)
            {
                dict.Add(arr[index], index);
            }

            var swaps = 0;

            for (int index = 0; index < arr.Length; index++)
            {
                if (arr[index] != sorted[index])
                {
                    var rightIndex = dict[sorted[index]];
                    dict[arr[rightIndex]] = index;
                    dict[arr[index]] = rightIndex;

                    Swap(arr, index, rightIndex);

                    swaps++;
                }
            }

            Console.WriteLine(swaps);
        }

        private static void Swap(int[] arr, int first, int second)
        {
            var temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }
    }
}
