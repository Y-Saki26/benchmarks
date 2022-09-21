using System;
using System.Numerics;
using BenchmarkDotNet.Attributes;
using SN = System.Numerics;
using UE = UnityEngine;

namespace Benchmark.Vectors.VectorFloat2
{
    /// <summary>
    /// Benchmarks of `(1, 0) x i + (0, 1) x i == (1, 1) x i` for i in 0..N
    /// </summary>
    //[MemoryDiagnoser]
    [AllStatisticsColumn]
    //[ShortRunJob]
    public class VectorFloat2Bench
    {
#pragma warning disable IDE0059 // 値の不必要な代入
#pragma warning disable IDE0042 // 変数の宣言を分解

        [Params(0, 1, 2, 12, 123, int.MaxValue)]
        public int I { get; set; }

        [Benchmark]
        public bool Vector2() {
            var x = SN::Vector2.UnitX * I;
            var y = SN::Vector2.UnitY * I;
            var z = SN::Vector2.One * I;
            return x + y == z;
        }

        [Benchmark]
        public bool UnityEngine() {
            var x = UE::Vector2.right * I;
            var y = UE::Vector2.up * I;
            var z = UE::Vector2.one * I;
            return x + y == z;
        }

        [Benchmark]
        public bool MyClass() {
            var x = MyClassVectorF2.UnitX * I;
            var y = MyClassVectorF2.UnitY * I;
            var z = MyClassVectorF2.One * I;
            return x + y == z;
        }

        [Benchmark(Baseline = true)]
        public bool MyStruct() {
            var x = MyStructVectorF2.UnitX * I;
            var y = MyStructVectorF2.UnitY * I;
            var z = MyStructVectorF2.One * I;
            return x + y == z;
        }

        [Benchmark]
        public bool ValueTuple_Extend() {
            var x = ValueTupleExtensions.VecF2_UnitX().Multiple(I);
            var y = ValueTupleExtensions.VecF2_UnitY().Multiple(I);
            var z = ValueTupleExtensions.VecF2_One().Multiple(I);
            return x.Add(y) == z;
        }

        [Benchmark]
        public bool ValueTuple_Wrap() {
            var x = WrapValueTupleVectorF2.UnitX * I;
            var y = WrapValueTupleVectorF2.UnitY * I;
            var z = WrapValueTupleVectorF2.One * I;
            return x + y == z;
        }

        [Benchmark]
        public bool Tuple_Extend() {
            var x = TupleExtensions.VecF2_UnitX().Multiple(I);
            var y = TupleExtensions.VecF2_UnitY().Multiple(I);
            var z = TupleExtensions.VecF2_One().Multiple(I);
            return x.Add(y).Equals(z);
        }

        [Benchmark]
        public bool Tuple_Class() {
            var x = MyTupleVectorF2.UnitX * I;
            var y = MyTupleVectorF2.UnitY * I;
            var z = MyTupleVectorF2.One * I;
            return x + y == z;
        }

        [Benchmark]
        public bool Tuple_Wrap() {
            var x = WrapTupleVectorF2.UnitX * I;
            var y = WrapTupleVectorF2.UnitY * I;
            var z = WrapTupleVectorF2.One * I;
            return x + y == z;
        }

        [Benchmark]
        public bool Array_Extend() {
            var x = ArrayExtensions.VecF2_UnitX().Multiple(I);
            var y = ArrayExtensions.VecF2_UnitY().Multiple(I);
            var z = ArrayExtensions.VecF2_One().Multiple(I);
            return x.Add(y).EachEquals(z);
        }

        [Benchmark]
        public bool Array_Wrap() {
            var x = WrapArrayVectorF2.UnitX * I;
            var y = WrapArrayVectorF2.UnitY * I;
            var z = WrapArrayVectorF2.One * I;
            return x + y == z;
        }

        [Benchmark]
        public bool List_Class() {
            var x = MyListVectorF2.UnitX * I;
            var y = MyListVectorF2.UnitY * I;
            var z = MyListVectorF2.One * I;
            return x + y == z;
        }

        [Benchmark]
        public bool List_Extend() {
            var x = ListExtensions.VecF2_UnitX().Multiple(I);
            var y = ListExtensions.VecF2_UnitY().Multiple(I);
            var z = ListExtensions.VecF2_One().Multiple(I);
            return x.Add(y).EachEquals(z);
        }

        [Benchmark]
        public bool List_ExtendEnumerate() {
            var x = ListExtensions.VecF2_UnitX().Multiple_Enumerate(I);
            var y = ListExtensions.VecF2_UnitY().Multiple_Enumerate(I);
            var z = ListExtensions.VecF2_One().Multiple_Enumerate(I);
            return x.Add_Enumerate(y).Equals_Enumerate(z);
        }

        [Benchmark]
        public bool List_ExtendParallel() {
            var x = ListExtensions.VecF2_UnitX().AsParallel().Multiple_Parallel(I);
            var y = ListExtensions.VecF2_UnitY().AsParallel().Multiple_Parallel(I);
            var z = ListExtensions.VecF2_One().AsParallel().Multiple_Parallel(I);
            return x.Add_Parallel(y).Equals_Parallel(z);
        }

