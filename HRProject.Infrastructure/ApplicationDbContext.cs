using HRProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRProject.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Affiliate> Affiliates { get; set; }

        public DbSet<Contract> Contracts { get; set; }

        public DbSet<Office> Offices { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Position> Positions { get; set; }
    }
}
