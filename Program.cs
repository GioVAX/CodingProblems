﻿using System;
using System.Linq;

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

            Console.WriteLine("------------------------------");
            Console.WriteLine();

            Console.WriteLine(SplitArrayEqualSum.Split(new int[] { -1, 6, 3, 1, -2, 3, 3 }, 7).ToString());
            Console.WriteLine();

            Console.WriteLine("------------------------------");
            Console.WriteLine();

            var weights = new int[] { 1, 2, 3,  8,  7,  4 };
            var values = new int[] { 20, 5, 10, 40, 15, 25 };
            Console.WriteLine(Knapsack.ComputeValue(values, weights, 6, 10));


            Console.WriteLine("------------------------------");
            Console.WriteLine();

            var changes = CoinChange.GetChanges( 1, new int[] { 1, 2, 5, 10 }, 4 ).ToList();
            changes.ForEach( s => Console.WriteLine( string.Join( ", ", s.Select( i => i.ToString()))));
            Console.WriteLine();

            changes = CoinChange.GetChanges( 2, new int[] { 1, 2, 5, 10 }, 4 ).ToList();
            changes.ForEach( s => Console.WriteLine( string.Join( ", ", s.Select( i => i.ToString()))));
            Console.WriteLine();

            changes = CoinChange.GetChanges( 11, new int[] { 1, 2, 5, 10 }, 4 ).ToList();
            changes.ForEach( s => Console.WriteLine( string.Join( ", ", s.Select( i => i.ToString()))));
            Console.WriteLine();

        }
    }
}
