using MusicSpot.Data.Repositories;
using MusicSpot.Models.Albums;
using MusicSpot.Models.Artists;

namespace MusicSpot.Services.Albums
{
    public interface IAlbumService
    {
        Task<AllAlbumsViewModel> Index(string userId,int artistId, string searchTerm, int p, int s);

        Task<AllAlbumsViewModel> AllAlbums(string userId, int artistId, string searchTerm, int p, int s);

        Task<DetailsAlbumFormModel> AlbumDetails(int? artistId);

        //Task<AllArtistViewModel> Artists(string userId);

        int Create(
           string name,
           string imageUrl,
           int year,
           string format,
           string mediaCondition,
           string sleeveCondition,
           string notes,
           int artistId
           );

        bool Edit(
           int albumId,
           string name,
           string imageUrl,
           int year,
           string format,
           string mediaCondition,
           string sleeveCondition,
           string notes);

        bool Delete(int albumId);

        bool AlbumExist(int albumId);
    }
}
