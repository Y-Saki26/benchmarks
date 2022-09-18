using Benchmark.Vectors.VectorDouble2;

namespace Benchmark.Vectors.VectorFloat2
{
    internal class MyVector2Float: IVector2Float<MyVector2Float>
    {
        public MyVector2Float(float x, float y) {
            X = x;
            Y = y;
        }

        // interface 実装
        // IVector2
        public float X { get; }

        public float Y { get; }

        public MyVector2Float Add(MyVector2Float other) => Add(this, other);

        public MyVector2Float Multiple(float other) => Multiple(this, other);

        public static MyVector2Float Add(MyVector2Float left, MyVector2Float right) =>
            new(left.X + right.X, left.Y + right.Y);

        public static MyVector2Float Multiple(MyVector2Float left, float right) =>
            new(left.X * right, left.Y * right);

        // IEquatable
        public bool Equals(MyVector2Float? other) =>
            other is not null && X == other.X && Y == other.Y;

        // IComparable
        public int CompareTo(MyVector2Float? other) {
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
        public static MyVector2Float operator +(MyVector2Float left, MyVector2Float right) => Add(left, right);
        public static MyVector2Float operator *(MyVector2Float left, float right) => Multiple(left, right);
        public static bool operator ==(MyVector2Float left, MyVector2Float right) => left.Equals(right);
        public static bool operator !=(MyVector2Float left, MyVector2Float right) => !left.Equals(right);

        public override bool Equals(object? obj) =>
            obj is not null && Equals(obj as MyVector2);

        public override int GetHashCode() => HashCode.Combine(X, Y);

        // Static Properties
        public static MyVector2Float UnitX { get => new(1f, 0f); }

        public static MyVector2Float UnitY { get => new(0f, 1f); }

        public static MyVector2Float One { get => new(1f, 1f); }
    }
}
