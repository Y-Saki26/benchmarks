// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using BenchmarkDotNet.Running;
using Benchmark.Vectors;
using Benchmark.Vectors.VectorFloat2;


Console.WriteLine("Whilch task? ( Float2 | Float2Short | Double2 )");
var s = Console.ReadLine();
switch(s) {
    case "Float2":
        BenchmarkRunner.Run<VectorFloat2Bench>();
        break;
    case "Float2Short":
        BenchmarkRunner.Run<VectorFloat2Bench_Short>();
        break;
    case "Double2":
        BenchmarkRunner.Run<Vector2Bench>();
        break;
    default:
        Console.WriteLine("Unexpected option entered.");
        break;
}

Console.Write("End...");
Console.ReadLine();
