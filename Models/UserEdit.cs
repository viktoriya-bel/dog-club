using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Models
{
    public class UserEdit : User
    {
        public ICollection<Role> availableRoles { set; get; }

    }
}
