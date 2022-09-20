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
    public class VectorFloat2Bench_Init: VectorFloat2Bench_2
    {
#pragma warning disable IDE0059 // 値の不必要な代入
#pragma warning disable IDE0042 // 変数の宣言を分解
        // 定数をコンストラクタで先に定義するか否かの検証
        SN::Vector2 Vector2_UnitX = SN::Vector2.UnitX,
            Vector2_UnitY = SN::Vector2.UnitY,
            Vector2_One = SN::Vector2.One;

        UE::Vector2 UEV2_UnitX = UE.Vector2.right,
            UEV2_UnitY = UE.Vector2.up,
            UEV2_One = UE.Vector2.one;

        MyClassVectorF2 MyClass_UnitX = MyClassVectorF2.UnitX,
            MyClass_UnitY = MyClassVectorF2.UnitY,
            MyClass_One = MyClassVectorF2.One;

        MyStructVectorF2 MyStruct_UnitX = MyStructVectorF2.UnitX,
            MyStruct_UnitY = MyStructVectorF2.UnitY,
            MyStruct_One = MyStructVectorF2.One;

        (float, float) ValueTuple_UnitX = (1f, 0f),
            ValueTuple_UnitY = (0f, 1f),
            ValueTuple_One = (1f, 1f);

        WrapValueTupleVectorF2 ValueTupleW_UnitX = new WrapValueTupleVectorF2(1f, 0f),
            ValueTupleW_UnitY = new WrapValueTupleVectorF2(0f, 1f),
            ValueTupleW_One = new WrapValueTupleVectorF2(1f, 1f);

        Tuple<float, float> Tuple_UnitX = new Tuple<float, float>(1f, 0f),
            Tuple_UnitY = new Tuple<float, float>(0f, 1f),
            Tuple_One = new Tuple<float, float>(1f, 1f);

        MyTupleVectorF2 TupleC_UnitX = MyTupleVectorF2.UnitX,
            TupleC_UnitY = MyTupleVectorF2.UnitY,
            TupleC_One = MyTupleVectorF2.One;

        WrapTupleVectorF2 TupleW_UnitX = WrapTupleVectorF2.UnitX,
            TupleW_UnitY = WrapTupleVectorF2.UnitY,
            TupleW_One = WrapTupleVectorF2.One;

        float[] Array_UnitX = new[] { 1f, 0f },
            Array_UnitY = new[] { 0f, 1f },
            Array_One = new[] { 1f, 1f };

        WrapArrayVectorF2 ArrayW_UnitX = WrapArrayVectorF2.UnitX,
            ArrayW_UnitY = WrapArrayVectorF2.UnitY,
            ArrayW_One = WrapArrayVectorF2.One;

        List<float> List_UnitX = new List<float>() { 1f, 0f },
            List_UnitY = new List<float>() { 0f, 1f },
            List_One = new List<float>() { 1f, 1f };

        MyListVectorF2 ListC_UnitX = MyListVectorF2.UnitX,
            ListC_UnitY = MyListVectorF2.UnitY,
            ListC_One = MyListVectorF2.One;

        ParallelQuery<float> ListP_UnitX = new List<float>() { 1f, 0f }.AsParallel(),
            ListP_UnitY = new List<float>() { 0f, 1f }.AsParallel(),
            ListP_One = new List<float>() { 1f, 1f }.AsParallel();

        float[] floatArray8Solid_UnitX = { 1f, 0f, 0f, 0f, 0f, 0f, 0f, 0f },
            floatArray8Solid_UnitY = { 0f, 1f, 0f, 0f, 0f, 0f, 0f, 0f },
            floatArray8Solid_One = { 1f, 1f, 0f, 0f, 0f, 0f, 0f, 0f },
            floatArray_UnitX, floatArray_UnitY, floatArray_One;

        Vector<float> VectorT_UnitX, VectorT_UnitY, VectorT_One;

        public VectorFloat2Bench_Init() {
            floatArray_UnitX = new float[Vector<float>.Count];
            floatArray_UnitX[0] = 1f;
            floatArray_UnitY = new float[Vector<float>.Count];
            floatArray_UnitY[1] = 1f;
            floatArray_One = new float[Vector<float>.Count];
            floatArray_One[0] = 1f;
            floatArray_One[1] = 1f;

            VectorT_UnitX = new Vector<float>(floatArray_UnitX);
            VectorT_UnitY = new Vector<float>(floatArray_UnitY);
            VectorT_One = new Vector<float>(floatArray_One);
        }

        [Benchmark]
        public bool Vector2_Init() {
            var x = Vector2_UnitX * I;
            var y = Vector2_UnitY * I;
            var z = Vector2_One * I;
            return x + y == z;
        }

        [Benchmark]
        public bool UnityEngine_Init() {
            var x = UEV2_UnitX * I;
            var y = UEV2_UnitY * I;
            var z = UEV2_One * I;
            return x + y == z;
        }

        [Benchmark]
        public bool MyClass_Init() {
            var x = MyClass_UnitX * I;
            var y = MyClass_UnitY * I;
            var z = MyClass_One * I;
            return x + y == z;
        }

        [Benchmark]
        public bool MyStruct_Init() {
            var x = MyStruct_UnitX * I;
            var y = MyStruct_UnitY * I;
            var z = MyStruct_One * I;
            return x + y == z;
        }

        [Benchmark]
        public bool ValueTuple_Extend_Init() {
            var x = ValueTuple_UnitX.Multiple(I);
            var y = ValueTuple_UnitY.Multiple(I);
            var z = ValueTuple_One.Multiple(I);
            return x.Add(y) == z;
        }

        [Benchmark]
        public bool ValueTuple_Wrap_Init() {
            var x = ValueTupleW_UnitX * I;
            var y = ValueTupleW_UnitY * I;
            var z = ValueTupleW_One * I;
            return x + y == z;
        }

        [Benchmark]
        public bool Tuple_Extend_Init() {
            var x = Tuple_UnitX.Multiple(I);
            var y = Tuple_UnitY.Multiple(I);
            var z = Tuple_One.Multiple(I);
            return x.Add(y).Equals(z);
        }

        [Benchmark]
        public bool Tuple_Class_Init() {
            var x = TupleC_UnitX * I;
            var y = TupleC_UnitY * I;
            var z = TupleC_One * I;
            return x + y == z;
        }

        [Benchmark]
        public bool Tuple_Wrap_Init() {
            var x = TupleW_UnitX * I;
            var y = TupleW_UnitY * I;
            var z = TupleW_One * I;
            return x + y == z;
        }

        [Benchmark]
        public bool Array_Extend_Init() {
            var x = Array_UnitX.Multiple(I);
            var y = Array_UnitY.Multiple(I);
            var z = Array_One.Multiple(I);
            return x.Add(y).EachEquals(z);
        }

        [Benchmark]
        public bool Array_Wrap_Init() {
            var x = ArrayW_UnitX * I;
            var y = ArrayW_UnitY * I;
            var z = ArrayW_One * I;
            return x + y == z;
        }

        [Benchmark]
        public bool List_Class_Init() {
            var x = ListC_UnitX * I;
            var y = ListC_UnitY * I;
            var z = ListC_One * I;
            return x + y == z;
        }

        [Benchmark]
        public bool List_Extend_Init() {
            var x = List_UnitX.Multiple(I);
            var y = List_UnitY.Multiple(I);
            var z = List_One.Multiple(I);
            return x.Add(y).EachEquals(z);
        }

        [Benchmark]
        public bool List_ExtendParallel_Init() {
            var x = ListP_UnitX.Multiple_Parallel(I);
            var y = ListP_UnitY.Multiple_Parallel(I);
            var z = ListP_One.Multiple_Parallel(I);
            return x.Add_Parallel(y).Equals_Parallel(z);
        }

#pragma warning restore IDE0059 // 値の不必要な代入
#pragma warning restore IDE0042 // 変数の宣言を分解
    }
}
