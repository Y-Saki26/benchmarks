// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using BenchmarkDotNet.Running;
using Benchmark.Vectors;
using Benchmark.Vectors.VectorFloat2;


Console.WriteLine("Whilch task? ( Float2 | Double2 )");
var s = Console.ReadLine();
switch(s) {
    case "Float2":
        BenchmarkRunner.Run<VectorFloat2Bench>();
        break;
    case "Double2":
        BenchmarkRunner.Run<Vector2Bench>();
        break;
    default:
        Console.WriteLine("Unexpected option entered.");
        break;
}

Console.WriteLine(new System.Numerics.Vector<float>(1f));

Console.Write("End...");
Console.ReadLine();
