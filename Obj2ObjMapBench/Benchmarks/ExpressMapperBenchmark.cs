using ExpressMapper;
using ExpressMapper.Extensions;
using Obj2ObjMapBench.Models;


namespace Obj2ObjMapBench
{
    public class ExpressMapperBenchmark : BaseBenchmark
    {
        public ExpressMapperBenchmark()
        {
            Mapper.Register<SimplePoco, SimplePocoDTO>();
            Mapper.Register<NestedPoco, NestedPocoDTO>();
            Mapper.Compile();

        }

        public override TDest Map<TSource, TDest>(TSource source)
        {
            if (source is SimplePoco)
                return (source as SimplePoco).Map<SimplePoco, SimplePocoDTO>() as TDest;

            return (source as NestedPoco).Map<NestedPoco, NestedPocoDTO>() as TDest;

        }
    }
}
