using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace People.Api.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<People.Api.Models.People> Peoples { get; set; }
        public DbSet<People.Api.Models.PeopleType> PeopleTypes { get; set; }
        public DbSet<People.Api.Models.State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People.Api.Models.People>().ToTable("Peoples");
            modelBuilder.Entity<People.Api.Models.PeopleType>().ToTable("PeopleTypes");
            modelBuilder.Entity<People.Api.Models.State>().ToTable("States");
        }
    }
}
