namespace Benchmark.Vectors
{
    using VecF2 = ValueTuple<float, float>;
    using VecD2 = ValueTuple<double, double>;
    using VecFD = ValueTuple<float, double>;
    using VecID = ValueTuple<int, double>;
    using VecF4 = ValueTuple<float, float, float, float>;
    using VecD4 = ValueTuple<double, double, double, double>;
    internal static class ValueTupleExtensions
    {
        // VecF2
        public static float X(this VecF2 @this) => @this.Item1;
        public static float Y(this VecF2 @this) => @this.Item2;

        public static VecF2 Add(this VecF2 left, VecF2 right) =>
            (left.Item1 + right.Item1, left.Item2 + right.Item2);

        public static VecF2 Multiple(this VecF2 left, float right) =>
            (left.Item1 * right, left.Item2 * right);

        public static VecF2 Add_Property(this VecF2 left, VecF2 right) =>
            (left.X() + right.X(), left.Y() + right.Y());

        public static VecF2 Multiple_Property(this VecF2 left, float right) =>
            (left.X() * right, left.Y() * right);

        public static VecF2 VecF2_UnitX() => (1f, 0f);

        public static VecF2 VecF2_UnitY() => (0f, 1f);

        public static VecF2 VecF2_One() => (1f, 1f);

        // VecD2
        public static double X(this VecD2 @this) => @this.Item1;
        public static double Y(this VecD2 @this) => @this.Item2;

        public static VecD2 Add(this VecD2 left, VecD2 right) =>
            (left.X() + right.X(), left.Y()+ right.Y());

        public static VecD2 Multiple(this VecD2 left, double right) =>
            (left.X()* right, left.Y()* right);


        // VecFD
        public static double X(this VecFD @this) => @this.Item1;
        public static double Y(this VecFD @this) => @this.Item2;

        public static VecFD Add(this VecFD left, VecFD right) =>
            (left.Item1 + right.Item1, left.Item2 + right.Item2);

        public static VecFD Multiple(this VecFD left, float right) =>
            (left.Item1 * right, left.Item2 * right);

        // VecID
        public static double X(this VecID @this) => @this.Item1;
        public static double Y(this VecID @this) => @this.Item2;

        public static VecID Add(this VecID left, VecID right) =>
            (left.Item1 + right.Item1, left.Item2 + right.Item2);

        public static VecID Multiple(this VecID left, int right) =>
            (left.Item1 * right, left.Item2 * right);

        // VecD4
        public static double X(this VecD4 @this) => @this.Item1;
        public static double Y(this VecD4 @this) => @this.Item2;
        public static double Z(this VecD4 @this) => @this.Item3;
        public static double W(this VecD4 @this) => @this.Item4;

        public static VecD4 Add(this VecD4 left, VecD4 right) =>
            (left.Item1 + right.Item1, left.Item2 + right.Item2,
                left.Item3 + right.Item3, left.Item4 + right.Item4);

        public static VecD4 Multiple(this VecD4 left, double right) =>
            (left.Item1 * right, left.Item2 * right,
                left.Item3 * right, left.Item4 * right);
    }
}
