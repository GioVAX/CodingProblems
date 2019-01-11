using System;
using System.Collections.Generic;
using System.Linq;

namespace Coding_Problems
{
    public class Knapsack
    {
        private class Sack
        {
            

            public int Value;
            public int Weigth;

            public Sack Add(int value, int weight) => new Sack() { Value = this.Value + value, Weigth = this.Weigth + weight };

        }

        private static int _ComputeValue(IEnumerable<int> values, IEnumerable<int> weights, int weightLimit, Sack sack)
        {
            if( !values.Any())
                return sack.Value;

            var withoutThis = _ComputeValue(values.Skip(1), weights.Skip(1), weightLimit, sack);

            var firstWeight = weights.First();

            if (firstWeight > weightLimit)
                return withoutThis;

            return Math.Max(
                withoutThis,
                _ComputeValue(values.Skip(1), weights.Skip(1), weightLimit - firstWeight, sack.Add(values.First(), firstWeight)));
        }


        public static int ComputeValue(int[] values, int[] weights, int size, int weightLimit)
        {
            var sack = new Sack() { Value = 0, Weigth = 0 };

            return _ComputeValue(values, weights, weightLimit, sack);
        }
    }
}