using dog_club.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Data.Mocks
{
    public class RewardsMock
    {
        public IEnumerable<Reward> get()
        {
            return new List<Reward>{
                new Reward { name = "Награда 1", date = new DateTime().Date},
                new Reward { name = "Награда 2", date = new DateTime().Date},
            };
        }
    }
}
