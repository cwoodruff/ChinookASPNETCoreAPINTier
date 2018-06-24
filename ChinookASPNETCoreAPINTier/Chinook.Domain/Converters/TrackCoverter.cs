using System.Collections.Generic;
using System.Linq;
using Chinook.Domain.Entities;
using Chinook.Domain.ViewModels;

namespace Chinook.Domain.Converters
{
    public static class TrackCoverter
    {
        public static TrackViewModel Convert(Track track)
        {
            var trackViewModel = new TrackViewModel();
            trackViewModel.TrackId = track.TrackId;
            trackViewModel.Name = track.Name;
            trackViewModel.AlbumId = track.AlbumId;
            trackViewModel.MediaTypeId = track.MediaTypeId;
            trackViewModel.GenreId = track.GenreId;
            trackViewModel.Composer = track.Composer;
            trackViewModel.Milliseconds = track.Milliseconds;
            trackViewModel.Bytes = track.Bytes;
            trackViewModel.UnitPrice = track.UnitPrice;
            return trackViewModel;
        }
        
        public static List<TrackViewModel> ConvertList(IEnumerable<Track> albums)
        {
            return albums.Select(t =>
                {
                    var model = new TrackViewModel();
                    model.TrackId = t.TrackId;
                    model.Name = t.Name;
                    model.AlbumId = t.AlbumId;
                    model.MediaTypeId = t.MediaTypeId;
                    model.GenreId = t.GenreId;
                    model.Composer = t.Composer;
                    model.Milliseconds = t.Milliseconds;
                    model.Bytes = t.Bytes;
                    model.UnitPrice = t.UnitPrice;
                    return model;
                })
                .ToList();
        }
    }
}