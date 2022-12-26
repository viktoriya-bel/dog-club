using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        
/*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5656;Database=testdb;Username=postgres;Password=root");
        }*/
    }
}
