using dog_club.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Data.Mocks
{
    public class GroupsMock
    {
        public IEnumerable<Group> getGroups()
        {
            return new List<Group>{
                new Group { },
            };
        }
    }
}
