using dog_club.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Data.Mocks
{
    public class BreedsMock
    {
        public IEnumerable<Breed> getBreeds()
        {
            return new List<Breed>{
                new Breed { },
            };
        }
    }
}
