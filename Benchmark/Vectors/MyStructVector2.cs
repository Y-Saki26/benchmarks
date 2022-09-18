using System;

namespace Benchmark.Vectors
{
    internal struct MyStructVector2: IVector2<MyStructVector2>//, IComparable<MyStructVector2>, IFormattable
    {
        public MyStructVector2(double x, double y) {
            X = x;
            Y = y;
        }

        // interface 実装
        // IVector2
        public double X { get; }

        public double Y { get; }

        public MyStructVector2 Add(MyStructVector2 other) => Add(this, other);

        public MyStructVector2 Multiple(double other) => Multiple(this, other);

        public static MyStructVector2 Add(MyStructVector2 left, MyStructVector2 right) =>
            new(left.X + right.X, left.Y + right.Y);

        public static MyStructVector2 Multiple(MyStructVector2 left, double right) =>
            new(left.X * right, left.Y * right);

        // IEquatable
        public bool Equals(MyStructVector2 other) =>
            X == other.X && Y == other.Y;

        // IComparable
        public int CompareTo(MyStructVector2 other) {
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
        public static MyStructVector2 operator +(MyStructVector2 left, MyStructVector2 right) => Add(left, right);

        public static MyStructVector2 operator *(MyStructVector2 left, double right) => Multiple(left, right);

        public static bool operator ==(MyStructVector2 left, MyStructVector2 right) => left.Equals(right);

        public static bool operator !=(MyStructVector2 left, MyStructVector2 right) => !left.Equals(right);

        public override bool Equals(object? obj) =>
            obj is not null && Equals((MyStructVector2)obj);

        public override int GetHashCode() => HashCode.Combine(X, Y);

        // Static Properties
        public static MyStructVector2 UnitX { get => new(1d, 0d); }

        public static MyStructVector2 UnitY { get => new(0d, 1d); }

        public static MyStructVector2 One { get => new(1d, 1d); }

        public static MyStructVector2 GetOne() => new(1d, 1d);

    }
}
