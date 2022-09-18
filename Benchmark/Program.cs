// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using BenchmarkDotNet.Running;
using Benchmark.Vectors;


//var x = new Vector2Bench();
//x.VectorFloat2_Static_Bench();
var summary = BenchmarkRunner.Run<Vector2Bench>();

Console.Write("End...");
Console.ReadLine();
