using Omu.ValueInjecter;

namespace Obj2ObjMapBench
{
    public class ValueInjecterBenchmark : BaseBenchmark
    {
        public ValueInjecterBenchmark()
        {
            
        }

        public override TDest Map<TSource, TDest>(TSource source)
        {
            return Mapper.Map<TDest>(source);
        }
    }
}
