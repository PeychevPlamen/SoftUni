using MusicSpot.Data.Repositories;
using MusicSpot.Models.Artists;

namespace MusicSpot.Services.Artists
{
    public interface IArtistService
    {
        Task<AllArtistViewModel> AllArtists(string userId, string searchTerm, int p, int s);

        Task<DetailsArtistFormModel> ArtistDetails(int? artistId);
    }
}
