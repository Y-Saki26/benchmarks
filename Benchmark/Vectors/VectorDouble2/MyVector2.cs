using System;

namespace Benchmark.Vectors.VectorDouble2
{
    internal class MyVector2: IVector2<MyVector2>
    {
        public MyVector2(double x, double y) {
            X = x;
            Y = y;
        }

        // interface 実装
        // IVector2
        public double X { get; }

        public double Y { get; }

        public MyVector2 Add(MyVector2 other) => Add(this, other);

        public MyVector2 Multiple(double other) => Multiple(this, other);

        public static MyVector2 Add(MyVector2 left, MyVector2 right) =>
            new(left.X + right.X, left.Y + right.Y);

        public static MyVector2 Multiple(MyVector2 left, double right) =>
            new(left.X * right, left.Y * right);

        // IEquatable
        public bool Equals(MyVector2? other) =>
            other is not null && X == other.X && Y == other.Y;

        // IComparable
        public int CompareTo(MyVector2? other) {
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
        public static MyVector2 operator +(MyVector2 left, MyVector2 right) => Add(left, right);
        public static MyVector2 operator *(MyVector2 left, double right) => Multiple(left, right);
        public static bool operator ==(MyVector2 left, MyVector2 right) => left.Equals(right);
        public static bool operator !=(MyVector2 left, MyVector2 right) => !left.Equals(right);

        public override bool Equals(object? obj) =>
            obj is not null && Equals(obj as MyVector2);

        public override int GetHashCode() => (X, Y).GetHashCode();

        // Static Properties
        public static MyVector2 UnitX { get => new(1d, 0d); }

        public static MyVector2 UnitY { get => new(0d, 1d); }

        public static MyVector2 One { get => new(1d, 1d); }
    }
}
