using System;

namespace Obj2ObjMapBench.Models
{
    public class SimplePoco
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Enabled { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Town { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class SimplePocoDTO : SimplePoco
    {

    }
}
