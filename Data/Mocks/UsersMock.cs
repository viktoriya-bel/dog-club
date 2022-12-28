using dog_club.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Data.Mocks
{
    public class UsersMock
    {
        public IEnumerable<User> get()
        {
            return new List<User>{
                new User { userName = "user", password = "user", RoleId = 5 },
                new User { userName = "admin", password = "admin", RoleId = 6 },
            };
        }
    }
}
