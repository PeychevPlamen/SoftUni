using MusicSpot.Data.Models;
using MusicSpot.Models.Tracks;

namespace MusicSpot.Services.Tracks
{
    public interface ITrackService
    {
        Task<AllTracksViewModel> AllTracks(int albumId);

        Task<AllTracksViewModel> Index(string userId, string searchTerm, int p, int s);

        Task<DetailsTrackFormModel> TrackDetails(int? trackId);

        Task<EditTrackFormModel> TrackEdit(int? trackId);
                

        int Create(
           string name,
           string duration,
           int albumId);

        bool Edit(
           int id,
           string name,
           string duration,
            int albumId);

        bool Delete(int id);

        bool TrackExist(int id);
    }
}
