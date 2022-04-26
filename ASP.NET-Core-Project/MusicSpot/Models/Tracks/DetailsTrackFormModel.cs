using MusicSpot.Data.Models;

namespace MusicSpot.Models.Tracks
{
    public class DetailsTrackFormModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Duration { get; set; }

        public Album? Album { get; set; }
        public int AlbumId { get; set; }
    }
}
