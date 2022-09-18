namespace Benchmark.Vectors
{
    using Vec2 = ValueTuple<double, double>;
    using Vec2f = ValueTuple<float, float>;
    using Vec4 = ValueTuple<double, double, double, double>;
    using Vec4f = ValueTuple<float, float, float, float>;
    internal static class ValueTupleExtensions
    {
        // Vec2
        public static double X(this Vec2 @this) => @this.Item1;
        public static double Y(this Vec2 @this) => @this.Item2;

        public static Vec2 Add(this Vec2 left, Vec2 right) =>
            (left.Item1 + right.Item1, left.Item2 + right.Item2);

        public static Vec2 Multiple(this Vec2 left, double right) =>
            (left.Item1 * right, left.Item2 * right);

        // Vec2f
        public static double X(this Vec2f @this) => @this.Item1;
        public static double Y(this Vec2f @this) => @this.Item2;

        public static Vec2f Add(this Vec2f left, Vec2f right) =>
            (left.Item1 + right.Item1, left.Item2 + right.Item2);

        public static Vec2f Multiple(this Vec2f left, float right) =>
            (left.Item1 * right, left.Item2 * right);

        // Vec4
        public static double X(this Vec4 @this) => @this.Item1;
        public static double Y(this Vec4 @this) => @this.Item2;
        public static double Z(this Vec4 @this) => @this.Item3;
        public static double W(this Vec4 @this) => @this.Item4;

        public static Vec4 Add(this Vec4 left, Vec4 right) =>
            (left.Item1 + right.Item1, left.Item2 + right.Item2,
                left.Item3 + right.Item3, left.Item4 + right.Item4);

        public static Vec4 Multiple(this Vec4 left, double right) =>
            (left.Item1 * right, left.Item2 * right,
                left.Item3 * right, left.Item4 * right);
    }
}
