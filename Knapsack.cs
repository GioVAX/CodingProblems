using System;
using System.Collections.Generic;
using System.Linq;

namespace Coding_Problems
{
    public class Knapsack
    {
        public static int ComputeValue(int[] values, int[] weights, int size, int weightLimit)
        {
            var sack = new List<Item>();
            var items = values.Zip( weights, (v, w) => new Item() { Value = v, Weight = w});

            return _MaxValueRecursively(items, weightLimit, sack);
        }

        private class Item
        {
            public int Value;
            public int Weight;
        }

        private static int _MaxValueRecursively(IEnumerable<Item> items, int weightLimit, List<Item> sack)
        {
            if (!items.Any())
                return sack.Sum(i => i.Value);

            var withoutThis = _MaxValueRecursively(items.Skip(1), weightLimit, sack);

            var firstItem = items.First();

            if (firstItem.Weight > weightLimit)
                return withoutThis;

            return Math.Max(
                withoutThis,
                _MaxValueRecursively(items.Skip(1), weightLimit - firstItem.Weight, sack.Append(firstItem).ToList()));
        }
    }
}