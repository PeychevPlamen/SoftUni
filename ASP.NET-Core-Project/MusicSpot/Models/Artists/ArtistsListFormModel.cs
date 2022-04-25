using MusicSpot.Data.Models;

namespace MusicSpot.Models.Artists
{
    public class ArtistsListFormModel
    {
        public IEnumerable<Artist> Artists { get; set; }

        public string UserId { get; set; }
    }
}
