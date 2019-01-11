using System;
using System.Collections.Generic;
using System.Linq;

namespace Coding_Problems
{
    // Find Longest Common Subsequence | Finding all LCS

    public class LongestCommonSubseq
    {

        private static List<string>[][] memo;

        private static void InitMemo(int rows, int cols)
        {
            memo = new List<string>[rows][];
            for (int r = 0; r < rows; ++r)
                memo[r] = new List<string>[cols];

            var emptyList = new List<string>() {""};
            for (int r = 0; r < rows; r++)
                memo[r][0] = emptyList;

            for (int c = 0; c < cols; c++)
                memo[0][c] = emptyList;
        }


        public static IEnumerable<string> Compute(string s1, string s2)
        {
            var maxRow = s1.Length + 1;
            var maxCol = s2.Length + 1;
            InitMemo(maxRow, maxCol);

            var seqs = ComputeCommonSubseqs(s1.Length, s2.Length, s1, s2)
                        .OrderByDescending(s => s.Length);
            var len = seqs.First().Length;
            return seqs.TakeWhile( s => s.Length == len);
        }

        private static string RemoveLastChar(string s) => s.Substring(0, s.Length - 1);

        private static IEnumerable<string> ComputeCommonSubseqs(int row, int col, string s1, string s2)
        {
            if (memo[row][col] != null)
                return memo[row][col];

            var s1end = s1.Last();
            var s2end = s2.Last();

            var cellRes = s1end == s2end ?
                ComputeCommonSubseqs(row - 1, col - 1, RemoveLastChar(s1), RemoveLastChar(s2))
                                    .Select(s => s + s1end.ToString()) :
                ComputeCommonSubseqs(row - 1, col, RemoveLastChar(s1), s2)
                    .Union(ComputeCommonSubseqs(row, col - 1, s1, RemoveLastChar(s2)))
                    .Distinct();

            return memo[row][col] = cellRes.ToList();
        }
    }
}