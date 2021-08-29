using Microsoft.EntityFrameworkCore;
using VogCodeChallenge.Domain;
using VogCodeChallenge.Infrastructure.EntityConfigurations;

namespace VogCodeChallenge.Infrastructure
{
    public class VogDBContext : DbContext
    {
        public VogDBContext(DbContextOptions<VogDBContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CompanyConfigurations())
                .ApplyConfiguration(new DepartmentConfigurations())
                .ApplyConfiguration(new EmployeeConfigurations());

            base.OnModelCreating(builder);
        }
    }
}
