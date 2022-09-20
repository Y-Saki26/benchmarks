using BenchmarkDotNet.Attributes;

namespace Benchmark.Vectors.VectorFloat2
{
    [ShortRunJob]
    internal class VectorFloat2Bench_Short: VectorFloat2Bench_2
    {

        [Params(0, 1, int.MaxValue)]
        public int I { get; set; }
    }
}
