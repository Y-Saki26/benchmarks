using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Benchmark.Vectors
{
    internal static class VectorTExtends
    {

        public static float X(this Vector<float> @this) => @this[0];
        public static float Y(this Vector<float> @this) => @this[1];

        public static Vector<float> VecF2_UnitX() {
            var UnitX = new float[Vector<float>.Count];
            UnitX[0] = 1f;
            return new(UnitX);
        }

        public static Vector<float> VecF2_UnitY() {
            var UnitY = new float[Vector<float>.Count];
            UnitY[1] = 1f;
            return new(UnitY);
        }

        public static Vector<float> VecF2_One() {
            var One = new float[Vector<float>.Count];
            One[0] = 1f;
            One[1] = 1f;
            return new(One);
        }
        public static Vector<float> VecF2_UnitX_Solid() =>
            new(new float[] { 1f, 0f, 0f, 0f, 0f, 0f, 0f, 0f });

        public static Vector<float> VecF2_UnitY_Solid() =>
            new(new float[] { 0f, 1f, 0f, 0f, 0f, 0f, 0f, 0f });

        public static Vector<float> VecF2_One_Solid() =>
            new(new float[] { 1f, 1f, 0f, 0f, 0f, 0f, 0f, 0f });
    }
}
