using dog_club.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Data.interfaces
{
    interface IBreeds
    {
        IEnumerable<Breed> Breeds { get; set; }

        //Breed GetBreed(int ВreedId);
    }
}
