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
    }
}
