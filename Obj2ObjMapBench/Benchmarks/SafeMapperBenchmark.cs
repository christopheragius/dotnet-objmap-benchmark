using Obj2ObjMapBench.Models;
using SafeMapper;
using System;

namespace Obj2ObjMapBench
{
    public class SafeMapperBenchmark : BaseBenchmark
    {
        Converter<SimplePoco, SimplePocoDTO> _simpleConverter;
        Converter<NestedPoco, NestedPocoDTO> _nestedConverter;

        public SafeMapperBenchmark()
        {
            _simpleConverter = SafeMap.GetConverter<SimplePoco, SimplePocoDTO>();
            _nestedConverter = SafeMap.GetConverter<NestedPoco, NestedPocoDTO>();
        }

        public override TDest Map<TSource, TDest>(TSource source)
        {
            if (source is SimplePoco)
                return MapSimplePoco<TDest>(source as SimplePoco);
            else if (source is NestedPoco)
                return MapNestedPoco<TDest>(source as NestedPoco);

            throw new NotImplementedException();
        }

        private TDest MapSimplePoco<TDest>(SimplePoco source) where TDest : class
        {
            return _simpleConverter(source) as TDest;
        }

        private TDest MapNestedPoco<TDest>(NestedPoco source) where TDest : class
        {
            return _nestedConverter(source) as TDest;
        }
    }
}
