using System;
using System.Linq;

namespace Arrays
{
    //https://www.hackerrank.com/challenges/crush/problem
    public class ArrayManipulations
    {
        public static void Main()
        {
            var firstLineData = Console.ReadLine().Split().Select(long.Parse).ToArray();

            var elementsCount = firstLineData[0];
            var operationsCount = firstLineData[1];

            var arr = new long[elementsCount + 1];
            var indexAdds = new long[elementsCount + 1];
            var indexRemoves = new long[elementsCount + 1];

            for (int i = 0; i < operationsCount; i++)
            {
                var operationData = Console.ReadLine().Split().Select(long.Parse).ToArray();

                var left = operationData[0];
                var right = operationData[1];
                var add = operationData[2];

                indexAdds[left] += add;
                indexRemoves[right] += add;
            }

            var value = 0L;
            for (int i = 0; i < arr.Length; i++)
            {
                value += indexAdds[i];

                arr[i] += value;

                value -= indexRemoves[i];
            }

            //Console.WriteLine(string.Join(" ", arr.Skip(1)));
            Console.WriteLine(arr.Max());
        }
    }
}
