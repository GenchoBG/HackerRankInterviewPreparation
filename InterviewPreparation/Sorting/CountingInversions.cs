using System;
using System.Linq;

namespace Sorting
{
    //https://www.hackerrank.com/challenges/ctci-merge-sort/problem
    public class CountingInversions
    {
        public static void Main()
        {
            var d = int.Parse(Console.ReadLine());

            for (int i = 0; i < d; i++)
            {
                var n = int.Parse(Console.ReadLine());

                var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var swaps = MergeSort(arr, 0, n - 1);

                //Console.WriteLine(string.Join(" ", arr));
                Console.WriteLine(swaps);
            }
        }

        private static long MergeSort(int[] arr, int left, int right)
        {
            if (left >= right)
            {
                return 0;
            }

            var mid = (left + right) / 2;

            var leftResult = MergeSort(arr, left, mid);
            //Console.WriteLine($"MergeSort {left} {mid} -> {leftResult}");
            var rightResult = MergeSort(arr, mid + 1, right);
            //Console.WriteLine($"MergeSort {mid+1} {right} -> {rightResult}");


            return leftResult + rightResult + Merge(arr, left, mid, mid + 1, right);
        }

        private static long Merge(int[] arr, int leftStart, int leftEnd, int rightStart, int rightEnd)
        {
            var temp = new int[rightEnd - leftStart + 1];
            var swaps = 0L;

            var leftRead = leftStart;
            var rightRead = rightStart;
            var write = 0;

            while (leftRead <= leftEnd && rightRead <= rightEnd)
            {
                if (arr[rightRead] < arr[leftRead])
                {
                    temp[write++] = arr[rightRead++];
                    //swaps++; // += razlika
                    swaps += Math.Abs(leftEnd - leftRead + 1);
                }
                else
                {
                    temp[write++] = arr[leftRead++];
                }
            }

            while (leftRead <= leftEnd)
            {
                temp[write++] = arr[leftRead++];
            }

            while (rightRead <= rightEnd)
            {
                temp[write++] = arr[rightRead++];
            }

            for (int read = 0, arrWrite = leftStart; read < temp.Length; read++, arrWrite++)
            {
                arr[arrWrite] = temp[read];
            }

            return swaps;
        }
    }
}
