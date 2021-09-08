using System.Collections.Generic;
using System.Linq;

namespace Lib
{
    /// <summary>
    /// In an array of integers, give the starting index of the largest series of identical consecutive numbers Ex: [1,0,1,1,1,0,0,1,0,0) => 2
    /// If there is many largest series with the same length give the smallest starting index. For null or empty array, return -1.
    /// </summary>
    public static class Kata01
    {
        public static int FindStartingIndex(int[] array)
        {
            if (array is null || array.Length == 0)
            {
                return -1;
            }

            if (array.Length == 2)
            {
                return 0;
            }

            var store = new Dictionary<int, List<Series>>
            {
                [array[0]] = new List<Series>
                {
                    new Series(0, array[0])
                }
            };

            for (var i = 1; i < array.Length; i++)
            {
                var currentNumber = array[i];
                var previousNumber = array[i-1];

                if (!store.ContainsKey(currentNumber))
                {
                    var series = new Series(i, currentNumber);
                    store.Add(series.Number, new List<Series> { series });
                }
                else
                {
                    if (currentNumber == previousNumber)
                    {
                        var series = store[currentNumber].Last();
                        series.Length++;
                    }
                    else
                    {
                        var series = new Series(i, currentNumber);
                        store[currentNumber].Add(series);
                    }
                }
            }

            var startingIndex = store.Values
                .SelectMany(x => x)
                .OrderByDescending(x => x.Length)
                .ThenBy(x => x.StartingIndex)
                .First()
                .StartingIndex;

            return startingIndex;
        }

        internal class Series
        {
            public int StartingIndex { get; }
            public int Number { get; }
            public int Length { get; set; }

            public Series(int index, int number)
            {
                StartingIndex = index;
                Number = number;
                Length = 1;
            }
        }
    }
}
