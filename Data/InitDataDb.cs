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
            if (!context.Owners.Any())
            {
                context.Owners.AddRange(new OwnersMock().get());
                context.SaveChanges();
            }
            if (!context.Groups.Any())
            {
                context.Groups.AddRange(new GroupsMock().get());
                context.SaveChanges();
            }
            if (!context.Breeds.Any())
            {
                context.Breeds.AddRange(new BreedsMock().get());
                context.SaveChanges();
            }
            /*if (!context.Dogs.Any())
            {
                context.Dogs.AddRange(new DogsMock().get());
                context.SaveChanges();
            }*/
            if (!context.Rewards.Any())
            {
                context.Rewards.AddRange(new RewardsMock().get());
                context.SaveChanges();
            }
        }
    }
}
