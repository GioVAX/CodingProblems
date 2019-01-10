using System;

namespace Coding_Problems
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join( "\n", LongestCommonSubseq.Compute( "ABBA", "AA")));
        }
    }
}
