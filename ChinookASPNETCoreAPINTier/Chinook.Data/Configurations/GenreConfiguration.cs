using Chinook.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.Data.Configurations
{
    public class GenreConfiguration
    {
        public GenreConfiguration(EntityTypeBuilder<Genre> entity)
        {
            entity.Property(e => e.Name).HasMaxLength(120);
        }
    }
}