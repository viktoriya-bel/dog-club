using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Models
{
    public class RewardEdit : Reward
    {
        public ICollection<Dog> Dogs { set; get; }
    }
}
