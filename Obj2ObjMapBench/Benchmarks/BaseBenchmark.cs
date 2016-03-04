using BenchmarkDotNet.Attributes;
using Obj2ObjMapBench.Models;
using System.Collections.Generic;
using System.Linq;

namespace Obj2ObjMapBench
{
    public abstract class BaseBenchmark
    {
        const int iterations = 10000;

        protected IEnumerable<SimplePoco> _simpleData;
        protected IEnumerable<NestedPoco> _nestedData;

        [Setup]
        public void Setup()
        {
            GenerateSampleData(iterations);
        }

        [Benchmark]
        public void SimpleMap()
        {
            for (int i = 0; i < _simpleData.Count(); i++)
                Map<SimplePoco, SimplePocoDTO>(_simpleData.ElementAt(i));
        }

        [Benchmark]
        public void NestedMap()
        {
            for (int i = 0; i < _nestedData.Count(); i++)
                Map<NestedPoco, NestedPocoDTO>(_nestedData.ElementAt(i));
        }

        public abstract TDest Map<TSource, TDest>(TSource source) where TDest : class;

        void GenerateSampleData(int iterations)
        {
            var factory = AutoPoco.AutoPocoContainer.Configure(c =>
            {
                c.Conventions(o => o.UseDefaultConventions());

                c.Include<SimplePoco>()
                 .Setup(p => p.Id).Use<AutoPoco.DataSources.IntegerIdSource>()
                 .Setup(p => p.Name).Use<AutoPoco.DataSources.FirstNameSource>()
                 .Setup(p => p.CreatedOn).Use<AutoPoco.DataSources.DateTimeSource>()
                 .Setup(p => p.Enabled).Use<AutoPoco.DataSources.BooleanSource>()
                 .Setup(p => p.Enabled).Use<AutoPoco.DataSources.BooleanSource>()
                 .Setup(p => p.PhoneNumber).Use<AutoPoco.DataSources.DutchTelephoneSource>()
                 .Setup(p => p.Town).Use<AutoPoco.DataSources.CitySource>()
                 .Setup(p => p.ZipCode).Use<AutoPoco.DataSources.PostalSource>()
                 .Setup(p => p.Address).Use<AutoPoco.DataSources.StreetSource>()
                 .Setup(p => p.BirthDate).Use<AutoPoco.DataSources.DateOfBirthSource>()
                 .Setup(p => p.Email).Use<AutoPoco.DataSources.ExtendedEmailAddressSource>();

                c.Include<NestedPoco>();
            });

            var session = factory.CreateSession();

            _simpleData = session.Collection<SimplePoco>(iterations);

            _nestedData = session.List<NestedPoco>(iterations)
                    .Impose(o => o.NestedObjects,
                                 session.List<NestedPoco>(5)
                                        .Impose(s => s.NestedObjects,
                                                     session.Collection<NestedPoco>(10)).Get())
                    .Get();
        }
    }
}
