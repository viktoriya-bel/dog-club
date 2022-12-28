using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Models
{
    public class BreedEdit : Breed
    {
        public ICollection<Group> Groups { set; get; }
    }
}
