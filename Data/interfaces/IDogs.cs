using dog_club.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Data.interfaces
{
    interface IDogs
    {
        IEnumerable<Dog> Dogs { get; set; }

        Dog GetDog(int dogId);
    }
}
