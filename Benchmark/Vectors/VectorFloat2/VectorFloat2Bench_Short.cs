using BenchmarkDotNet.Attributes;

namespace Benchmark.Vectors.VectorFloat2
{
    [ShortRunJob]
    internal class VectorFloat2Bench_Short: VectorFloat2Bench
    {

        [Params(0, 1, 2, 3, 4, 5, 12, 123, 1234, int.MaxValue)]
        public new int I { get; set; }
    }
}
