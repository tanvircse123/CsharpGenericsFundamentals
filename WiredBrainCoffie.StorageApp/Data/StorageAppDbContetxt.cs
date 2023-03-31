using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WiredBrainCoffie.StorageApp.Entities;

namespace WiredBrainCoffie.StorageApp.Data
{
    
    public class StorageAppDbContetxt:DbContext
    {
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Organization> Organizations => Set<Organization>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }
    }
}