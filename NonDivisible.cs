using System.Collections.Generic;
using System.Linq;

namespace Coding_Problems
{
    public class NonDivisible
    {
        // Given a set of distinct integers, print the size of a maximal subset of  where the sum of any  numbers in  is not evenly divisible by K.

        public static IEnumerable<IEnumerable<int>> X(IEnumerable<int> set, int k)
        {
            var remainders = set.GroupBy(n => n % k).ToDictionary(g => g.Key);
            var res = new List<List<int>>();

            foreach (var item in remainders[0])
            {
                var l = new List<int>() { item };
                for (int i = 1; i <= k / 2 + 1; i++)
                    l.AddRange(remainders[i].Count() > remainders[k - i].Count() ? remainders[i] : remainders[k - i]);
                res.Add(l);
            }

            return res;
        }
    }
}