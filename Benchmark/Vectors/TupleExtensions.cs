namespace Benchmark.Vectors
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
    }
}
