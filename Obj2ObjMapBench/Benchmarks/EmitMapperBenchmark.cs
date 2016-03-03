using EmitMapper;

namespace Obj2ObjMapBench
{
    public class EmitMapperBenchmark : BaseBenchmark
    {
        readonly ObjectsMapper<Person, PersonDTO> _converter;

        public EmitMapperBenchmark()
        {
            _converter = ObjectMapperManager.DefaultInstance.GetMapper<Person, PersonDTO>();
        }      

        public override void Map(Person person)
        {
            _converter.Map(person);
        }
    }
}
