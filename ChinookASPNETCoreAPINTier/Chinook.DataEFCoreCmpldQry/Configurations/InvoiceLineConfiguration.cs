using Chinook.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Chinook.DataEFCoreCmpldQry.Configurations
{
    public class InvoiceLineConfiguration
    {
        public InvoiceLineConfiguration(EntityTypeBuilder<InvoiceLine> entity)
        {
            entity.HasIndex(e => e.InvoiceId)
                .HasName("IFK_Invoice_InvoiceLine");

            entity.HasIndex(e => e.TrackId)
                .HasName("IFK_ProductItem_InvoiceLine");

            entity.Property(e => e.UnitPrice).HasColumnType("numeric");

            entity.HasOne(d => d.Invoice)
                .WithMany(p => p.InvoiceLines)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__InvoiceLi__Invoi__2F10007B");

            entity.HasOne(d => d.Track)
                .WithMany(p => p.InvoiceLines)
                .HasForeignKey(d => d.TrackId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__InvoiceLi__Track__2E1BDC42");
        }
    }
}