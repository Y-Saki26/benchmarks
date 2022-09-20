using System;

namespace Benchmark.Vectors.VectorFloat2
{
    internal class MyTupleVectorF2: Tuple<float, float>, IVectorF2<MyTupleVectorF2>
    {
        public MyTupleVectorF2(float x, float y) : base(x, y) {
        }

        // interface 実装
        // IVector2
        public float X { get => Item1; }

        public float Y { get => Item2; }

        public MyTupleVectorF2 Add(MyTupleVectorF2 other) => Add(this, other);

        public MyTupleVectorF2 Multiple(float other) => Multiple(this, other);

        public static MyTupleVectorF2 Add(MyTupleVectorF2 left, MyTupleVectorF2 right) =>
            new(left.X + right.X, left.Y + right.Y);

        public static MyTupleVectorF2 Multiple(MyTupleVectorF2 left, float right) =>
            new(left.X * right, left.Y * right);

        // IEquatable
        public bool Equals(MyTupleVectorF2? other) =>
            other is not null && X == other.X && Y == other.Y;

        // IComparable
        public int CompareTo(MyTupleVectorF2? other) {
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
        public static MyTupleVectorF2 operator +(MyTupleVectorF2 left, MyTupleVectorF2 right) => Add(left, right);

        public static MyTupleVectorF2 operator *(MyTupleVectorF2 left, float right) => Multiple(left, right);

        public static bool operator ==(MyTupleVectorF2 left, MyTupleVectorF2 right) => left.Equals(right);

        public static bool operator !=(MyTupleVectorF2 left, MyTupleVectorF2 right) => !left.Equals(right);

        public override bool Equals(object? obj) =>
            obj is not null && Equals(obj as MyTupleVectorF2);

        public override int GetHashCode() => base.GetHashCode();

        // Static Properties
        public static MyTupleVectorF2 UnitX { get => new(1f, 0f); }

        public static MyTupleVectorF2 UnitY { get => new(0f, 1f); }

        public static MyTupleVectorF2 One { get => new(1f, 1f); }
    }
}
