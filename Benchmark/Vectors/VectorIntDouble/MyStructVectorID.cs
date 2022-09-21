using System;

namespace Benchmark.Vectors.VectorIntDouble
{
    internal struct MyStructVectorID//: IVector2Float<MyStructVector2Mix>
    {
        public MyStructVectorID(int x, double y) {
            X = x;
            Y = y;
        }

        // interface 実装
        // IVector2
        public int X { get; }

        public double Y { get; }

        public MyStructVectorID Add(MyStructVectorID other) => Add(this, other);

        public MyStructVectorID Multiple(int other) => Multiple(this, other);

        public static MyStructVectorID Add(MyStructVectorID left, MyStructVectorID right) =>
            new(left.X + right.X, left.Y + right.Y);

        public static MyStructVectorID Multiple(MyStructVectorID left, int right) =>
            new(left.X * right, left.Y * right);

        // IEquatable
        public bool Equals(MyStructVectorID other) =>
            X == other.X && Y == other.Y;

        // IComparable
        public int CompareTo(MyStructVectorID other) {
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

        public override string? ToString() {
            return base.ToString();
        }

        // 演算子実装
        public static MyStructVectorID operator +(MyStructVectorID left, MyStructVectorID right) => Add(left, right);

        public static MyStructVectorID operator *(MyStructVectorID left, int right) => Multiple(left, right);

        public static bool operator ==(MyStructVectorID left, MyStructVectorID right) => left.Equals(right);

        public static bool operator !=(MyStructVectorID left, MyStructVectorID right) => !left.Equals(right);

        public override bool Equals(object? obj) =>
            obj is not null && Equals((MyStructVectorID)obj);

        public override int GetHashCode() => HashCode.Combine(X, Y);

        // Static Properties
        public static MyStructVectorID UnitX { get => new(1, 0d); }

        public static MyStructVectorID UnitY { get => new(0, 1d); }

        public static MyStructVectorID One { get => new(1, 1d); }

    }
}
