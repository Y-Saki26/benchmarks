using Benchmark.Vectors.VectorDouble2;

namespace Benchmark.Vectors.VectorFloat2
{
    internal class MyClassVectorF2: IVectorF2<MyClassVectorF2>
    {
        public MyClassVectorF2(float x, float y) {
            X = x;
            Y = y;
        }

        // interface 実装
        // IVector2
        public float X { get; }

        public float Y { get; }

        public MyClassVectorF2 Add(MyClassVectorF2 other) => Add(this, other);

        public MyClassVectorF2 Multiple(float other) => Multiple(this, other);

        public static MyClassVectorF2 Add(MyClassVectorF2 left, MyClassVectorF2 right) =>
            new(left.X + right.X, left.Y + right.Y);

        public static MyClassVectorF2 Multiple(MyClassVectorF2 left, float right) =>
            new(left.X * right, left.Y * right);

        // IEquatable
        public bool Equals(MyClassVectorF2? other) =>
            other is not null && X == other.X && Y == other.Y;

        // IComparable
        public int CompareTo(MyClassVectorF2? other) {
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
        public static MyClassVectorF2 operator +(MyClassVectorF2 left, MyClassVectorF2 right) => Add(left, right);
        public static MyClassVectorF2 operator *(MyClassVectorF2 left, float right) => Multiple(left, right);
        public static bool operator ==(MyClassVectorF2 left, MyClassVectorF2 right) => left.Equals(right);
        public static bool operator !=(MyClassVectorF2 left, MyClassVectorF2 right) => !left.Equals(right);

        public override bool Equals(object? obj) =>
            obj is not null && Equals(obj as MyVector2);

        public override int GetHashCode() => HashCode.Combine(X, Y);

        // Static Properties
        public static MyClassVectorF2 UnitX { get => new(1f, 0f); }

        public static MyClassVectorF2 UnitY { get => new(0f, 1f); }

        public static MyClassVectorF2 One { get => new(1f, 1f); }
    }
}
