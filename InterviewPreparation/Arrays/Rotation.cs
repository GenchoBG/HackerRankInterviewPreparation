using System;
using System.Linq;
using System.Text;

namespace Arrays
{
    //https://www.hackerrank.com/challenges/ctci-array-left-rotation/problem
    public class Rotation
    {
        public static void Main()
        {
            var firstLineData = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var elementsCount = firstLineData[0];
            var rotationsCount = firstLineData[1];

            var array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var start = rotationsCount % elementsCount;

            var sb = new StringBuilder();

            for (int i = start; i < start + elementsCount; i++)
            {
                sb.Append(array[i % elementsCount]);
                sb.Append(" ");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
