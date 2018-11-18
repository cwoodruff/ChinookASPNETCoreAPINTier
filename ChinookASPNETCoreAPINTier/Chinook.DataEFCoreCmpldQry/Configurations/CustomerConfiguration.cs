using Chinook.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Chinook.DataEFCoreCmpldQry.Configurations
{
    public class CustomerConfiguration
    {
        public CustomerConfiguration(EntityTypeBuilder<Customer> entity)
        {
            entity.HasIndex(e => e.SupportRepId)
                .HasName("IFK_Employee_Customer");

            entity.Property(e => e.Address).HasMaxLength(70);

            entity.Property(e => e.City).HasMaxLength(40);

            entity.Property(e => e.Company).HasMaxLength(80);

            entity.Property(e => e.Country).HasMaxLength(40);

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(60);

            entity.Property(e => e.Fax).HasMaxLength(24);

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(40);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(20);

            entity.Property(e => e.Phone).HasMaxLength(24);

            entity.Property(e => e.PostalCode).HasMaxLength(10);

            entity.Property(e => e.State).HasMaxLength(40);

            entity.HasOne(d => d.SupportRep)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.SupportRepId)
                .HasConstraintName("FK__Customer__Suppor__2C3393D0");
        }
    }
}