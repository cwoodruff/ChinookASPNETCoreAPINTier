using Chinook.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.Data.Configurations
{
    public class PlaylistConfiguration
    {
        public PlaylistConfiguration(EntityTypeBuilder<Playlist> entity)
        {
            entity.Property(e => e.Name).HasMaxLength(120);
        }
    }
}