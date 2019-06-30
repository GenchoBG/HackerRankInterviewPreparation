using System;
using System.Linq;

namespace Sorting
{
    //https://www.hackerrank.com/challenges/ctci-bubble-sort/problem
    public class CountSortSwaps
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var swaps = CountSwaps(arr, n);

            Console.WriteLine($"Array is sorted in {swaps} swaps.");
            Console.WriteLine($"First Element: {arr[0]}");
            Console.WriteLine($"Last Element: {arr[n - 1]}");
        }

        private static int CountSwaps(int[] arr, int n)
        {
            var swaps = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        swaps++;
                        Swap(ref arr[j], ref arr[j + 1]);
                    }
                }
            }

            return swaps;
        }

        private static void Swap(ref int i, ref int i1)
        {
            var temp = i;
            i = i1;
            i1 = temp;
        }
    }
}
