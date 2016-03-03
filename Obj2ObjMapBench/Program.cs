using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Obj2ObjMapBench
{
    class Program
    {
        static Stopwatch stopWatch = new Stopwatch();

        static void Main(string[] args)
        {
            Console.WriteLine("Running benchmarks...");
            Console.WriteLine();

            var benchmarksToRun = new Dictionary<string, Type>();
            benchmarksToRun.Add("Handwritten", typeof(HandwrittenBenchmark));
            benchmarksToRun.Add("AutoMapperBenchmark", typeof(AutoMapperBenchmark));
            benchmarksToRun.Add("TinyMapperBenchmark", typeof(TinyMapperBenchmark));
            benchmarksToRun.Add("SafeMapperBenchmark", typeof(SafeMapperBenchmark));
            benchmarksToRun.Add("ValueInjecterBenchmark", typeof(ValueInjecterBenchmark));
            benchmarksToRun.Add("EmitMapperBenchmark", typeof(EmitMapperBenchmark));

            var summaries = new List<Summary>();
            foreach (var item in benchmarksToRun)
                summaries.Add(BenchmarkRunner.Run(item.Value));

            Console.WriteLine("Results Summary");
            Console.WriteLine(
                        string.Join(" \t| ",
                            "Type",
                            "Method",
                            "Median",
                            "StdDev"
                        ));
            foreach (var s in summaries)
            {
                foreach (var b in s.Reports)
                {
                    Console.WriteLine(
                        string.Join(" \t| ",
                            b.Key.Target.Type.Name,
                            b.Key.Target.MethodTitle,
                            b.Value.ResultStatistics.Median.ToString("N2"),
                            b.Value.ResultStatistics.StandardDeviation.ToString("N2")
                        ));
                }
            }

            Console.ReadLine();
        }
    }
}
