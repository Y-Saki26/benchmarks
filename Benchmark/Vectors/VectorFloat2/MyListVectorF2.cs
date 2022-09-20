using System;

namespace Benchmark.Vectors.VectorFloat2
{
    internal class MyListVectorF2: List<float>, IVectorF2<MyListVectorF2>
    {
        public MyListVectorF2(float x, float y) : base() {
            Add(x);
            Add(y);
        }

        // interface 実装
        // IVector2
        public float X { get => this[0]; }

        public float Y { get => this[1]; }

        public MyListVectorF2 Add(MyListVectorF2 other) => Add(this, other);

        public MyListVectorF2 Multiple(float other) => Multiple(this, other);

        public static MyListVectorF2 Add(MyListVectorF2 left, MyListVectorF2 right) =>
            new(left.X + right.X, left.Y + right.Y);

        public static MyListVectorF2 Multiple(MyListVectorF2 left, float right) =>
            new(left.X * right, left.Y * right);

        // IEquatable
        public bool Equals(MyListVectorF2? other) =>
            other is not null && X == other.X && Y == other.Y;

        // IComparable
        public int CompareTo(MyListVectorF2? other) {
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

        public override string? ToString() {
            return base.ToString();
        }

        // 演算子実装
        public static MyListVectorF2 operator +(MyListVectorF2 left, MyListVectorF2 right) => Add(left, right);

        public static MyListVectorF2 operator *(MyListVectorF2 left, float right) => Multiple(left, right);

        public static bool operator ==(MyListVectorF2 left, MyListVectorF2 right) => left.Equals(right);

        public static bool operator !=(MyListVectorF2 left, MyListVectorF2 right) => !left.Equals(right);

        public override bool Equals(object? obj) =>
            obj is not null && Equals(obj as MyListVectorF2);

        public override int GetHashCode() => base.GetHashCode();

        // Static Properties
        public static MyListVectorF2 UnitX { get => new(1f, 0f); }

        public static MyListVectorF2 UnitY { get => new(0f, 1f); }

        public static MyListVectorF2 One { get => new(1f, 1f); }
    }
}
