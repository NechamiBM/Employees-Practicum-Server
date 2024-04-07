using Employees.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Employees.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Employee> Employees { get; set; }
        public DbSet<RoleType> RoleTypes { get; set; }


        public DataContext(IConfiguration configuration) => _configuration = configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["DbConnectionString"]);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasKey(er => new { er.RoleTypeId, er.EmployeeId });
        }
    }
}