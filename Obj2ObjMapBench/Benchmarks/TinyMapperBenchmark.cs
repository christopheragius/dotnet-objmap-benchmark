using Nelibur.ObjectMapper;
using Obj2ObjMapBench.Models;
using System.Collections.Generic;
using System.Linq;

namespace Obj2ObjMapBench
{
    public class TinyMapperBenchmark : BaseBenchmark
    {
        public TinyMapperBenchmark()
        {
            TinyMapper.Bind<SimplePoco, SimplePocoDTO>();
            TinyMapper.Bind<NestedPoco, NestedPocoDTO>();

            //TinyMapper.Bind<NestedPoco, NestedPocoDTO>(config =>
            //{
            //    config.Bind(source => source.NestedObjects, target => target.NestedObjects);
            //    //config.Bind(target => target.NestedObjects, typeof(List<NestedPoco>));
            //});
        }      

        public override TDest Map<TSource, TDest>(TSource source)
        {
            return TinyMapper.Map<TDest>(source);
        }
    }
}
