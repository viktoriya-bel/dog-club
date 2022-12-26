using dog_club.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Data.Mocks
{
    public class OwnersMock
    {
        public IEnumerable<Owner> getOwners()
        {
            return new List<Owner>{
                new Owner { },
            };
        }
    }
}
