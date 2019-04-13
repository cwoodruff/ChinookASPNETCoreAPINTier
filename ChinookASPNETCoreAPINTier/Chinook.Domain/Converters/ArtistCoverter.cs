using System.Collections.Generic;
using System.Linq;
using Chinook.Domain.Entities;
using Chinook.Domain.Responses;

namespace Chinook.Domain.Converters
{
    public static class ArtistCoverter
    {
        public static ArtistResponse Convert(Artist artist)
        {
            var artistViewModel = new ArtistResponse();
            artistViewModel.ArtistId = artist.ArtistId;
            artistViewModel.Name = artist.Name;
            return artistViewModel;
        }

        public static List<ArtistResponse> ConvertList(IEnumerable<Artist> artists)
        {
            return artists.Select(a =>
                {
                    var model = new ArtistResponse();
                    model.ArtistId = a.ArtistId;
                    model.Name = a.Name;
                    return model;
                })
                .ToList();
        }
    }
}