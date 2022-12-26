using dog_club.Data.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Data
{
    public class InitDataDb
    {
        public static void Initialize(testdbContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(new RolesMock().get());
                context.SaveChanges();
            }
           
            if (!context.Users.Any())
            {
                context.Users.AddRange(new UsersMock().get());
                context.SaveChanges();
            }
        }
    }
}
