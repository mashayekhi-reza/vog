using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using VogCodeChallenge.Domain;

namespace VogCodeChallenge.Infrastructure.EntityConfigurations
{
    public class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedNever();

            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();

            builder.Property(c => c.Address).HasMaxLength(500).IsRequired();

            builder.Property<Guid>("CompanyId").HasColumnType("TEXT").IsRequired();

            builder.HasOne(d => d.Company).WithMany().HasForeignKey("CompanyId");
        }
    }
}
