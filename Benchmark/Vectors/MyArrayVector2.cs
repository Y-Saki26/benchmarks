namespace Benchmark.Vectors
{
    internal class MyArrayVector2: IVector2<MyArrayVector2>
    {
        readonly double[] _values;

        public MyArrayVector2(double x, double y) {
            _values = new[] { x, y };
        }


        // interface 実装
        // IVector2
        public double X { get => _values[0]; }

        public double Y { get => _values[0]; }

        public MyArrayVector2 Add(MyArrayVector2 other) => Add(this, other);

        public MyArrayVector2 Multiple(double other) => Multiple(this, other);

        public static MyArrayVector2 Add(MyArrayVector2 left, MyArrayVector2 right) =>
            new(left.X + right.X, left.Y + right.Y);

        public static MyArrayVector2 Multiple(MyArrayVector2 left, double right) =>
            new(left.X * right, left.Y * right);

        // IEquatable
        public bool Equals(MyArrayVector2? other) =>
            other is not null && X == other.X && Y == other.Y;

        // IComparable
        public int CompareTo(MyArrayVector2? other) {
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
        public static MyArrayVector2 operator +(MyArrayVector2 left, MyArrayVector2 right) => Add(left, right);

        public static MyArrayVector2 operator *(MyArrayVector2 left, double right) => Multiple(left, right);

        public static bool operator ==(MyArrayVector2 left, MyArrayVector2 right) => left.Equals(right);

        public static bool operator !=(MyArrayVector2 left, MyArrayVector2 right) => !left.Equals(right);

        public override bool Equals(object? obj) =>
            obj is not null && Equals(obj as MyArrayVector2);

        public override int GetHashCode() => base.GetHashCode();

        // Static Properties
        public static MyArrayVector2 UnitX { get => new(1d, 0d); }

        public static MyArrayVector2 UnitY { get => new(0d, 1d); }

        public static MyArrayVector2 One { get => new(1d, 1d); }
    }
}
