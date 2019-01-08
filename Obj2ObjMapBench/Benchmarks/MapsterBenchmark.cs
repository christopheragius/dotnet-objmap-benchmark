
using Mapster;


namespace Obj2ObjMapBench
{
    public class MapsterBenchmark : BaseBenchmark
    {
        public override TDest Map<TSource, TDest>(TSource source)
        {
            return source.Adapt<TDest>();
        }
    }
}
