using Chinook.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Chinook.DataEFCore.Configurations
{
    public class EmployeeConfiguration
    {
        public EmployeeConfiguration(EntityTypeBuilder<Employee> entity)
        {
            entity.HasIndex(e => e.ReportsTo)
                .HasName("IFK_Employee_ReportsTo");

            entity.Property(e => e.Address).HasMaxLength(70);

            entity.Property(e => e.BirthDate).HasColumnType("datetime");

            entity.Property(e => e.City).HasMaxLength(40);

            entity.Property(e => e.Country).HasMaxLength(40);

            entity.Property(e => e.Email).HasMaxLength(60);

            entity.Property(e => e.Fax).HasMaxLength(24);

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(20);

            entity.Property(e => e.HireDate).HasColumnType("datetime");

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(20);

            entity.Property(e => e.Phone).HasMaxLength(24);

            entity.Property(e => e.PostalCode).HasMaxLength(10);

            entity.Property(e => e.State).HasMaxLength(40);

            entity.Property(e => e.Title).HasMaxLength(30);

            entity.HasOne(d => d.Manager)
                .WithMany(p => p.DirectReports)
                .HasForeignKey(d => d.ReportsTo)
                .HasConstraintName("FK__Employee__Report__2B3F6F97");
        }
    }
}