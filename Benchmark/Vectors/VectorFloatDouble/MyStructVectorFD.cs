using System;

namespace Benchmark.Vectors.VectorFloatDouble
{
    internal struct MyStructVectorFD//: IVector2Float<MyStructVector2Mix>
    {
        public MyStructVectorFD(float x, double y) {
            X = x;
            Y = y;
        }

        // interface 実装
        // IVector2
        public float X { get; }

        public double Y { get; }

        public MyStructVectorFD Add(MyStructVectorFD other) => Add(this, other);

        public MyStructVectorFD Multiple(float other) => Multiple(this, other);

        public static MyStructVectorFD Add(MyStructVectorFD left, MyStructVectorFD right) =>
            new(left.X + right.X, left.Y + right.Y);

        public static MyStructVectorFD Multiple(MyStructVectorFD left, float right) =>
            new(left.X * right, left.Y * right);

        // IEquatable
        public bool Equals(MyStructVectorFD other) =>
            X == other.X && Y == other.Y;

        // IComparable
        public int CompareTo(MyStructVectorFD other) {
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
        public static MyStructVectorFD operator +(MyStructVectorFD left, MyStructVectorFD right) => Add(left, right);

        public static MyStructVectorFD operator *(MyStructVectorFD left, float right) => Multiple(left, right);

        public static bool operator ==(MyStructVectorFD left, MyStructVectorFD right) => left.Equals(right);

        public static bool operator !=(MyStructVectorFD left, MyStructVectorFD right) => !left.Equals(right);

        public override bool Equals(object? obj) =>
            obj is not null && Equals((MyStructVectorFD)obj);

        public override int GetHashCode() => HashCode.Combine(X, Y);

        // Static Properties
        public static MyStructVectorFD UnitX { get => new(1f, 0d); }

        public static MyStructVectorFD UnitY { get => new(0f, 1d); }

        public static MyStructVectorFD One { get => new(1f, 1d); }

    }
}
