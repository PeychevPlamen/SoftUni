using MusicSpot.Data.Models;

namespace MusicSpot.Services.Artists.Models
{
    public class ArtistDetailsServiceModel : ArtistServiceModel
    {
        public string UserId { get; init; }

        public IEnumerable<Album> Albums { get; set; }
    }
}
