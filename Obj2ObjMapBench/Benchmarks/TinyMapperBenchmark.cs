using Nelibur.ObjectMapper;

namespace Obj2ObjMapBench
{
    public class TinyMapperBenchmark : BaseBenchmark
    {
        public TinyMapperBenchmark()
        {
            TinyMapper.Bind<Person, PersonDTO>();
        }      

        public override void Map(Person person)
        {
            TinyMapper.Map<PersonDTO>(person);
        }
    }
}
