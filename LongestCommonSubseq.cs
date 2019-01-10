using System.Collections.Generic;

namespace Coding_Problems
{
    public class LongestCommonSubseq
    {

        private static List<string> [][] memo;

        private static void InitMemo( int rows, int cols ) {
            memo = new List<string> [rows][];
            for (int r = 0; r < rows; ++r)
                memo[r] = new List<string>[cols];
        }


        public static IEnumerable<string> Compute( string s1, string s2) {
            
            InitMemo( s1.Length + 1, s2.Length + 1);
            
            



            return null;
        }
    }
}