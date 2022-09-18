using System;

namespace Benchmark.Vectors
{
    internal struct MyStructVector2MixID//: IVector2Float<MyStructVector2Mix>
    {
        public MyStructVector2MixID(int x, double y) {
            X = x;
            Y = y;
        }

        // interface 実装
        // IVector2
        public int X { get; }

        public double Y { get; }

        public MyStructVector2MixID Add(MyStructVector2MixID other) => Add(this, other);

        public MyStructVector2MixID Multiple(int other) => Multiple(this, other);

        public static MyStructVector2MixID Add(MyStructVector2MixID left, MyStructVector2MixID right) =>
            new(left.X + right.X, left.Y + right.Y);

        public static MyStructVector2MixID Multiple(MyStructVector2MixID left, int right) =>
            new(left.X * right, left.Y * right);

        // IEquatable
        public bool Equals(MyStructVector2MixID other) =>
            X == other.X && Y == other.Y;

        // IComparable
        public int CompareTo(MyStructVector2MixID other) {
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
        public static MyStructVector2MixID operator +(MyStructVector2MixID left, MyStructVector2MixID right) => Add(left, right);

        public static MyStructVector2MixID operator *(MyStructVector2MixID left, int right) => Multiple(left, right);

        public static bool operator ==(MyStructVector2MixID left, MyStructVector2MixID right) => left.Equals(right);

        public static bool operator !=(MyStructVector2MixID left, MyStructVector2MixID right) => !left.Equals(right);

        public override bool Equals(object? obj) =>
            obj is not null && Equals((MyStructVector2MixID)obj);

        public override int GetHashCode() => HashCode.Combine(X, Y);

        // Static Properties
        public static MyStructVector2MixID UnitX { get => new(1, 0d); }

        public static MyStructVector2MixID UnitY { get => new(0, 1d); }

        public static MyStructVector2MixID One { get => new(1, 1d); }

    }
}
