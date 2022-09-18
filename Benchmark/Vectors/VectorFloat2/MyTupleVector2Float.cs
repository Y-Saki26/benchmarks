using System;

namespace Benchmark.Vectors.VectorFloat2
{
    internal class MyTupleVector2Float: Tuple<float, float>, IVector2Float<MyTupleVector2Float>
    {
        public MyTupleVector2Float(float x, float y) : base(x, y) {
        }

        // interface 実装
        // IVector2
        public float X { get => Item1; }

        public float Y { get => Item2; }

        public MyTupleVector2Float Add(MyTupleVector2Float other) => Add(this, other);

        public MyTupleVector2Float Multiple(float other) => Multiple(this, other);

        public static MyTupleVector2Float Add(MyTupleVector2Float left, MyTupleVector2Float right) =>
            new(left.X + right.X, left.Y + right.Y);

        public static MyTupleVector2Float Multiple(MyTupleVector2Float left, float right) =>
            new(left.X * right, left.Y * right);

        // IEquatable
        public bool Equals(MyTupleVector2Float? other) =>
            other is not null && X == other.X && Y == other.Y;

        // IComparable
        public int CompareTo(MyTupleVector2Float? other) {
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
        public static MyTupleVector2Float operator +(MyTupleVector2Float left, MyTupleVector2Float right) => Add(left, right);

        public static MyTupleVector2Float operator *(MyTupleVector2Float left, float right) => Multiple(left, right);

        public static bool operator ==(MyTupleVector2Float left, MyTupleVector2Float right) => left.Equals(right);

        public static bool operator !=(MyTupleVector2Float left, MyTupleVector2Float right) => !left.Equals(right);

        public override bool Equals(object? obj) =>
            obj is not null && Equals(obj as MyTupleVector2Float);

        public override int GetHashCode() => base.GetHashCode();

        // Static Properties
        public static MyTupleVector2Float UnitX { get => new(1f, 0f); }

        public static MyTupleVector2Float UnitY { get => new(0f, 1f); }

        public static MyTupleVector2Float One { get => new(1f, 1f); }
    }
}
