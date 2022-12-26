using dog_club.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Data.Mocks
{
    public class DogsMock
    {
        public IEnumerable<Dog> getDogs()
        {
            return new List<Dog>{
                new Dog { },
            };
        }
    }
}
