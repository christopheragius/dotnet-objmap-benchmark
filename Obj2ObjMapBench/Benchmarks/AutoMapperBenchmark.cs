using AutoMapper;
using Obj2ObjMapBench.Models;
using System.Linq;

namespace Obj2ObjMapBench
{
    public class AutoMapperBenchmark : BaseBenchmark
    {
        private IMapper mapper;

        public AutoMapperBenchmark()
        {

            MapperConfiguration config = new MapperConfiguration(cfg => {
                cfg.CreateMap<SimplePoco, SimplePocoDTO>();
                cfg.CreateMap<NestedPoco, NestedPocoDTO>();
            });

            mapper = config.CreateMapper();
        }

        public override TDest Map<TSource, TDest>(TSource source)
        {
            return mapper.Map<TDest>(source);
        }

    }
}
