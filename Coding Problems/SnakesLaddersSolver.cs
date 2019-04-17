using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Coding_Problems
{
    public class SnakesLaddersSolver
    {
        public SnakesLaddersSolver()
        {
        }

        public int Solve(int[] destinations)
        {
            if (destinations == null)
                throw new ArgumentNullException(nameof(destinations));

            var throws = 0;
            var baseIndex = 0;
            var arrive = destinations.Length - 1;

            var normalized = destinations.Select((val, idx) => val == -1 ? idx : val).ToList();

            while (baseIndex != arrive)
            {
                if (baseIndex + 6 > arrive)
                    return throws + 1;

                baseIndex = normalized.Skip(baseIndex).Take(6).Max();
                ++throws;
            }

            return throws;

        }
    }
}