using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using VogCodeChallenge.Domain;

namespace VogCodeChallenge.Infrastructure.EntityConfigurations
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedNever();

            builder.Property(c => c.FirstName).HasMaxLength(100).IsRequired();
            
            builder.Property(c => c.LastName).HasMaxLength(100).IsRequired();
            
            builder.Property(c => c.Address).HasMaxLength(500).IsRequired();

            builder.Property(c => c.JobTitle).HasMaxLength(200).IsRequired();

            builder.Property<Guid>("DepartmentId").HasColumnType("TEXT").IsRequired();

            builder.HasOne(d => d.Department).WithMany().HasForeignKey("DepartmentId");
        }
    }
}
