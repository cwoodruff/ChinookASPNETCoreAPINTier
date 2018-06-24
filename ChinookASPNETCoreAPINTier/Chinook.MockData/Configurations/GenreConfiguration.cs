using Chinook.MockData.DataModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.MockData.Configurations
{
    public class GenreConfiguration
    {
        public GenreConfiguration(EntityTypeBuilder<Genre> entity)
        {
            entity.Property(e => e.Name).HasMaxLength(120);
        }
    }
}
