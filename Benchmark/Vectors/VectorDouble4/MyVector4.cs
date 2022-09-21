using System;

namespace Benchmark.Vectors.VectorDouble4
{
    internal class MyVector4: IVector4<MyVector4>
    {
        public MyVector4(double x, double y, double z, double w) {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        // interface 実装
        // IVector2
        public double X { get; }

        public double Y { get; }

        public double Z { get; }

        public double W { get; }

        public MyVector4 Add(MyVector4 other) => Add(this, other);

        public MyVector4 Multiple(double other) => Multiple(this, other);

        public static MyVector4 Add(MyVector4 left, MyVector4 right) =>
            new(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);

        public static MyVector4 Multiple(MyVector4 left, double right) =>
            new(left.X * right, left.Y * right, left.Z * right, left.W * right);

        // IEquatable
        public bool Equals(MyVector4? other) =>
            other is not null
                && X == other.X
                && Y == other.Y
                && Z == other.Z
                && W == other.W;

        // IComparable
        public int CompareTo(MyVector4? other) {
            if(other is null)
                return 1;
            if(X < other.X
                    || X == other.X && Y < other.Y
                    || X == other.X && Y == other.Y && Z < other.Z
                    || X == other.X && Y == other.Y && Z == other.Z && W < other.W)
                return -1;
            if(Equals(other))
                return 0;
            return 1;
        }

        // IFormattable
        public string ToString(string? format, IFormatProvider? provider) {
            return "<" + X.ToString(format, provider) + "," + Y.ToString(format, provider)
                + "," + Z.ToString(format, provider) + "," + W.ToString(format, provider) + ">";
        }

        public override string? ToString() {
            return base.ToString();
        }

        // 演算子実装
        public static MyVector4 operator +(MyVector4 left, MyVector4 right) => Add(left, right);
        public static MyVector4 operator *(MyVector4 left, double right) => Multiple(left, right);
        public static bool operator ==(MyVector4 left, MyVector4 right) => left.Equals(right);
        public static bool operator !=(MyVector4 left, MyVector4 right) => !left.Equals(right);

        public override bool Equals(object? obj) =>
            obj is not null && Equals(obj as MyVector4);

        public override int GetHashCode() => (X, Y).GetHashCode();

        // Static Properties
        public static MyVector4 UnitX { get => new(1d, 0d, 0d, 0d); }

        public static MyVector4 UnitY { get => new(0d, 1d, 0d, 0d); }

        public static MyVector4 UnitZ { get => new(0d, 0d, 1d, 0d); }

        public static MyVector4 UnitW { get => new(0d, 0d, 0d, 1d); }

        public static MyVector4 One { get => new(1d, 1d, 1d, 1d); }
    }
}
