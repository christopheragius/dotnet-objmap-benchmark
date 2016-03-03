namespace Obj2ObjMapBench
{
    public class HandwrittenBenchmark : BaseBenchmark
    {
        public HandwrittenBenchmark()
        {

        }      

        public override void Map(Person person)
        {
            var obj = new PersonDTO
            {
                FirstName = person.FirstName,
                LastName = person.LastName
            };

            if (person.ResidenceAddress != null)
            {
                obj.ResidenceAddress = new AddressDTO
                {
                    City = person.ResidenceAddress.City,
                    StreetName = person.ResidenceAddress.StreetName,
                    ZipCode = person.ResidenceAddress.ZipCode
                };
            }
        }
    }
}
