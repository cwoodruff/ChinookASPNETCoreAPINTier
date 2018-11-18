using Chinook.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Chinook.DataEFCore.Configurations
{
    public class PlaylistTrackConfiguration
    {
        public PlaylistTrackConfiguration(EntityTypeBuilder<PlaylistTrack> entity)
        {
            entity.HasKey(e => new {e.PlaylistId, e.TrackId})
                .HasName("PK__Playlist__A4A6282E25869641");

            entity.HasIndex(e => e.PlaylistId)
                .HasName("IPK_PlaylistTrack");

            entity.HasIndex(e => e.TrackId)
                .HasName("IFK_Track_PlaylistTrack");

            entity.HasOne(d => d.Playlist)
                .WithMany(p => p.PlaylistTracks)
                .HasForeignKey(d => d.PlaylistId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__PlaylistT__Playl__30F848ED");

            entity.HasOne(d => d.Track)
                .WithMany(p => p.PlaylistTracks)
                .HasForeignKey(d => d.TrackId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__PlaylistT__Track__300424B4");
        }
    }
}