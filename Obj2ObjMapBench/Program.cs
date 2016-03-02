using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obj2ObjMapBench
{
    class Program
    {
        static Stopwatch stopWatch = new Stopwatch();

        static void Main(string[] args)
        {
            Console.WriteLine("Running benchmarks...");
            Console.WriteLine();
            RunSet(1000000, false);
            RunSet(1000000, true);
            Console.WriteLine("Benchmarking ended...");
            Console.ReadKey();
        }

        static void RunSet(int records, bool useComplexData)
        {
            var personsData = GenerateSampleData(records, useComplexData);
            var results = new Dictionary<string, long>();

            results.Add("Handwritten", Benchmark(personsData, null,
                p =>
                {
                    var obj = new PersonDTO
                    {
                        FirstName = p.FirstName,
                        LastName = p.LastName
                    };

                    if (p.ResidenceAddress != null)
                    {
                        obj.ResidenceAddress = new AddressDTO
                        {
                            City = p.ResidenceAddress.City,
                            StreetName = p.ResidenceAddress.StreetName,
                            ZipCode = p.ResidenceAddress.ZipCode
                        };
                    }
                }));

            results.Add("AutoMapper", Benchmark(personsData, 
                () => 
                {
                    AutoMapper.Mapper.CreateMap<Person, PersonDTO>().IgnoreAllUnmappedProperties();
                    AutoMapper.Mapper.CreateMap<Address, AddressDTO>().IgnoreAllUnmappedProperties();
                }, 
                p =>
                {
                    AutoMapper.Mapper.Map<PersonDTO>(p);
                }));

            results.Add("TinyMapper", Benchmark(personsData, null, 
                p =>
                {
                    Nelibur.ObjectMapper.TinyMapper.Map<PersonDTO>(p);
                }));

            results.Add("SafeMapper", Benchmark(personsData, null, 
                p =>
                {
                    SafeMapper.SafeMap.Convert<Person, PersonDTO>(p);
                }));

            results.Add("EmitMapper", Benchmark(personsData, null,
                p =>
                {
                    EmitMapper.ObjectMapperManager.DefaultInstance.GetMapper<Person, PersonDTO>().Map(p);
                }));

            results.Add("ValueInjecter", Benchmark(personsData, null,
                p =>
                {
                    Omu.ValueInjecter.Mapper.Map<PersonDTO>(p);
                }));

            foreach (var r in results.OrderBy(o => o.Value))
                Console.WriteLine(string.Format("{0} ({2}): {1} milliseconds", 
                    r.Key, r.Value, (useComplexData ? "nested" : "simple")));

            Console.WriteLine();
        }

        static long Benchmark(IEnumerable<Person> dataset, Action configuration, 
            Action<Person> mapExecute)
        {
            stopWatch.Reset();

            if (configuration != null) configuration();

            stopWatch.Start();
            for (int i = 0; i < dataset.Count(); i++)
                mapExecute(dataset.ElementAt(i));
            stopWatch.Stop();

            return stopWatch.ElapsedMilliseconds;
        }

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
