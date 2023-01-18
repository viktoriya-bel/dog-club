using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Models
{
    public class SelectDataDog : Dog
    {
        public ICollection<Owner> Owners { set; get; }
        public ICollection<Breed> Breeds { set; get; }
        public ICollection<Dog> Dogs { set; get; }
    }
}
