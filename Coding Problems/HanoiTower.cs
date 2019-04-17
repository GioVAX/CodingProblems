using System.Collections.Generic;
using System.Linq;

namespace Coding_Problems
{
    public class HanoiTower
    {
        public static List<string> Solve(int disks)
        {
            var moves = new IEnumerable<string>[disks + 1, 3];
            moves[0, 0] = new List<string>();
            moves[0, 1] = new List<string>();
            moves[0, 2] = new List<string>();

            for (int d = 1; d < disks + 1; d++)
                for (var p = 0; p < 3; ++p)
                    moves[d, p] = moves[d - 1, (p + d + 1) % 3].Append($"Disk {d} from {p} to {p + 1}");

            return moves[disks,0].ToList();
        }
    }
}