        // System.Numerics.Vector<T>
        [Benchmark]
        public bool VectorT_Solid() {
            var x = VectorTExtends.VecF2_UnitX_Solid() * I;
            var y = VectorTExtends.VecF2_UnitY_Solid() * I;
            var z = VectorTExtends.VecF2_One_Solid() * I;
            return x + y == z;
        }

        [Benchmark]
        public bool VectorT_Static() {
            var x = VectorTExtends.VecF2_UnitX() * I;
            var y = VectorTExtends.VecF2_UnitY() * I;
            var z = VectorTExtends.VecF2_One() * I;
            return x + y == z;
        }

        // ゼロ確認
        [Benchmark]
        public bool Vain() {
            float x = (float)I;
            return x == -1.0f;
        }

        [Benchmark]
        public void Void() {
            //continue;
        }

        // 最適化されるかどうかの確認
        [Benchmark]
        public void Vector2_NoReturn() {
            var x = SN::Vector2.UnitX * I;
            var y = SN::Vector2.UnitY * I;
            var z = SN::Vector2.One * I;
            var w = x + y == z;
        }

        [Benchmark]
        public (Vector2, Vector2) Vector2_NoCompare() {
            var x = SN::Vector2.UnitX * I;
            var y = SN::Vector2.UnitY * I;
            var z = SN::Vector2.One * I;
            return (x + y, z);
        }

        [Benchmark]
        public (Vector2, Vector2, Vector2) Vector2_NoAdd() {
            var x = SN::Vector2.UnitX * I;
            var y = SN::Vector2.UnitY * I;
            var z = SN::Vector2.One * I;
            return (x, y, z);
        }

        [Benchmark]
        public ((float X, float Y), (float X, float Y)) ValueTuple_NoCompare() {
            (float X, float Y) x = (1f, 0f).Multiple(I);
            (float X, float Y) y = (0f, 1f).Multiple(I);
            (float X, float Y) z = (1f, 1f).Multiple(I);
            return (x.Add(y), z);
        }

        [Benchmark]
        public ((float X, float Y), (float X, float Y), (float X, float Y)) ValueTuple_NoAdd() {
            (float X, float Y) x = (1f, 0f).Multiple(I);
            (float X, float Y) y = (0f, 1f).Multiple(I);
            (float X, float Y) z = (1f, 1f).Multiple(I);
            return (x, y, z);
        }

        // タプルの細かい挙動確認
        // 拡張メソッドとローカルメソッドの比較
        [Benchmark]
        public bool ValueTuple_LocalMethod() {
            (float, float) x = Multiple((1f, 0f), I);
            (float, float) y = Multiple((0f, 1f), I);
            (float, float) z = Multiple((1f, 1f), I);
            return Add(x, y) == z;
        }

        public static (float, float) Add((float, float) left, (float, float) right) =>
            (left.Item1 + right.Item1, left.Item2 + right.Item2);

        public static (float, float) Multiple((float, float) left, float right) =>
            (left.Item1 * right, left.Item2 * right);

        [Benchmark]
        public bool ValueTuple_Literal() {
            (float X, float Y) x = (1f, 0f).Multiple(I);
            (float X, float Y) y = (0f, 1f).Multiple(I);
            (float X, float Y) z = (1f, 1f).Multiple(I);
            return x.Add(y) == z;
        }

        [Benchmark]
        public bool ValueTuple_Raw() {
            (float X, float Y) x = (1f, 0f);
            x.X *= I;
            x.Y *= I;
            (float X, float Y) y = (0f, 1f);
            y.X *= I;
            y.Y *= I;
            (float X, float Y) z = (1f, 1f);
            z.X *= I;
            z.Y *= I;
            return (x.X + y.X, x.Y + y.Y) == z;
        }

        [Benchmark]
        public bool ValueTuple_Cast() {
            (float, float) x = ((float, float))(1d, 0d);
            x = Multiple(x, I);
            (float, float) y = ((float, float))(0d, 1d);
            y = Multiple(y, I);
            (float, float) z = ((float, float))(1d, 1d);
            z = Multiple(z, I);
            return Add(x, y) == z;
        }

        [Benchmark]
        public bool ValueTuple_ExtendDirect() {
            var x = (1f, 0f).Multiple(I);
            var y = (0f, 1f).Multiple(I);
            var z = (1f, 1f).Multiple(I);
            return x.Add(y) == z;
        }

        [Benchmark]
        public bool ValueTuple_Property() {
            var x = ValueTupleExtensions.VecF2_UnitX().Multiple_Property(I);
            var y = ValueTupleExtensions.VecF2_UnitY().Multiple_Property(I);
            var z = ValueTupleExtensions.VecF2_One().Multiple_Property(I);
            return x.Add_Property(y) == z;
        }

        // インスタンスメソッドとクラスメソッドの呼び出しの差
        [Benchmark]
        public bool MyStruct_DirectCall() {
            var x = MyStructVectorF2.Multiple(MyStructVectorF2.UnitX, I);
            var y = MyStructVectorF2.Multiple(MyStructVectorF2.UnitY, I);
            var z = MyStructVectorF2.Multiple(MyStructVectorF2.One, I);
            return MyStructVectorF2.Add(x, y) == z;
        }
#pragma warning restore IDE0059 // 値の不必要な代入
#pragma warning restore IDE0042 // 変数の宣言を分解
    }
}
