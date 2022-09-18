namespace Benchmark.Vectors
{
    internal class MyArrayVector2Float: IVector2Float<MyArrayVector2Float>
    {
        readonly float[] _values;

        public MyArrayVector2Float(float x, float y) {
            _values = new[] { x, y };
        }


        // interface 実装
        // IVector2
        public float X { get => _values[0]; }

        public float Y { get => _values[0]; }

        public MyArrayVector2Float Add(MyArrayVector2Float other) => Add(this, other);

        public MyArrayVector2Float Multiple(float other) => Multiple(this, other);

        public static MyArrayVector2Float Add(MyArrayVector2Float left, MyArrayVector2Float right) =>
            new(left.X + right.X, left.Y + right.Y);

        public static MyArrayVector2Float Multiple(MyArrayVector2Float left, float right) =>
            new(left.X * right, left.Y * right);

        // IEquatable
        public bool Equals(MyArrayVector2Float? other) =>
            other is not null && X == other.X && Y == other.Y;

        // IComparable
        public int CompareTo(MyArrayVector2Float? other) {
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
        public static MyArrayVector2Float operator +(MyArrayVector2Float left, MyArrayVector2Float right) => Add(left, right);

        public static MyArrayVector2Float operator *(MyArrayVector2Float left, float right) => Multiple(left, right);

        public static bool operator ==(MyArrayVector2Float left, MyArrayVector2Float right) => left.Equals(right);

        public static bool operator !=(MyArrayVector2Float left, MyArrayVector2Float right) => !left.Equals(right);

        public override bool Equals(object? obj) =>
            obj is not null && Equals(obj as MyArrayVector2Float);

        public override int GetHashCode() => base.GetHashCode();

        // Static Properties
        public static MyArrayVector2Float UnitX { get => new(1f, 0f); }

        public static MyArrayVector2Float UnitY { get => new(0f, 1f); }

        public static MyArrayVector2Float One { get => new(1f, 1f); }
    }
}
