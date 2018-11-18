using Chinook.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Chinook.DataEFCoreCmpldQry.Configurations
{
    public class InvoiceConfiguration
    {
        public InvoiceConfiguration(EntityTypeBuilder<Invoice> entity)
        {
            entity.HasIndex(e => e.CustomerId)
                .HasName("IFK_Customer_Invoice");

            entity.Property(e => e.BillingAddress).HasMaxLength(70);

            entity.Property(e => e.BillingCity).HasMaxLength(40);

            entity.Property(e => e.BillingCountry).HasMaxLength(40);

            entity.Property(e => e.BillingPostalCode).HasMaxLength(10);

            entity.Property(e => e.BillingState).HasMaxLength(40);

            entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

            entity.Property(e => e.Total).HasColumnType("numeric");

            entity.HasOne(d => d.Customer)
                .WithMany(p => p.Invoices)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__Invoice__Custome__2D27B809");
        }
    }
}