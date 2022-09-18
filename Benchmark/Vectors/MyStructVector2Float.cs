using System;

namespace Benchmark.Vectors
{
    internal struct MyStructVector2Float: IVector2Float<MyStructVector2Float>
    {
        public MyStructVector2Float(float x, float y) {
            X = x;
            Y = y;
        }

        // interface 実装
        // IVector2
        public float X { get; }

        public float Y { get; }

        public MyStructVector2Float Add(MyStructVector2Float other) => Add(this, other);

        public MyStructVector2Float Multiple(float other) => Multiple(this, other);

        public static MyStructVector2Float Add(MyStructVector2Float left, MyStructVector2Float right) =>
            new(left.X + right.X, left.Y + right.Y);

        public static MyStructVector2Float Multiple(MyStructVector2Float left, float right) =>
            new(left.X * right, left.Y * right);

        // IEquatable
        public bool Equals(MyStructVector2Float other) =>
            X == other.X && Y == other.Y;

        // IComparable
        public int CompareTo(MyStructVector2Float other) {
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
        public static MyStructVector2Float operator +(MyStructVector2Float left, MyStructVector2Float right) => Add(left, right);

        public static MyStructVector2Float operator *(MyStructVector2Float left, float right) => Multiple(left, right);

        public static bool operator ==(MyStructVector2Float left, MyStructVector2Float right) => left.Equals(right);

        public static bool operator !=(MyStructVector2Float left, MyStructVector2Float right) => !left.Equals(right);

        public override bool Equals(object? obj) =>
            obj is not null && Equals((MyStructVector2Float)obj);

        public override int GetHashCode() => HashCode.Combine(X, Y);

        // Static Properties
        public static MyStructVector2Float UnitX { get => new(1f, 0f); }

        public static MyStructVector2Float UnitY { get => new(0f, 1f); }

        public static MyStructVector2Float One { get => new(1f, 1f); }

    }
}
