# benchmarks

様々なベンチマーク

## ベクトル的データ構造

Zennにて結果のまとめを公開中．

### `float` 2次元ベクトル

[第①回](https://zenn.dev/ysaki51/articles/45d180e3755410)，[第②回](https://zenn.dev/ysaki51/articles/47122564898e5d) で説明．

+ 結果データ：
  [BenchmarkResults/Vectors/result1+2/](https://github.com/Y-Saki26/benchmarks/tree/main/BenchmarkResults/Vectors/result_1%2B2)
+ ベンチマークコード：
  [VectorFloat2Bench.cs](https://github.com/Y-Saki26/benchmarks/blob/main/Benchmark/Vectors/VectorFloat2/VectorFloat2Bench.cs) と [VectorFloat2Bench_Init.cs](https://github.com/Y-Saki26/benchmarks/blob/main/Benchmark/Vectors/VectorFloat2/VectorFloat2Bench_Init.cs)
+ 各データ構造(class/struct)の定義：
  [Benchmark/Vectors/VectorFloat2/*VectorF2.cs](https://github.com/Y-Saki26/benchmarks/tree/main/Benchmark/Vectors/VectorFloat2)
+ 拡張メソッドの定義：
  [Benchmark/Vectors/VectorExtensions/*Extensions.cs](https://github.com/Y-Saki26/benchmarks/tree/main/Benchmark/Vectors)
