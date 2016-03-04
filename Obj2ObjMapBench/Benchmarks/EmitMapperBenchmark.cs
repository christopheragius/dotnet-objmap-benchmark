using System;
using EmitMapper;
using Obj2ObjMapBench.Models;

namespace Obj2ObjMapBench
{
    public class EmitMapperBenchmark : BaseBenchmark
    {
        ObjectsMapper<SimplePoco, SimplePocoDTO> _simpleConverter;
        ObjectsMapper<NestedPoco, NestedPocoDTO> _nestedConverter;

        public EmitMapperBenchmark()
        {
            _simpleConverter = ObjectMapperManager.DefaultInstance.GetMapper<SimplePoco, SimplePocoDTO>();
            _nestedConverter = ObjectMapperManager.DefaultInstance.GetMapper<NestedPoco, NestedPocoDTO>();
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
            return _simpleConverter.Map(source) as TDest;
        }

        private TDest MapNestedPoco<TDest>(NestedPoco source) where TDest : class
        {
            return _nestedConverter.Map(source) as TDest;
        }
    }
}
