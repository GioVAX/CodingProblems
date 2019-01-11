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
            var items = values.Zip(weights, (v, w) => new Item() { Value = v, Weight = w });

            // return _MaxValueRecursively(items, weightLimit, sack);
            var sackDP = _SackDynProg(items.ToList(), weightLimit);
            return sackDP.Sum(i => i.Value);
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

        private static int Value(IEnumerable<Item> sack) => sack.Sum(i => i.Value);

        private static IEnumerable<Item> _SackDynProg(List<Item> items, int weightLimit)
        {
            var cells = new IEnumerable<Item>[weightLimit + 1, items.Count() + 1];

            for (int w = 0; w < weightLimit + 1; w++)
                for (int i = 0; i < items.Count() + 1; i++)
                {
                    
                    if (w == 0 || i == 0) {
                        cells[w, i] = new List<Item>();
                        continue;
                    }

                    var item = items[i - 1];

                    if (item.Weight > w)  // This item is bigger than the sack
                        cells[w, i] = cells[w, i - 1];
                    else
                    {
                        var sackWithout = cells[w, i - 1];
                        var sackWith = cells[w - item.Weight, i - 1];

                        cells[w, i] = Value(sackWith) + item.Value > Value(sackWithout) ?
                             sackWith.Append(item) :
                             sackWithout;
                    }
                }

            return cells[weightLimit, items.Count()];
        }
    }
}