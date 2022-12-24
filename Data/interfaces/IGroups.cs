using dog_club.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Data.interfaces
{
    interface IGroups
    {
        IEnumerable<Group> Groups { get; set; }

        Group GetGroup(int groupId);
    }
}
