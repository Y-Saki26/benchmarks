namespace Benchmark.Vectors.VectorFloat2
{
    internal struct WrapValueTupleVectorF2: IVectorF2<WrapValueTupleVectorF2>
    {
        (float X, float Y) _values { get; }

        public WrapValueTupleVectorF2(float x, float y) {
            _values = (x, y);
        }


        // interface 実装
        // IVector2
        public float X { get => _values.X; }

        public float Y { get => _values.Y; }

        public WrapValueTupleVectorF2 Add(WrapValueTupleVectorF2 other) => Add(this, other);

        public WrapValueTupleVectorF2 Multiple(float other) => Multiple(this, other);

        public static WrapValueTupleVectorF2 Add(WrapValueTupleVectorF2 left, WrapValueTupleVectorF2 right) =>
            new(left.X + right.X, left.Y + right.Y);

        public static WrapValueTupleVectorF2 Multiple(WrapValueTupleVectorF2 left, float right) =>
            new(left.X * right, left.Y * right);

        // IEquatable
        public bool Equals(WrapValueTupleVectorF2 other) =>
            X == other.X && Y == other.Y;

        // IComparable
        public int CompareTo(WrapValueTupleVectorF2 other) {
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
        public static WrapValueTupleVectorF2 operator +(WrapValueTupleVectorF2 left, WrapValueTupleVectorF2 right) => Add(left, right);

        public static WrapValueTupleVectorF2 operator *(WrapValueTupleVectorF2 left, float right) => Multiple(left, right);

        public static bool operator ==(WrapValueTupleVectorF2 left, WrapValueTupleVectorF2 right) => left.Equals(right);

        public static bool operator !=(WrapValueTupleVectorF2 left, WrapValueTupleVectorF2 right) => !left.Equals(right);

        public override bool Equals(object? obj) =>
            obj is not null && Equals((WrapValueTupleVectorF2)obj);

        public override int GetHashCode() => base.GetHashCode();

        // Static Properties
        public static WrapValueTupleVectorF2 UnitX { get => new(1f, 0f); }

        public static WrapValueTupleVectorF2 UnitY { get => new(0f, 1f); }

        public static WrapValueTupleVectorF2 One { get => new(1f, 1f); }
    }
}
