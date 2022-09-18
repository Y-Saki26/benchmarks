using System;

namespace Benchmark.Vectors
{
    internal struct MyStructVector2MixFD//: IVector2Float<MyStructVector2Mix>
    {
        public MyStructVector2MixFD(float x, double y) {
            X = x;
            Y = y;
        }

        // interface 実装
        // IVector2
        public float X { get; }

        public double Y { get; }

        public MyStructVector2MixFD Add(MyStructVector2MixFD other) => Add(this, other);

        public MyStructVector2MixFD Multiple(float other) => Multiple(this, other);

        public static MyStructVector2MixFD Add(MyStructVector2MixFD left, MyStructVector2MixFD right) =>
            new(left.X + right.X, left.Y + right.Y);

        public static MyStructVector2MixFD Multiple(MyStructVector2MixFD left, float right) =>
            new(left.X * right, left.Y * right);

        // IEquatable
        public bool Equals(MyStructVector2MixFD other) =>
            X == other.X && Y == other.Y;

        // IComparable
        public int CompareTo(MyStructVector2MixFD other) {
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
        public static MyStructVector2MixFD operator +(MyStructVector2MixFD left, MyStructVector2MixFD right) => Add(left, right);

        public static MyStructVector2MixFD operator *(MyStructVector2MixFD left, float right) => Multiple(left, right);

        public static bool operator ==(MyStructVector2MixFD left, MyStructVector2MixFD right) => left.Equals(right);

        public static bool operator !=(MyStructVector2MixFD left, MyStructVector2MixFD right) => !left.Equals(right);

        public override bool Equals(object? obj) =>
            obj is not null && Equals((MyStructVector2MixFD)obj);

        public override int GetHashCode() => HashCode.Combine(X, Y);

        // Static Properties
        public static MyStructVector2MixFD UnitX { get => new(1f, 0d); }

        public static MyStructVector2MixFD UnitY { get => new(0f, 1d); }

        public static MyStructVector2MixFD One { get => new(1f, 1d); }

    }
}
