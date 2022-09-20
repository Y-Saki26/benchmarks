namespace Benchmark.Vectors.VectorFloat2
{
    internal struct WrapTupleVectorF2: IVectorF2<WrapTupleVectorF2>
    {
        Tuple<float, float> _values { get; }

        public WrapTupleVectorF2(float x, float y) {
            _values = new(x, y);
        }


        // interface 実装
        // IVector2
        public float X { get => _values.Item1; }

        public float Y { get => _values.Item2; }

        public WrapTupleVectorF2 Add(WrapTupleVectorF2 other) => Add(this, other);

        public WrapTupleVectorF2 Multiple(float other) => Multiple(this, other);

        public static WrapTupleVectorF2 Add(WrapTupleVectorF2 left, WrapTupleVectorF2 right) =>
            new(left.X + right.X, left.Y + right.Y);

        public static WrapTupleVectorF2 Multiple(WrapTupleVectorF2 left, float right) =>
            new(left.X * right, left.Y * right);

        // IEquatable
        public bool Equals(WrapTupleVectorF2 other) =>
            X == other.X && Y == other.Y;

        // IComparable
        public int CompareTo(WrapTupleVectorF2 other) {
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
        public static WrapTupleVectorF2 operator +(WrapTupleVectorF2 left, WrapTupleVectorF2 right) => Add(left, right);

        public static WrapTupleVectorF2 operator *(WrapTupleVectorF2 left, float right) => Multiple(left, right);

        public static bool operator ==(WrapTupleVectorF2 left, WrapTupleVectorF2 right) => left.Equals(right);

        public static bool operator !=(WrapTupleVectorF2 left, WrapTupleVectorF2 right) => !left.Equals(right);

        public override bool Equals(object? obj) =>
            obj is not null && Equals((WrapTupleVectorF2)obj);

        public override int GetHashCode() => base.GetHashCode();

        // Static Properties
        public static WrapTupleVectorF2 UnitX { get => new(1f, 0f); }

        public static WrapTupleVectorF2 UnitY { get => new(0f, 1f); }

        public static WrapTupleVectorF2 One { get => new(1f, 1f); }
    }
}
