using Obj2ObjMapBench.Models;
using System;
using System.Collections.Generic;

namespace Obj2ObjMapBench
{
    public class HandwrittenBenchmark : BaseBenchmark
    {
        public override TDest Map<TSource, TDest>(TSource source) 
        {
            if (source is SimplePoco)
                return MapSimplePoco<TDest>(source as SimplePoco);
            else if (source is NestedPoco)
                return MapNestedPoco<TDest>(source as NestedPoco);

            throw new NotImplementedException();
        }

        private TDest MapSimplePoco<TDest>(SimplePoco source) where TDest : class
        {
            var instance = new SimplePocoDTO()
            {
                Address = source.Address,
                BirthDate = source.BirthDate,
                CreatedOn = source.CreatedOn,
                Email = source.Email,
                Enabled = source.Enabled,
                Id = source.Id,
                Name = source.Name,
                PhoneNumber = source.PhoneNumber,
                Town = source.Town,
                ZipCode = source.ZipCode
            };
            return instance as TDest;
        }

        private TDest MapNestedPoco<TDest>(NestedPoco source) where TDest : class
        {
            var instance = MapSimplePoco<NestedPocoDTO>(source);
            foreach (var obj in source.NestedObjects)
                instance.NestedObjects.Add(MapNestedPoco<NestedPocoDTO>(obj));
            return instance as TDest;
        }
    }
}
