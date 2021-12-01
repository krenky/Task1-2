using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1_2.Models;

namespace Task1_2.Context
{
    class ApplicationContext : DbContext
    {
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=OprganisationDb;Trusted_Connection=True;");
        }
    }
}
