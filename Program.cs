using System;

namespace Coding_Problems
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = LongestCommonSubseq.Compute("ABBA", "AA");
            Console.WriteLine(string.Join("\n", result));
            Console.WriteLine();

            result = LongestCommonSubseq.Compute("AGCAT", "GAC");
            Console.WriteLine(string.Join("\n", result));
            Console.WriteLine();

            result = LongestCommonSubseq.Compute("GXTXAYB", "AGGTAB");
            Console.WriteLine(string.Join("\n", result));
            Console.WriteLine();
        }
    }
}
