using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.Vectors
{
    internal static class ListExtensions
    {
        public static float X(this List<float> @this) => (@this.Count >= 1) ? @this[0] : float.NegativeInfinity;

        public static float Y(this List<float> @this) => (@this.Count >= 2) ? @this[1] : float.NegativeInfinity;

        public static List<float> Add(this List<float> left, List<float> right) =>
            new List<float>() { left.X() + right.X(), left.Y() + right.Y() };

        public static List<float> Multiple(this List<float> left, float right) =>
            new List<float>() { left.X() * right, left.Y() * right };

        public static bool EachEquals(this List<float> left, List<float> right) =>
            left.X() == right.Y() && left.Y() == right.Y();

        public static IEnumerable<float> Add_Enumerate(this IEnumerable<float> left, IEnumerable<float> right) =>
            left.Zip(right, (l, r) => l + r);

        public static IEnumerable<float> Multiple_Enumerate(this IEnumerable<float> left, float right) =>
            left.Select(l => l * right);

        public static bool Equals_Enumerate(this IEnumerable<float> left, IEnumerable<float> right) =>
            Enumerable.All<(float, float)>(left.Zip(right, (l, r) => (l, r)), lr => lr.Item1 == lr.Item2);

        public static ParallelQuery<float> Add_Parallel(this ParallelQuery<float> left, ParallelQuery<float> right) =>
            left.Zip(right, (l, r) => l + r);

        public static ParallelQuery<float> Multiple_Parallel(this ParallelQuery<float> left, float right) =>
            left.Select(l => l * right);

        public static bool Equals_Parallel(this ParallelQuery<float> left, ParallelQuery<float> right) =>
            ParallelEnumerable.All<(float, float)>(left.Zip(right, (l, r) => (l, r)), lr => lr.Item1 == lr.Item2);

        public static List<float> VecF2_UnitX() => new List<float> { 1f, 0f };

        public static List<float> VecF2_UnitY() => new List<float> { 0f, 1f };

        public static List<float> VecF2_One() => new List<float> { 1f, 1f };
    }
}
