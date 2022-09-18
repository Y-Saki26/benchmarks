namespace Benchmark.Vectors
{
    internal static class ArrayExtensions
    {
        public static double X(this double[] @this) => (@this.Length >= 1) ? @this[0] : double.NegativeInfinity;
        public static double Y(this double[] @this) => (@this.Length >= 2) ? @this[1] : double.NegativeInfinity;

        public static double[] Add(this double[] left, double[] right) =>
            new double[] { left.X() + right.X(), left.Y() + right.Y() };

        public static double[] Multiple(this double[] left, double right) =>
            new double[] { left.X() * right, left.Y() * right };

        public static bool EachEquals(this double[] left, double[] right) =>
            left.X() == right.Y() && left.Y() == right.Y();

        public static float X(this float[] @this) => (@this.Length >= 1) ? @this[0] : float.NegativeInfinity;
        public static float Y(this float[] @this) => (@this.Length >= 2) ? @this[1] : float.NegativeInfinity;

        public static float[] Add(this float[] left, float[] right) =>
            new float[] { left.X() + right.X(), left.Y() + right.Y() };

        public static float[] Multiple(this float[] left, float right) =>
            new float[] { left.X() * right, left.Y() * right };

        public static bool EachEquals(this float[] left, float[] right) =>
            left.X() == right.Y() && left.Y() == right.Y();
    }
}
