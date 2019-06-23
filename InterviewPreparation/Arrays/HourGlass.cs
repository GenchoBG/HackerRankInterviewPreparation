using System;
using System.Collections.Generic;
using System.Linq;

namespace Arrays
{
    //https://www.hackerrank.com/challenges/2d-array/problem
    public class HourGlass
    {
        public static void Main()
        {
            var size = 6;

            var arr = new int[size][];

            for (int i = 0; i < size; i++)
            {
                arr[i] = Console.ReadLine().Split(new char[]{}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            var maxes = new List<int>();

            for (int row = 1; row < size - 1; row++)
            {
                for (int col = 1; col < size - 1; col++)
                {
                    maxes.Add(GetHourglassSum(arr, row, col));
                }
            }

            Console.WriteLine(maxes.Max());
        }

        private static int GetHourglassSum(int[][] arr, int row, int col)
        {
            var sum = 0;

            sum += arr[row][col];
            sum += arr[row + 1][col - 1];
            sum += arr[row + 1][col];
            sum += arr[row + 1][col + 1];
            sum += arr[row - 1][col - 1];
            sum += arr[row - 1][col];
            sum += arr[row - 1][col + 1];

            return sum;
        }
    }
}
