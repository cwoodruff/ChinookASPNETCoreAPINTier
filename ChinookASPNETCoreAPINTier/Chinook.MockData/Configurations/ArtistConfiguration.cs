using Chinook.MockData.DataModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.MockData.Configurations
{
    public class ArtistConfiguration
    {
        public ArtistConfiguration(EntityTypeBuilder<Artist> entity)
        {
            entity.Property(e => e.Name).HasMaxLength(120);
        }
    }
}
