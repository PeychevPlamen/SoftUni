using MusicSpot.Services.Artists.Models;

namespace MusicSpot.Services.Artists
{
    public interface IArtistService
    {
        ArtistQueryServiceModel Index(
            string name = null,
            string genre = null,
            string searchTerm = null,
            int currentPage = 1,
            int carsPerPage = int.MaxValue
            );

        ArtistDetailsServiceModel Details(int id);

        int Create(
            string name,
            string genre,
            string userId
            );


    }
}
