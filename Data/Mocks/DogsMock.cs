using dog_club.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Data.Mocks
{
    public class DogsMock
    {
        public IEnumerable<Dog> get()
        {
            return new List<Dog>{
                new Dog { name = "Баллу", gender = "мужской", dateBirth = DateTime.Now.Date, OwnerId = 1, BreedId = 3 },
                new Dog { name = "Нэйси", gender = "женский", dateBirth = DateTime.Now.Date, OwnerId = 2, BreedId = 4 },
            };
        }
    }
}
