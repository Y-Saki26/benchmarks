namespace Benchmark.Vectors
{
    internal interface IVector2<T>: IEquatable<T>, IComparable<T>, IFormattable
    {
        public double X { get; }

        public double Y { get; }

        public T Add(T other);

        public T Multiple(double other);

#pragma warning disable CS8618 // null 非許容のフィールドには、コンストラクターの終了時に null 以外の値が入っていなければなりません。Null 許容として宣言することをご検討ください。
        public static T UnitX { get; }

        public static T UnitY { get; }

        public static T One { get; }
#pragma warning restore CS8618 // null 非許容のフィールドには、コンストラクターの終了時に null 以外の値が入っていなければなりません。Null 許容として宣言することをご検討ください。

    }
    internal interface IVectorF2<T>: IEquatable<T>, IComparable<T>, IFormattable
    {
        public float X { get; }

        public float Y { get; }

        public T Add(T other);

        public T Multiple(float other);

#pragma warning disable CS8618 // null 非許容のフィールドには、コンストラクターの終了時に null 以外の値が入っていなければなりません。Null 許容として宣言することをご検討ください。
        public static T UnitX { get; }

        public static T UnitY { get; }

        public static T One { get; }
#pragma warning restore CS8618 // null 非許容のフィールドには、コンストラクターの終了時に null 以外の値が入っていなければなりません。Null 許容として宣言することをご検討ください。

    }
}
