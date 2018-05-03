using AgileObjects.AgileMapper.Extensions;

namespace Obj2ObjMapBench
{
    public class AgileMapperBenchmark : BaseBenchmark
    {


        public override TDest Map<TSource, TDest>(TSource source)
        {
            return source.Map().ToANew<TDest>();
        }
    }
}
