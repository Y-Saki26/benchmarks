#define SECOND_RUN

using System;
using System.Numerics;
using BenchmarkDotNet.Attributes;
using UE = UnityEngine;

namespace Benchmark.Vectors
{
    /// <summary>
    /// Benchmarks of `(1, 0) x i + (0, 1) x i == (1, 1) x i` for i in 0..N
    /// </summary>
    //[MemoryDiagnoser]
    [AllStatisticsColumn]
    [ShortRunJob]
    public class Vector2Bench
    {
#pragma warning disable IDE0059 // 値の不必要な代入
#pragma warning disable IDE0042 // 変数の宣言を分解
        [Params(10, 100, 1000)]
        public int N { get; set; }

#if !SECOND_RUN
        /*
        /// <summary>
        /// Benchmark of System.Numerics.Vector2
        /// </summary>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Benchmark of UnityEngine.Vector2
        /// </summary>
        /// <exception cref="Exception"></exception>
        [Benchmark]
        public void UEVector2_Bench() {
            for(int i = 0; i < N; i++) {
                var x = UE.Vector2.right * i;
                var y = UE.Vector2.up * i;
                var z = UE.Vector2.one * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }
        */

        /*
        /// <summary>
        /// Benchmark of Tuple<double, double>
        /// </summary>
        /// <exception cref="Exception"></exception>
        [Benchmark]
        public void Tuple2_Bench() {
            var X = new Tuple<double, double>(1d, 0d);
            var Y = new Tuple<double, double>(0d, 1d);
            var One = new Tuple<double, double>(1d, 1d);
            for(int i = 0; i < N; i++) {
                var x = X.Multiple(i);
                var y = Y.Multiple(i);
                var z = One.Multiple(i);
                if(!x.Add(y).Equals(z))
                    throw new Exception($"assert error: {x} + {y} = {x.Add(y)} != {z}");
            }
        }
        
        /// <summary>
        /// Benchmark of Tuple<float, float>
        /// </summary>
        /// <exception cref="Exception"></exception>
        [Benchmark]
        public void Tuple2Float_Bench() {
            for(int i = 0; i < N; i++) {
                var x = new Tuple<float, float>(1f, 0f).Multiple(i);
                var y = new Tuple<float, float>(0f, 1f).Multiple(i);
                var z = new Tuple<float, float>(1f, 1f).Multiple(i);
                if(!x.Add(y).Equals(z))
                    throw new Exception($"assert error: {x} + {y} = {x.Add(y)} != {z}");
            }
        }

        /// <summary>
        /// Benchmark of (double, double), using extension method
        /// </summary>
        /// <exception cref="Exception"></exception>
        [Benchmark(Baseline = true)]
        public void ValueTuple2_Bench() {
            for(int i = 0; i < N; i++) {
                (double X, double Y) x = (1d, 0d).Multiple(i);
                (double X, double Y) y = (0d, 1d).Multiple(i);
                (double X, double Y) z = (1d, 1d).Multiple(i);
                if(x.Add(y) != z)
                    throw new Exception("assert error");
            }
        }

        /// <summary>
        /// Benchmark of (float, float)
        /// </summary>
        /// <exception cref="Exception"></exception>
        [Benchmark]
        public void ValueTuple2Float_Bench() {
            for(int i = 0; i < N; i++) {
                var x = (1f, 0f).Multiple(i);
                var y = (0f, 1f).Multiple(i);
                var z = (1f, 1f).Multiple(i);
                if(x.Add(y) != z)
                    throw new Exception("assert error");
            }
        }

        /// <summary>
        /// Benchmark of User-defined class:
        ///   X: double
        ///   Y: double
        /// </summary>
        /// <exception cref="Exception"></exception>
        [Benchmark]
        public void MyVector2_Bench() {
            for(int i = 0; i < N; i++) {
                var x = MyVector2.UnitX * i;
                var y = MyVector2.UnitY * i;
                var z = MyVector2.One * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        /// <summary>
        /// Benchmark of User-defined class:
        ///   X: float
        ///   Y: float
        /// </summary>
        /// <exception cref="Exception"></exception>
        [Benchmark]
        public void MyVector2Float_Bench() {
            for(int i = 0; i < N; i++) {
                var x = MyVector2Float.UnitX * i;
                var y = MyVector2Float.UnitY * i;
                var z = MyVector2Float.One * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        /// <summary>
        /// Benchmark of User-defined struct:
        ///   X: double
        ///   Y: double
        /// </summary>
        /// <exception cref="Exception"></exception>
        [Benchmark]
        public void MyStructVector2_Bench() {
            for(int i = 0; i < N; i++) {
                var x = MyStructVector2.UnitX * i;
                var y = MyStructVector2.UnitY * i;
                var z = MyStructVector2.One * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        /// <summary>
        /// Benchmark of User-defined struct:
        ///   X: float
        ///   Y: float
        /// </summary>
        /// <exception cref="Exception"></exception>
        [Benchmark]
        public void MyStructVector2Float_Bench() {
            for(int i = 0; i < N; i++) {
                var x = MyStructVector2Float.UnitX * i;
                var y = MyStructVector2Float.UnitY * i;
                var z = MyStructVector2Float.One * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        /// <summary>
        /// Benchmark of User-defined class extends Tuple<double, double>
        /// </summary>
        /// <exception cref="Exception"></exception>
        [Benchmark]
        public void MyTupleVector2_Bench() {
            for(int i = 0; i < N; i++) {
                var x = MyTupleVector2.UnitX * i;
                var y = MyTupleVector2.UnitY * i;
                var z = MyTupleVector2.One * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        /// <summary>
        /// Benchmark of User-defined class extends Tuple<float, float>
        /// </summary>
        /// <exception cref="Exception"></exception>
        [Benchmark]
        public void MyTupleVector2Float_Bench() {
            for(int i = 0; i < N; i++) {
                var x = MyTupleVector2Float.UnitX * i;
                var y = MyTupleVector2Float.UnitY * i;
                var z = MyTupleVector2Float.One * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        /// <summary>
        /// Benchmark of User-defined class:
        ///   _values: double[]
        ///   X => _values[0]
        ///   Y => _values[1]
        /// </summary>
        /// <exception cref="Exception"></exception>
        [Benchmark]
        public void MyArrayVector2_Bench() {
            for(int i = 0; i < N; i++) {
                var x = MyArrayVector2.UnitX * i;
                var y = MyArrayVector2.UnitY * i;
                var z = MyArrayVector2.One * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        /// <summary>
        /// Benchmark of User-defined class:
        ///   _values: float[]
        ///   X => _values[0]
        ///   Y => _values[1]
        /// </summary>
        /// <exception cref="Exception"></exception>
        [Benchmark]
        public void MyArrayVector2Float_Bench() {
            for(int i = 0; i < N; i++) {
                var x = MyArrayVector2Float.UnitX * i;
                var y = MyArrayVector2Float.UnitY * i;
                var z = MyArrayVector2Float.One * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        /// <summary>
        /// Benchmark of double[], using extension method
        /// </summary>
        /// <exception cref="Exception"></exception>
        [Benchmark]
        public void ExtensionArray2_Bench() {
            for(int i = 0; i < N; i++) {
                double[] x = new[] { 1d, 0d }.Multiple(i);
                double[] y = new[] { 0d, 1d }.Multiple(i);
                double[] z = new[] { 1d, 1d }.Multiple(i);
                if(!x.Add(y).EachEquals(z))
                    throw new Exception("assert error");
            }
        }

        /// <summary>
        /// Benchmark of System.Numerics.Vector2 without assertion
        /// </summary>
        [Benchmark]
        public void Vector2_NoAssert_Bench() {
            for(int i = 0; i < N; i++) {
                var x = Vector2.UnitX * i;
                var y = Vector2.UnitY * i;
                var z = Vector2.One * i;
                bool w = x + y != z;
            }
        }

        /// <summary>
        /// Benchmark of System.Numerics.Vector2 without comparison of (x + y) == z
        /// </summary>
        [Benchmark]
        public void Vector2_NoCompare_Bench() {
            for(int i = 0; i < N; i++) {
                var x = Vector2.UnitX * i;
                var y = Vector2.UnitY * i;
                var z = Vector2.One * i;
                var w = x + y;
            }
        }

        /// <summary>
        /// Benchmark of System.Numerics.Vector2 without addition of x + y
        /// </summary>
        [Benchmark]
        public void Vector2_NoAdd_Bench() {
            for(int i = 0; i < N; i++) {
                var x = Vector2.UnitX * i;
                var y = Vector2.UnitY * i;
                var z = Vector2.One * i;
            }
        }

        /// <summary>
        /// Benchmark of (double, double), using usual method
        /// </summary>
        /// <exception cref="Exception"></exception>
        [Benchmark]
        public void ValueTuple2_Method_Bench() {
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

        /// <summary>
        /// Benchmark of (double, double) when each element is computed individually without using methods.
        /// </summary>
        /// <exception cref="Exception"></exception>
        [Benchmark]
        public void ValueTuple2_Raw_Bench() {
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

        /// <summary>
        /// Benchmark of (double, double) without assertion
        /// </summary>
        [Benchmark]
        public void ValueTuple2_NoAssert_Bench() {
            for(int i = 0; i < N; i++) {
                (double X, double Y) x = (1d, 0d).Multiple(i);
                (double X, double Y) y = (0d, 1d).Multiple(i);
                (double X, double Y) z = (1d, 1d).Multiple(i);
                bool w = x.Add(y) != z;
            }
        }

        /// <summary>
        /// Benchmark of (double, double) without comparison of (x + y) == z
        /// </summary>
        [Benchmark]
        public void ValueTuple2_NoCompare_Bench() {
            for(int i = 0; i < N; i++) {
                (double X, double Y) x = (1d, 0d).Multiple(i);
                (double X, double Y) y = (0d, 1d).Multiple(i);
                (double X, double Y) z = (1d, 1d).Multiple(i);
                var w = x.Add(y);
            }
        }

        /// <summary>
        /// Benchmark of (double, double) without addition of x + y
        /// </summary>
        [Benchmark]
        public void ValueTuple2_NoAdd_Bench() {
            for(int i = 0; i < N; i++) {
                (double X, double Y) x = (1d, 0d).Multiple(i);
                (double X, double Y) y = (0d, 1d).Multiple(i);
                (double X, double Y) z = (1d, 1d).Multiple(i);
            }
        }

        /// <summary>
        /// Benchmark of (double, double) with inference from literal number to double
        /// </summary>
        [Benchmark]
        public void ValueTuple2_Inference_Bench() {
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

        /// <summary>
        /// Benchmark of User-defined class, comparing when using methods instead of operators
        /// </summary>
        /// <exception cref="Exception"></exception>
        [Benchmark]
        public void MyVector2_Call_Bench() {
            for(int i = 0; i < N; i++) {
                var x = MyVector2.Multiple(MyVector2.UnitX, i);
                var y = MyVector2.Multiple(MyVector2.UnitY, i);
                var z = MyVector2.Multiple(MyVector2.One, i);
                if(MyVector2.Add(x, y) != z)
                    throw new Exception("assert error");
            }
        }
        */
#else
        /// <summary>
        /// Benchmark of (double, double), using extension method
        /// </summary>
        /// <exception cref="Exception"></exception>
        [Benchmark(Baseline = true)]
        public void ValueTuple2_Bench() {
            for(int i = 0; i < N; i++) {
                (double X, double Y) x = (1d, 0d).Multiple(i);
                (double X, double Y) y = (0d, 1d).Multiple(i);
                (double X, double Y) z = (1d, 1d).Multiple(i);
                if(x.Add(y) != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void Vector2_Init_Bench() {
            var X = Vector2.UnitX;
            var Y = Vector2.UnitY;
            var One = Vector2.One;
            for(int i = 0; i < N; i++) {
                var x = X * i;
                var y = Y * i;
                var z = One * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void UEVector2_Init_Bench() {
            var X = UE.Vector2.right;
            var Y = UE.Vector2.up;
            var One = UE.Vector2.one;
            for(int i = 0; i < N; i++) {
                var x = X * i;
                var y = Y * i;
                var z = One * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }


        [Benchmark]
        public void VectorFloat2_Bench() {
            var X = new float[Vector<float>.Count];
            X[0] = 1f;
            var Y = new float[Vector<float>.Count];
            Y[1] = 1f;
            var One = new float[Vector<float>.Count];
            One[0] = 1f;
            One[1] = 1f;
            for(int i = 0; i < N; i++) {
                var x = new Vector<float>(X) * i;
                var y = new Vector<float>(Y) * i;
                var z = new Vector<float>(One) * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void VectorDouble2_Bench() {
            var X = new double[Vector<float>.Count];
            X[0] = 1d;
            var Y = new double[Vector<float>.Count];
            Y[1] = 1d;
            var One = new double[Vector<float>.Count];
            One[0] = 1d;
            One[1] = 1d;
            for(int i = 0; i < N; i++) {
                var x = new Vector<double>(X) * i;
                var y = new Vector<double>(Y) * i;
                var z = new Vector<double>(One) * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        static Vector<float> VectorFloatX {
            get {
                var X = new float[Vector<float>.Count];
                X[0] = 1f;
                return new Vector<float>(X);
            }
        }

        static Vector<float> VectorFloatY {
            get {
                var Y = new float[Vector<float>.Count];
                Y[1] = 1f;
                return new Vector<float>(Y);
            }
        }

        static Vector<float> VectorFloatOne {
            get {
                var One = new float[Vector<float>.Count];
                One[0] = 1f;
                One[1] = 1f;
                return new Vector<float>(One);
            }
        }


        [Benchmark]
        public void VectorFloat2_Static_Bench() {
            for(int i = 0; i < N; i++) {
                var x = VectorFloatX * i;
                var y = VectorFloatY * i;
                var z = VectorFloatOne * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void VectorFloat2_Init_Bench() {
            var X = VectorFloatX;
            var Y = VectorFloatY;
            var One = VectorFloatOne;
            for(int i = 0; i < N; i++) {
                var x = X * i;
                var y = Y * i;
                var z = One * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void Tuple2Float_Init_Bench() {
            var X = new Tuple<float, float>(1f, 0f);
            var Y = new Tuple<float, float>(0f, 1f);
            var One = new Tuple<float, float>(1f, 1f);
            for(int i = 0; i < N; i++) {
                var x = X.Multiple(i);
                var y = Y.Multiple(i);
                var z = One.Multiple(i);
                if(!x.Add(y).Equals(z))
                    throw new Exception($"assert error: {x} + {y} = {x.Add(y)} != {z}");
            }
        }

        [Benchmark]
        public void ValueTuple2Float_Init_Bench() {
            var X = (1f, 0f);
            var Y = (0f, 1f);
            var One = (1f, 1f);
            for(int i = 0; i < N; i++) {
                var x = X.Multiple(i);
                var y = Y.Multiple(i);
                var z = One.Multiple(i);
                if(x.Add(y) != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void MyVector2Float_Init_Bench() {
            var X = MyVector2Float.UnitX;
            var Y = MyVector2Float.UnitY;
            var One = MyVector2Float.One;
            for(int i = 0; i < N; i++) {
                var x = X * i;
                var y = Y * i;
                var z = One * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void MyStructVector2Float_Init_Bench() {
            var X = MyStructVector2Float.UnitX;
            var Y = MyStructVector2Float.UnitY;
            var One = MyStructVector2Float.One;
            for(int i = 0; i < N; i++) {
                var x = X * i;
                var y = Y * i;
                var z = One * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void MyTupleVector2Float_Init_Bench() {
            var X = MyTupleVector2Float.UnitX;
            var Y = MyTupleVector2Float.UnitY;
            var One = MyTupleVector2Float.One;
            for(int i = 0; i < N; i++) {
                var x = X * i;
                var y = Y * i;
                var z = One * i;
                if(x + y != z)
                    throw new Exception("assert error");
            }
        }

        [Benchmark]
        public void ExtensionArray2_Init_Bench() {
            var X = new[] { 1d, 0d };
            var Y = new[] { 0d, 1d };
            var One = new[] { 1d, 1d };
            for(int i = 0; i < N; i++) {
                double[] x = X.Multiple(i);
                double[] y = Y.Multiple(i);
                double[] z = One.Multiple(i);
                if(!x.Add(y).EachEquals(z))
                    throw new Exception("assert error");
            }
        }
#endif
#pragma warning restore IDE0059 // 値の不必要な代入
#pragma warning restore IDE0042 // 変数の宣言を分解
    }
}
