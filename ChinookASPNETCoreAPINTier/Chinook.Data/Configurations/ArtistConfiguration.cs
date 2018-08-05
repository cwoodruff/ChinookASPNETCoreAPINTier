using Chinook.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.Data.Configurations
{
    public class ArtistConfiguration
    {
        public ArtistConfiguration(EntityTypeBuilder<Artist> entity)
        {
            entity.Property(e => e.Name).HasMaxLength(120);
        }
    }
}