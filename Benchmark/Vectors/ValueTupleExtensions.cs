namespace Benchmark.Vectors
{
    using Vec2 = ValueTuple<double, double>;
    using VecF2 = ValueTuple<float, float>;
    using Vec2mFD = ValueTuple<float, double>;
    using Vec2mID = ValueTuple<int, double>;
    using Vec4 = ValueTuple<double, double, double, double>;
    using Vec4f = ValueTuple<float, float, float, float>;
    internal static class ValueTupleExtensions
    {
        // Vec2
        public static double X(this Vec2 @this) => @this.Item1;
        public static double Y(this Vec2 @this) => @this.Item2;

        public static Vec2 Add(this Vec2 left, Vec2 right) =>
            (left.X() + right.X(), left.Y()+ right.Y());

        public static Vec2 Multiple(this Vec2 left, double right) =>
            (left.X()* right, left.Y()* right);


        // VecF2
        public static float X(this VecF2 @this) => @this.Item1;
        public static float Y(this VecF2 @this) => @this.Item2;

        public static VecF2 Add(this VecF2 left, VecF2 right) =>
            (left.Item1 + right.Item1, left.Item2 + right.Item2);

        public static VecF2 Multiple(this VecF2 left, float right) =>
            (left.Item1 * right, left.Item2 * right);

        public static VecF2 Add_Method(this VecF2 left, VecF2 right) =>
            (left.X() + right.X(), left.Y() + right.Y());

        public static VecF2 Multiple_Method(this VecF2 left, float right) =>
            (left.X() * right, left.Y() * right);

        public static VecF2 VecF2_UnitX() => (1f, 0f);

        public static VecF2 VecF2_UnitY() => (0f, 1f);

        public static VecF2 VecF2_One() => (1f, 1f);

        // Vec2mFD
        public static double X(this Vec2mFD @this) => @this.Item1;
        public static double Y(this Vec2mFD @this) => @this.Item2;

        public static Vec2mFD Add(this Vec2mFD left, Vec2mFD right) =>
            (left.Item1 + right.Item1, left.Item2 + right.Item2);

        public static Vec2mFD Multiple(this Vec2mFD left, float right) =>
            (left.Item1 * right, left.Item2 * right);

        // Vec2mID
        public static double X(this Vec2mID @this) => @this.Item1;
        public static double Y(this Vec2mID @this) => @this.Item2;

        public static Vec2mID Add(this Vec2mID left, Vec2mID right) =>
            (left.Item1 + right.Item1, left.Item2 + right.Item2);

        public static Vec2mID Multiple(this Vec2mID left, int right) =>
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
