using Chinook.MockData.DataModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.MockData.Configurations
{
    public class MediaTypeConfiguration
    {
        public MediaTypeConfiguration(EntityTypeBuilder<MediaType> entity)
        {
            entity.Property(e => e.Name).HasMaxLength(120);
        }
    }
}
