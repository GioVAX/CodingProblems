using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Coding_Problems
{
    public class FindClosest
    {
        // Find K Closest Points to the Origin
        // Given a list of points on the 2-D plane and an integer K. The task is to find K closest points to the origin and print them.

        public static List<Point> Find(List<Point> points, int k)
        {
            var split = SplitPoints(points.Skip(1), points[0]);
            if (split.Key.Count == k - 1)
                return split.Key.Append(points[0]).ToList();

            if (split.Key.Count == k)
                return split.Key;

            if (split.Key.Count > k)
                return Find(split.Key, k);

            return split.Key.Append(points[0]).Union(Find(split.Value, k - split.Key.Count - 1)).ToList();
        }

        private static KeyValuePair<List<Point>, List<Point>> SplitPoints(IEnumerable<Point> points, Point reference)
        {
            var lower = new List<Point>();
            var higher = new List<Point>();

            var refValue = Math.Pow(reference.X, 2) + Math.Pow(reference.Y, 2);
            foreach (var pnt in points)
                if (Math.Pow(pnt.X, 2) + Math.Pow(pnt.Y, 2) > refValue)
                    higher.Add(pnt);
                else
                    lower.Add(pnt);

            return new KeyValuePair<List<Point>, List<Point>>(lower, higher);
        }
    }
}