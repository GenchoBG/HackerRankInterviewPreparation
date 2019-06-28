using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionariesHashmaps
{
    //https://www.hackerrank.com/challenges/frequency-queries/problem
    public class FrequencyQueries
    {
        public static void Main()
        {
            var q = int.Parse(Console.ReadLine());
            var elements = new Dictionary<int, int>();
            var frequencies = new Dictionary<int, int>();

            var sb = new StringBuilder();

            for (int i = 0; i < q; i++)
            {
                var query = Console.ReadLine().Split().Select(int.Parse).ToList();

                var type = query[0];
                var el = query[1];

                switch (type)
                {
                    case 1:
                        //insert
                        if (!elements.ContainsKey(el))
                        {
                            elements[el] = 0;
                        }
                        elements[el]++;

                        if (!frequencies.ContainsKey(elements[el]))
                        {
                            frequencies[elements[el]] = 0;
                        }

                        frequencies[elements[el]]++;

                        if (elements[el] != 1)
                        {
                            frequencies[elements[el] - 1]--;
                        }
                        break;

                    case 2:
                        //remove
                        if (elements.ContainsKey(el) && elements[el] > 0)
                        {
                            frequencies[elements[el]]--;
                            elements[el]--;
                            if (elements[el] != 0)
                            {
                                frequencies[elements[el]]++;
                            }
                        }
                        break;

                    case 3:
                        //check
                        sb.AppendLine(frequencies.ContainsKey(el) ? (frequencies[el] > 0 ? "1" : "0") : "0");
                        break;
                }
            }

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
