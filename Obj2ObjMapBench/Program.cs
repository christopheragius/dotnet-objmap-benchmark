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
            benchmarksToRun.Add("AgileMapperBenchmark", typeof(AgileMapperBenchmark));
            benchmarksToRun.Add("AutoMapperBenchmark", typeof(AutoMapperBenchmark));
            benchmarksToRun.Add("EmitMapperBenchmark", typeof(EmitMapperBenchmark));
            //benchmarksToRun.Add("ExpressMapper", typeof(ExpressMapperBenchmark));
            benchmarksToRun.Add("MapsterBenchmark", typeof(MapsterBenchmark));
            //benchmarksToRun.Add("TinyMapperBenchmark", typeof(TinyMapperBenchmark));
            benchmarksToRun.Add("SafeMapperBenchmark", typeof(SafeMapperBenchmark));
            benchmarksToRun.Add("ValueInjecterBenchmark", typeof(ValueInjecterBenchmark));


            var summaries = new List<Summary>();
            foreach (var item in benchmarksToRun)
                summaries.Add(BenchmarkRunner.Run(item.Value));
        }


        static void GenerateSampleData(int iterations)
        {
            var factory = AutoPoco.AutoPocoContainer.Configure(c =>
            {
                c.Conventions(o => o.UseDefaultConventions());

                c.Include<Models.SimplePoco>()
                 .Setup(p => p.Id).Use<AutoPoco.DataSources.IntegerIdSource>()
                 .Setup(p => p.Name).Use<AutoPoco.DataSources.FirstNameSource>()
                 .Setup(p => p.CreatedOn).Use<AutoPoco.DataSources.DateTimeSource>()
                 .Setup(p => p.Enabled).Use<AutoPoco.DataSources.BooleanSource>();

                c.Include<Models.NestedPoco>();
            });

            var session = factory.CreateSession();

            var _simpleData = session.Collection<Models.SimplePoco>(iterations);

            var _nestedData = session.List<Models.NestedPoco>(iterations)
                    .Impose(o => o.NestedObjects,
                                 session.List<Models.NestedPoco>(5)
                                        .Impose(s => s.NestedObjects,
                                                     session.Collection<Models.NestedPoco>(10)).Get())
                    .Get();
        }
    }
}
