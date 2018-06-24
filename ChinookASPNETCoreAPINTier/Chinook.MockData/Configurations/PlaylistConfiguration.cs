using Chinook.MockData.DataModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.MockData.Configurations
{
    public class PlaylistConfiguration
    {
        public PlaylistConfiguration(EntityTypeBuilder<Playlist> entity)
        {
            entity.Property(e => e.Name).HasMaxLength(120);
        }
    }
}
