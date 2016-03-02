using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obj2ObjMapBench
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Address ResidenceAddress { get; set; }
    }

    public class Address
    {
        public string StreetName { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }
    }

    public class PersonDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public AddressDTO ResidenceAddress { get; set; }
    }

    public class AddressDTO
    {
        public string StreetName { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }
    }
}
