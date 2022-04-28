using Microsoft.EntityFrameworkCore;
using MusicSpot.Data;
using MusicSpot.Data.Models;
using MusicSpot.Models.Tracks;

namespace MusicSpot.Services.Tracks
{
    public class TrackService : ITrackService
    {
        private readonly MusicSpotDbContext _context;

        public TrackService(MusicSpotDbContext context)
        {
            _context = context;
        }

        public bool TrackExist(int id)
        {
            var track = _context.Albums.Find(id);

            if (track == null)
            {
                return false;
            }

            return true;
        }

        public async Task<AllTracksViewModel> AllTracks(int albumId)
        {

            var tracks = await _context.Tracks.Where(x => x.AlbumId == albumId).ToListAsync();

            var result = new AllTracksViewModel
            {
                Tracks = tracks.OrderBy(x => x.Id).ToList(),
            };

            return result;
        }

        public int Create(string name, string duration, int albumId)
        {
            var track = new Track
            {
                Name = name,
                Duration = duration,
                AlbumId = albumId
            };

            _context.Tracks.AddAsync(track);
            _context.SaveChangesAsync();

            return track.Id;
        }

        public bool Delete(int id)
        {
            var track = _context.Albums.Find(id);

            if (track == null)
            {
                return false;
            }

            _context.Remove(track);
            _context.SaveChangesAsync();

            return true;
        }

        public bool Edit(int id, string name, string duration, int albumId)
        {
            var trackData = _context.Tracks.Find(id);

            if (trackData == null)
            {
                return false;
            }


            trackData.Name = name;
            trackData.Duration = duration;
            trackData.AlbumId = albumId;

            _context.Update(trackData);
            _context.SaveChangesAsync();

            return true;
        }

        public async Task<DetailsTrackFormModel> TrackDetails(int? trackId)
        {
            var track = await _context.Tracks
                         .FirstOrDefaultAsync(t => t.Id == trackId);

            var result = new DetailsTrackFormModel
            {

                Name = track.Name,
                Duration = track.Duration,
                AlbumId = track.AlbumId,
            };

            return result;
        }

        public async Task<EditTrackFormModel> TrackEdit(int? trackId)
        {
            var track = await _context.Tracks
                         .FirstOrDefaultAsync(t => t.Id == trackId);

            var result = new EditTrackFormModel
            {

                Name = track.Name,
                Duration = track.Duration,
                AlbumId = track.AlbumId,
            };

            return result;
        }

        
        public async Task<AllTracksViewModel> Index(string userId, string searchTerm, int p, int s)
        {
            var allTracks = _context.Albums.Where(x => x.Artist.UserId == userId).SelectMany(x => x.Tracks);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                allTracks = allTracks.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            var result = new AllTracksViewModel
            {
                Tracks = allTracks
                              .OrderBy(x => x.Name)
                              .Skip(p * s - s)
                              .Take(s)
                              .ToList(),
                SearchTerm = searchTerm,
                PageNum = p,
                PageSize = s,
                TotalRec = allTracks.ToList().Count(),
                UserId = userId
            };

            return result;
        }
    }
}
