using System.Collections.Generic;
using System.Linq;

namespace Coding_Problems
{
    public class CoinChange
    {
        // Given an unlimited supply of coins of given denominations, 
        // find the minimum number of coins required to get a desired change

        public static IEnumerable<IEnumerable<int>> GetChanges(int change, int[] denominations, int numDenominations)
        {
            var dp = new List<IEnumerable<int>>[change + 1];

            for (int c = 0; c <= change; c++)
            {
                dp[c] = new List<IEnumerable<int>> {};
                if (c == 0) continue;

                for (int d = 0; d < numDenominations; d++)
                {
                    if (denominations[d] > c)
                        continue;

                    if (denominations[d] == c)
                        dp[c].Add(new List<int>() { denominations[d] });
                    else
                        dp[c].AddRange(dp[c - denominations[d]].Select(comb => comb.Append(denominations[d])));
                }
            }

            return dp[change].OrderBy( ch => ch.Count());
        }
    }
}
