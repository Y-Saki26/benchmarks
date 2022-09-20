namespace Benchmark.Vectors.VectorFloat2
{
    internal struct WrapArrayVectorF2: IVectorF2<WrapArrayVectorF2>
    {
        float[] _values { get; }

        public WrapArrayVectorF2(float x, float y) {
            _values = new[] { x, y };
        }

        // interface 実装
        // IVector2
        public float X { get => _values[0]; }

        public float Y { get => _values[1]; }

        public WrapArrayVectorF2 Add(WrapArrayVectorF2 other) => Add(this, other);

        public WrapArrayVectorF2 Multiple(float other) => Multiple(this, other);

        public static WrapArrayVectorF2 Add(WrapArrayVectorF2 left, WrapArrayVectorF2 right) =>
            new(left.X + right.X, left.Y + right.Y);

        public static WrapArrayVectorF2 Multiple(WrapArrayVectorF2 left, float right) =>
            new(left.X * right, left.Y * right);

        // IEquatable
        public bool Equals(WrapArrayVectorF2 other) =>
            X == other.X && Y == other.Y;

        // IComparable
        public int CompareTo(WrapArrayVectorF2 other) {
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
        public static WrapArrayVectorF2 operator +(WrapArrayVectorF2 left, WrapArrayVectorF2 right) => Add(left, right);

        public static WrapArrayVectorF2 operator *(WrapArrayVectorF2 left, float right) => Multiple(left, right);

        public static bool operator ==(WrapArrayVectorF2 left, WrapArrayVectorF2 right) => left.Equals(right);

        public static bool operator !=(WrapArrayVectorF2 left, WrapArrayVectorF2 right) => !left.Equals(right);

        public override bool Equals(object? obj) =>
            obj is not null && Equals((WrapArrayVectorF2)obj);

        public override int GetHashCode() => base.GetHashCode();

        // Static Properties
        public static WrapArrayVectorF2 UnitX { get => new(1f, 0f); }

        public static WrapArrayVectorF2 UnitY { get => new(0f, 1f); }

        public static WrapArrayVectorF2 One { get => new(1f, 1f); }
    }
}
