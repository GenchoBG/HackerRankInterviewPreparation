using System;
using System.Collections.Generic;
using System.Linq;

namespace DictionariesHashmaps
{
    //https://www.hackerrank.com/challenges/count-triplets-1/problem
    public class CountTriplets
    {
        public static void Main()
        {
            var firstLineData = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var n = firstLineData[0];
            var ratio = firstLineData[1];

            var array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var numsIndexes = new Dictionary<int, ICollection<int>>();

            for (var i = 0; i < array.Length; i++)
            {
                var num = array[i];

                if (!numsIndexes.ContainsKey(num))
                {
                    numsIndexes[num] = new SortedSet<int>();
                }

                numsIndexes[num].Add(i);
            }

            var sum = 0L;

            foreach (var kvp in numsIndexes)
            {
                var num = kvp.Key;
                var indexes = kvp.Value;

                var prev = num / ratio;
                var next = num * ratio;

                if (prev * ratio == num && numsIndexes.TryGetValue(next, out var nextIndexes) && numsIndexes.TryGetValue(prev, out var prevIndexes))
                {
                    var prevIndexesCount = 0L;
                    var nextIndexesCount = 0L;

                    var prevIndexesList = prevIndexes.ToList();
                    var nextIndexesList = nextIndexes.ToList();
                    var prevIndex = 0;
                    var nextIndex = nextIndexesList.Count - 1;

                    var firstIndex = indexes.First();
                    while (prevIndex < prevIndexesList.Count && prevIndexesList[prevIndex] < firstIndex)
                    {
                        prevIndexesCount++;
                        prevIndex++;
                    }
                    while (nextIndex >= 0 && nextIndexesList[nextIndex] > firstIndex)
                    {
                        nextIndexesCount++;
                        nextIndex--;
                    }
                    if (ratio != 1)
                    {
                        nextIndex++;
                    }

                    foreach (var index in indexes)
                    {
                        while (prevIndex < prevIndexesList.Count && prevIndexesList[prevIndex] < index)
                        {
                            prevIndexesCount++;
                            prevIndex++;
                        }
                        while (nextIndex >= 0 && nextIndex < nextIndexesList.Count && nextIndexesList[nextIndex] < index)
                        {
                            nextIndexesCount--;
                            nextIndex++;
                        }


                        sum += prevIndexesCount * nextIndexesCount;
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
