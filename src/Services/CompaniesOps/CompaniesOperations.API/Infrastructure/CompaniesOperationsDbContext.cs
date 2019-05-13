using CompaniesOperations.API.Model;
using Microsoft.EntityFrameworkCore;

namespace CompaniesOperations.API.Infrastructure
{
    public class CompaniesOperationsDbContext : DbContext
    {
        public CompaniesOperationsDbContext(DbContextOptions<CompaniesOperationsDbContext> options) : base(options)
        {
        }

        protected CompaniesOperationsDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Lead> Leads { get; set; }
        public DbSet<LeadType> LeadTypes { get; set; }
        public DbSet<Management> Managements { get; set; }
        public DbSet<ManagementStats> ManagementStats { get; set; }

    }
}