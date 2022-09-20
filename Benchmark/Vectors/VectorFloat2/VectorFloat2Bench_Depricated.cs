using System;
using System.Numerics;
using Benchmark.Vectors.VectorDouble2;
using BenchmarkDotNet.Attributes;
using UE = UnityEngine;

namespace Benchmark.Vectors.VectorFloat2
{
    /// <summary>
    /// Benchmarks of `(1, 0) x i + (0, 1) x i == (1, 1) x i` for i in 0..N
    /// </summary>
    //[MemoryDiagnoser]
    [AllStatisticsColumn]
    //[ShortRunJob]
    public class VectorFloat2Bench_Depricated
    {
#pragma warning disable IDE0059 // 値の不必要な代入
#pragma warning disable IDE0042 // 変数の宣言を分解
        [Params(10, 100, 1000)]
        public int N { get; set; }

        [Benchmark]
        public void Vector2_Bench() {
            for(int i = 0; i < N; i++) {
                var x = Vector2.UnitX * i;
                var y = Vector2.UnitY * i;
                var z = Vector2.One * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void UnityEngine_Bench() {
            for(int i = 0; i < N; i++) {
                var x = UE.Vector2.right * i;
                var y = UE.Vector2.up * i;
                var z = UE.Vector2.one * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void MyClass_Bench() {
            for(int i = 0; i < N; i++) {
                var x = MyClassVectorF2.UnitX * i;
                var y = MyClassVectorF2.UnitY * i;
                var z = MyClassVectorF2.One * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark(Baseline = true)]
        public void MyStruct_Bench() {
            for(int i = 0; i < N; i++) {
                var x = MyStructVectorF2.UnitX * i;
                var y = MyStructVectorF2.UnitY * i;
                var z = MyStructVectorF2.One * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void ValueTuple_Extend_Bench() {
            for(int i = 0; i < N; i++) {
                var x = ValueTupleExtensions.VecF2_UnitX().Multiple(i);
                var y = ValueTupleExtensions.VecF2_UnitY().Multiple(i);
                var z = ValueTupleExtensions.VecF2_One().Multiple(i);
                if(x.Add(y) != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void ValueTuple_Wrap_Bench() {
            for(int i = 0; i < N; i++) {
                var x = WrapValueTupleVectorF2.UnitX * i;
                var y = WrapValueTupleVectorF2.UnitY * i;
                var z = WrapValueTupleVectorF2.One * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void Tuple_Extend_Bench() {
            for(int i = 0; i < N; i++) {
                var x = TupleExtensions.VecF2_UnitX().Multiple(i);
                var y = TupleExtensions.VecF2_UnitY().Multiple(i);
                var z = TupleExtensions.VecF2_One().Multiple(i);
                if(!x.Add(y).Equals(z))
                    throw new Exception($"assert error: {x} + {y} = {x.Add(y)} != {z}");
            }
        }

        [Benchmark]
        public void Tuple_Class_Bench() {
            for(int i = 0; i < N; i++) {
                var x = MyTupleVectorF2.UnitX * i;
                var y = MyTupleVectorF2.UnitY * i;
                var z = MyTupleVectorF2.One * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void Tuple_Wrap_Bench() {
            for(int i = 0; i < N; i++) {
                var x = WrapTupleVectorF2.UnitX * i;
                var y = WrapTupleVectorF2.UnitY * i;
                var z = WrapTupleVectorF2.One * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void Array_Extend_Bench() {
            for(int i = 0; i < N; i++) {
                var x = ArrayExtensions.VecF2_UnitX().Multiple(i);
                var y = ArrayExtensions.VecF2_UnitY().Multiple(i);
                var z = ArrayExtensions.VecF2_One().Multiple(i);
                if(!x.Add(y).EachEquals(z))
                    throw new Exception($"assert error: {x} + {y} = {x.Add(y)} != {z}");
            }
        }

        [Benchmark]
        public void Array_Wrap_Bench() {
            for(int i = 0; i < N; i++) {
                var x = WrapArrayVectorF2.UnitX * i;
                var y = WrapArrayVectorF2.UnitY * i;
                var z = WrapArrayVectorF2.One * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void List_Class_Bench() {
            for(int i = 0; i < N; i++) {
                var x = MyListVectorF2.UnitX * i;
                var y = MyListVectorF2.UnitY * i;
                var z = MyListVectorF2.One * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void Vector2_NoCompare_Bench() {
            for(int i = 0; i < N; i++) {
                var x = Vector2.UnitX * i;
                var y = Vector2.UnitY * i;
                var z = Vector2.One * i;
                var w = x + y;
            }
        }

        [Benchmark]
        public void Vector2_NoAdd_Bench() {
            for(int i = 0; i < N; i++) {
                var x = Vector2.UnitX * i;
                var y = Vector2.UnitY * i;
                var z = Vector2.One * i;
            }
        }

        [Benchmark]
        public void ValueTuple_LocalMethod_Bench() {
            for(int i = 0; i < N; i++) {
                (double, double) x = Multiple((1d, 0d), i);
                (double, double) y = Multiple((0d, 1d), i);
                (double, double) z = Multiple((1d, 1d), i);
                if(Add(x, y) != z)
                    throw new Exception("assert error");
            }
        }

        public static (double, double) Add((double, double) left, (double, double) right) =>
            (left.Item1 + right.Item1, left.Item2 + right.Item2);

        public static (double, double) Multiple((double, double) left, double right) =>
            (left.Item1 * right, left.Item2 * right);

        [Benchmark]
        public void ValueTuple_Raw_Bench() {
            for(int i = 0; i < N; i++) {
                (double X, double Y) x = (1d, 0d);
                x.X *= i;
                x.Y *= i;
                (double X, double Y) y = (0d, 1d);
                y.X *= i;
                y.Y *= i;
                (double X, double Y) z = (1d, 1d);
                z.X *= i;
                z.Y *= i;
                if((x.X + y.X, x.Y + y.Y) != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void ValueTuple_NoAssert_Bench() {
            for(int i = 0; i < N; i++) {
                (double X, double Y) x = (1d, 0d).Multiple(i);
                (double X, double Y) y = (0d, 1d).Multiple(i);
                (double X, double Y) z = (1d, 1d).Multiple(i);
                bool w = x.Add(y) != z;
            }
        }

        [Benchmark]
        public void ValueTuple_NoCompare_Bench() {
            for(int i = 0; i < N; i++) {
                (double X, double Y) x = (1d, 0d).Multiple(i);
                (double X, double Y) y = (0d, 1d).Multiple(i);
                (double X, double Y) z = (1d, 1d).Multiple(i);
                var w = x.Add(y);
            }
        }

        [Benchmark]
        public void ValueTuple_NoAdd_Bench() {
            for(int i = 0; i < N; i++) {
                (double X, double Y) x = (1d, 0d).Multiple(i);
                (double X, double Y) y = (0d, 1d).Multiple(i);
                (double X, double Y) z = (1d, 1d).Multiple(i);
            }
        }

        [Benchmark]
        public void ValueTuple_Inference_Bench() {
            for(int i = 0; i < N; i++) {
                (double, double) x = (1, 0);
                x = Multiple(x, i);
                (double, double) y = (0, 1);
                y = Multiple(y, i);
                (double, double) z = (1, 1);
                z = Multiple(z, i);
                if(Add(x, y) != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void ValueTuple_ExtendDirect_Bench() {
            for(int i = 0; i < N; i++) {
                var x = (1f, 0f).Multiple(i);
                var y = (0f, 1f).Multiple(i);
                var z = (1f, 1f).Multiple(i);
                if(x.Add(y) != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void ValueTuple_ExtendDetour_Bench() {
            for(int i = 0; i < N; i++) {
                var x = ValueTupleExtensions.VecF2_UnitX().Multiple_Method(i);
                var y = ValueTupleExtensions.VecF2_UnitY().Multiple_Method(i);
                var z = ValueTupleExtensions.VecF2_One().Multiple_Method(i);
                if(x.Add_Method(y) != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void MyStruct_DirectCall_Bench() {
            for(int i = 0; i < N; i++) {
                var x = MyStructVector2.Multiple(MyStructVector2.UnitX, i);
                var y = MyStructVector2.Multiple(MyStructVector2.UnitY, i);
                var z = MyStructVector2.Multiple(MyStructVector2.One, i);
                if(MyStructVector2.Add(x, y) != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void Void() {
            for(int i = 0; i < N; i++) {
                double x = (double)i;
                if(x == -1.0d)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void VoidContinue() {
            for(int i = 0; i < N; i++) {
                continue;
            }
        }

        [Benchmark]
        public void VoidVoid() {
            for(int i = 0; i < N; i++) {
                //continue;
            }
        }

        [Benchmark]
        public void Vector2_Init_Bench() {
            var UnitX = Vector2.UnitX;
            var UnitY = Vector2.UnitY;
            var One = Vector2.One;
            for(int i = 0; i < N; i++) {
                var x = UnitX * i;
                var y = UnitY * i;
                var z = One * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void UnityEngine_Init_Bench() {
            var UnitX = UE.Vector2.right;
            var UnitY = UE.Vector2.up;
            var One = UE.Vector2.one;
            for(int i = 0; i < N; i++) {
                var x = UnitX * i;
                var y = UnitY * i;
                var z = One * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void VectorFloat_Solid_Bench() {
            for(int i = 0; i < N; i++) {
                var x = VectorTExtends.VecF2_UnitX_Solid() * i;
                var y = VectorTExtends.VecF2_UnitY_Solid() * i;
                var z = VectorTExtends.VecF2_One_Solid() * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void VectorFloat_Cotr_Bench() {
            var UnitX = new float[Vector<float>.Count];
            UnitX[0] = 1f;
            var UnitY = new float[Vector<float>.Count];
            UnitY[1] = 1f;
            var One = new float[Vector<float>.Count];
            One[0] = 1f;
            One[1] = 1f;
            for(int i = 0; i < N; i++) {
                var x = new Vector<float>(UnitX) * i;
                var y = new Vector<float>(UnitY) * i;
                var z = new Vector<float>(One) * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void VectorFloat_Static_Bench() {
            for(int i = 0; i < N; i++) {
                var x = VectorTExtends.VecF2_UnitX() * i;
                var y = VectorTExtends.VecF2_UnitY() * i;
                var z = VectorTExtends.VecF2_One() * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void VectorFloat_Init_Bench() {
            var UnitX = VectorTExtends.VecF2_UnitX();
            var UnitY = VectorTExtends.VecF2_UnitY();
            var One = VectorTExtends.VecF2_One();
            for(int i = 0; i < N; i++) {
                var x = UnitX * i;
                var y = UnitY * i;
                var z = One * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void Tuple2Float_Init_Bench() {
            var UnitX = new Tuple<float, float>(1f, 0f);
            var UnitY = new Tuple<float, float>(0f, 1f);
            var One = new Tuple<float, float>(1f, 1f);
            for(int i = 0; i < N; i++) {
                var x = UnitX.Multiple(i);
                var y = UnitY.Multiple(i);
                var z = One.Multiple(i);
                if(!x.Add(y).Equals(z))
                    throw new Exception($"assert error: {x} + {y} = {x.Add(y)} != {z}");
            }
        }

        [Benchmark]
        public void ValueTuple2Float_Init_Bench() {
            var UnitX = (1f, 0f);
            var UnitY = (0f, 1f);
            var One = (1f, 1f);
            for(int i = 0; i < N; i++) {
                var x = UnitX.Multiple_Method(i);
                var y = UnitY.Multiple_Method(i);
                var z = One.Multiple_Method(i);
                if(x.Add_Method(y) != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void MyVector2Float_Init_Bench() {
            var UnitX = MyClassVectorF2.UnitX;
            var UnitY = MyClassVectorF2.UnitY;
            var One = MyClassVectorF2.One;
            for(int i = 0; i < N; i++) {
                var x = UnitX * i;
                var y = UnitY * i;
                var z = One * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void MyStructVector2Float_Init_Bench() {
            var UnitX = MyStructVectorF2.UnitX;
            var UnitY = MyStructVectorF2.UnitY;
            var One = MyStructVectorF2.One;
            for(int i = 0; i < N; i++) {
                var x = UnitX * i;
                var y = UnitY * i;
                var z = One * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void MyTupleVector2Float_Init_Bench() {
            var UnitX = MyTupleVectorF2.UnitX;
            var UnitY = MyTupleVectorF2.UnitY;
            var One = MyTupleVectorF2.One;
            for(int i = 0; i < N; i++) {
                var x = UnitX * i;
                var y = UnitY * i;
                var z = One * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void ExtensionArray2_Init_Bench() {
            var UnitX = new[] { 1d, 0d };
            var UnitY = new[] { 0d, 1d };
            var One = new[] { 1d, 1d };
            for(int i = 0; i < N; i++) {
                double[] x = UnitX.Multiple(i);
                double[] y = UnitY.Multiple(i);
                double[] z = One.Multiple(i);
                if(!x.Add(y).EachEquals(z))
                    throw new Exception("assert error");
            }
        }

#pragma warning restore IDE0059 // 値の不必要な代入
#pragma warning restore IDE0042 // 変数の宣言を分解
    }
}
