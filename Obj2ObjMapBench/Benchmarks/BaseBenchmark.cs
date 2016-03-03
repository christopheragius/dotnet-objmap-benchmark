using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace Obj2ObjMapBench
{
    public abstract class BaseBenchmark
    {
        const int iterations = 1;

        protected IEnumerable<Person> _simpleData;
        protected IEnumerable<Person> _nestedData;

        [Setup]
        public void Setup()
        {
            _simpleData = GenerateSampleData(iterations, false);
            _nestedData = GenerateSampleData(iterations, false);
        }

        [Benchmark]
        public void SimpleMap()
        {
            for (int i = 0; i < _simpleData.Count(); i++)
                Map(_simpleData.ElementAt(i));
        }

        [Benchmark]
        public void NestedMap()
        {
            for (int i = 0; i < _nestedData.Count(); i++)
                Map(_nestedData.ElementAt(i));
        }

        public abstract void Map(Person person);

        static IList<Person> GenerateSampleData(int neededRecords, bool complex)
        {
            var factory = AutoPoco.AutoPocoContainer.Configure(c =>
            {
                c.Conventions(o => o.UseDefaultConventions());
                c.Include<Person>()
                 .Setup(p => p.FirstName).Use<AutoPoco.DataSources.FirstNameSource>()
                 .Setup(p => p.LastName).Use<AutoPoco.DataSources.LastNameSource>();
                c.Include<Address>()
                 .Setup(a => a.City).Use<AutoPoco.DataSources.CitySource>()
                 .Setup(a => a.StreetName).Use<AutoPoco.DataSources.StreetSource>()
                 .Setup(a => a.ZipCode).Use<AutoPoco.DataSources.PostalSource>();
            });

            var session = factory.CreateSession();

            return session
                    .List<Person>(neededRecords)
                    .Impose(p => p.ResidenceAddress,
                        (complex) ? session.Single<Address>().Get() : null)
                    .Get();
        }
    }
}
