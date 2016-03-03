using AutoMapper;
using System.Linq;

namespace Obj2ObjMapBench
{
    public class AutoMapperBenchmark : BaseBenchmark
    {
        public AutoMapperBenchmark()
        {
            Mapper.CreateMap<Person, PersonDTO>().IgnoreAllUnmappedProperties();
            Mapper.CreateMap<Address, AddressDTO>().IgnoreAllUnmappedProperties();
        }      

        public override void Map(Person person)
        {
            Mapper.Map<PersonDTO>(person);
        }
    }

    public static class AutomapperExtensions
    {
        public static AutoMapper.IMappingExpression<TSource, TDest>
            IgnoreAllUnmappedProperties<TSource, TDest>(
                this AutoMapper.IMappingExpression<TSource, TDest> @this)
        {

            var sourceType = typeof(TSource);
            var destinationType = typeof(TDest);

            var existingMaps = Mapper.GetAllTypeMaps()
                .First(x => x.SourceType.Equals(sourceType) &&
                    x.DestinationType.Equals(destinationType));

            foreach (var prop in existingMaps.GetUnmappedPropertyNames())
                @this.ForMember(prop, x => x.Ignore());

            return @this;
        }

    }
}
