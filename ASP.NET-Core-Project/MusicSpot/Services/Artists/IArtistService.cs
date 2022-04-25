using MusicSpot.Data.Models;
using MusicSpot.Data.Repositories;
using MusicSpot.Models.Artists;

namespace MusicSpot.Services.Artists
{
    public interface IArtistService
    {
        Task<AllArtistViewModel> AllArtists(string userId, string searchTerm, int p, int s);

        Task<List<Artist>> ArtistsList(string userId);

        Task<DetailsArtistFormModel> ArtistDetails(int? artistId);

        int Create(
           string name,
           string genre,
           string userId);

        bool Edit(
           int artistId,
           string name,
           string genre);

        bool Delete(int artistId);

        bool ArtistExist(int artistId);
    }
}
