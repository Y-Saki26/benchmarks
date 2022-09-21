namespace Benchmark.Vectors.VectorExtensions
{
    internal static class TupleExtensions
    {
        public static Tuple<double, double> Add(this Tuple<double, double> left, Tuple<double, double> right) =>
            new(left.Item1 + right.Item1, left.Item2 + right.Item2);

        public static Tuple<double, double> Multiple(this Tuple<double, double> left, double right) =>
            new(left.Item1 * right, left.Item2 * right);

        public static Tuple<float, float> Add(this Tuple<float, float> left, Tuple<float, float> right) =>
            new(left.Item1 + right.Item1, left.Item2 + right.Item2);

        public static Tuple<float, float> Multiple(this Tuple<float, float> left, float right) =>
            new(left.Item1 * right, left.Item2 * right);

        public static Tuple<float, float> VecF2_UnitX() => new(1f, 0f);

        public static Tuple<float, float> VecF2_UnitY() => new(0f, 1f);

        public static Tuple<float, float> VecF2_One() => new(1f, 1f);
    }
}
