using System;
using System.Collections.Generic;
using System.Linq;

namespace Coding_Problems
{
    public class Knapsack
    {
        private class Item
        {
            public int Value;
            public int Weight;
        }

        private static int _ComputeValue(IEnumerable<Item> items, int weightLimit, List<Item> sack)
        {
            if (!items.Any())
                return sack.Sum(i => i.Value);

            var withoutThis = _ComputeValue(items.Skip(1), weightLimit, sack);

            var firstItem = items.First();

            if (firstItem.Weight > weightLimit)
                return withoutThis;

            return Math.Max(
                withoutThis,
                _ComputeValue(items.Skip(1), weightLimit - firstItem.Weight, sack.Append(firstItem).ToList()));
        }


        public static int ComputeValue(int[] values, int[] weights, int size, int weightLimit)
        {
            var sack = new List<Item>();
            var items = values.Zip( weights, (v, w) => new Item() { Value = v, Weight = w});

            return _ComputeValue(items, weightLimit, sack);
        }
    }
}