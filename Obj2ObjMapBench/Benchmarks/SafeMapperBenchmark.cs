using SafeMapper;
using System;

namespace Obj2ObjMapBench
{
    public class SafeMapperBenchmark: BaseBenchmark
    {
        readonly Converter<Person, PersonDTO> _converter;

        public SafeMapperBenchmark()
        {
            _converter = SafeMap.GetConverter<Person, PersonDTO>();
        }      

        public override void Map(Person person)
        {
            _converter(person);
        }
    }
}
