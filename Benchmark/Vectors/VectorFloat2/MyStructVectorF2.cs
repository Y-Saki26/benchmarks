using System;

namespace Benchmark.Vectors.VectorFloat2
{
    internal struct MyStructVectorF2: IVectorF2<MyStructVectorF2>
    {
        public MyStructVectorF2(float x, float y) {
            X = x;
            Y = y;
        }

        // interface 実装
        // IVector2
        public float X { get; }

        public float Y { get; }

        public MyStructVectorF2 Add(MyStructVectorF2 other) => Add(this, other);

        public MyStructVectorF2 Multiple(float other) => Multiple(this, other);

        public static MyStructVectorF2 Add(MyStructVectorF2 left, MyStructVectorF2 right) =>
            new(left.X + right.X, left.Y + right.Y);

        public static MyStructVectorF2 Multiple(MyStructVectorF2 left, float right) =>
            new(left.X * right, left.Y * right);

        // IEquatable
        public bool Equals(MyStructVectorF2 other) =>
            X == other.X && Y == other.Y;

        // IComparable
        public int CompareTo(MyStructVectorF2 other) {
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
        public static MyStructVectorF2 operator +(MyStructVectorF2 left, MyStructVectorF2 right) => Add(left, right);

        public static MyStructVectorF2 operator *(MyStructVectorF2 left, float right) => Multiple(left, right);

        public static bool operator ==(MyStructVectorF2 left, MyStructVectorF2 right) => left.Equals(right);

        public static bool operator !=(MyStructVectorF2 left, MyStructVectorF2 right) => !left.Equals(right);

        public override bool Equals(object? obj) =>
            obj is not null && Equals((MyStructVectorF2)obj);

        public override int GetHashCode() => HashCode.Combine(X, Y);

        // Static Properties
        public static MyStructVectorF2 UnitX { get => new(1f, 0f); }

        public static MyStructVectorF2 UnitY { get => new(0f, 1f); }

        public static MyStructVectorF2 One { get => new(1f, 1f); }

    }
}
