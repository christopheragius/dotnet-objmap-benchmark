using AutoMapper;
using Obj2ObjMapBench.Models;
using System.Linq;

namespace Obj2ObjMapBench
{
    public class AutoMapperBenchmark : BaseBenchmark
    {
        public AutoMapperBenchmark()
        {
            Mapper.CreateMap<SimplePoco, SimplePocoDTO>().IgnoreAllUnmappedProperties();
            Mapper.CreateMap<NestedPoco, NestedPocoDTO>().IgnoreAllUnmappedProperties();
        }      

        public override TDest Map<TSource, TDest>(TSource source)
        {
            return Mapper.Map<TDest>(source);
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
