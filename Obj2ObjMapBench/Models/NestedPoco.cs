using System.Collections.Generic;

namespace Obj2ObjMapBench.Models
{
    public class NestedPoco : SimplePoco
    {
        public List<NestedPoco> NestedObjects { get; set; }

        public NestedPoco()
        {
            NestedObjects = new List<NestedPoco>();
        }
    }
    public class NestedPocoDTO : NestedPoco
    {

    }
}
