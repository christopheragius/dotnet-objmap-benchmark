using Omu.ValueInjecter;

namespace Obj2ObjMapBench
{
    public class ValueInjecterBenchmark : BaseBenchmark
    {
        public ValueInjecterBenchmark()
        {
            
        }      

        public override void Map(Person person)
        {
            Mapper.Map<PersonDTO>(person);
        }
    }
}
