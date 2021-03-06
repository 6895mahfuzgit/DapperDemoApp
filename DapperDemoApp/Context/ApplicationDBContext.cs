using DapperDemoApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemoApp.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Company>()
            //            .Ignore(t => t.Employees);

            //modelBuilder.Entity<Employee>()
            //            .HasOne(x => x.Company)
            //            .WithMany(x => x.Employees)
            //            .HasForeignKey(x => x.EmployeeId);
        }

    }
}
