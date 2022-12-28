using dog_club.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Data.Mocks
{
    public class BreedsMock
    {
        public IEnumerable<Breed> get()
        {
            return new List<Breed>{
                new Breed { nameBreed = "Метис", GroupId = 1 },
                new Breed { nameBreed = "Бриар", GroupId = 2 },
                new Breed { nameBreed = "Босерон", GroupId = 2 },
                new Breed { nameBreed = "Доберман", GroupId = 3 },
                new Breed { nameBreed = "Пинчер", GroupId = 3 },
                new Breed { nameBreed = "Русский черный терьер", GroupId = 3 },
                new Breed { nameBreed = "Английский той терьер", GroupId = 4 },
                new Breed { nameBreed = "Такса классическая", GroupId = 5 },
            };
        }
    }
}
