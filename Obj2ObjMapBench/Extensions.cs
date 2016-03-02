using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obj2ObjMapBench
{
    public static class Extensions
    {
        public static AutoMapper.IMappingExpression<TSource, TDest> 
            IgnoreAllUnmappedProperties<TSource, TDest>(
                this AutoMapper.IMappingExpression<TSource, TDest> @this)
        {

            var sourceType = typeof(TSource);
            var destinationType = typeof(TDest);

            var existingMaps = AutoMapper.Mapper.GetAllTypeMaps()
                .First(x => x.SourceType.Equals(sourceType) &&
                    x.DestinationType.Equals(destinationType));

            foreach (var prop in existingMaps.GetUnmappedPropertyNames())
                @this.ForMember(prop, x => x.Ignore());

            return @this;
        }

    }
}
