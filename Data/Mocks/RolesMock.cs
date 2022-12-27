using dog_club.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Data.Mocks
{
    public class RolesMock
    {
        public IEnumerable<Role> get()
        {
            return new List<Role>{
                new Role { name = "operator", isAdmin = false, },
                new Role { name = "admin", isAdmin = true },
            };
        }
    }
}
