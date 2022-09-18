using System;

namespace Benchmark.Vectors.VectorDouble2
{
    internal class MyTupleVector2: Tuple<double, double>, IVector2<MyTupleVector2>
    {
        public MyTupleVector2(double x, double y) : base(x, y) {
        }

        // interface 実装
        // IVector2
        public double X { get => Item1; }

        public double Y { get => Item2; }

        public MyTupleVector2 Add(MyTupleVector2 other) => Add(this, other);

        public MyTupleVector2 Multiple(double other) => Multiple(this, other);

        public static MyTupleVector2 Add(MyTupleVector2 left, MyTupleVector2 right) =>
            new(left.X + right.X, left.Y + right.Y);

        public static MyTupleVector2 Multiple(MyTupleVector2 left, double right) =>
            new(left.X * right, left.Y * right);

        // IEquatable
        public bool Equals(MyTupleVector2? other) =>
            other is not null && X == other.X && Y == other.Y;

        // IComparable
        public int CompareTo(MyTupleVector2? other) {
            if(other is null)
                return 1;
            if(X < other.X || X == other.X && Y < other.Y)
                return -1;
            if(Equals(other))
                return 0;
            return 1;
        }

        // IFormattable
        public string ToString(string? format, IFormatProvider? provider) {
            return "<" + X.ToString(format, provider) + "," + Y.ToString(format, provider) + ">";
        }

        public override string ToString() {
            return base.ToString();
        }

        // 演算子実装
        public static MyTupleVector2 operator +(MyTupleVector2 left, MyTupleVector2 right) => Add(left, right);

        public static MyTupleVector2 operator *(MyTupleVector2 left, double right) => Multiple(left, right);

        public static bool operator ==(MyTupleVector2 left, MyTupleVector2 right) => left.Equals(right);

        public static bool operator !=(MyTupleVector2 left, MyTupleVector2 right) => !left.Equals(right);

        public override bool Equals(object? obj) =>
            obj is not null && Equals(obj as MyTupleVector2);

        public override int GetHashCode() => base.GetHashCode();

        // Static Properties
        public static MyTupleVector2 UnitX { get => new(1d, 0d); }

        public static MyTupleVector2 UnitY { get => new(0d, 1d); }

        public static MyTupleVector2 One { get => new(1d, 1d); }
    }
}
