using Microsoft.EntityFrameworkCore;
using MusicSpot.Data;
using MusicSpot.Data.Models;
using MusicSpot.Models.Albums;
using MusicSpot.Models.Artists;

namespace MusicSpot.Services.Albums
{
    public class AlbumService : IAlbumService
    {
        private readonly MusicSpotDbContext _context;

        public AlbumService(MusicSpotDbContext context)
        {
            _context = context;
        }

        public async Task<DetailsAlbumFormModel> AlbumDetails(int? artistId)
        {
            var album = await _context.Albums.FindAsync(artistId);
            var artist = await _context.Artists.FindAsync(album.ArtistId);

            var result = new DetailsAlbumFormModel
            {
                Id = album.Id,
                Name = album.Name,
                Format = album.Format,
                ImageUrl = album.ImageUrl,
                MediaCondition = album.MediaCondition,
                Notes = album.Notes,
                SleeveCondition = album.SleeveCondition,
                Year = album.Year,
                Artist = new Artist { Name = artist.Name },
            };

            return result;
        }

        public async Task<AllAlbumsViewModel> Index(string userID, int artistId, string searchTerm, int p, int s)
        {
            var currAlbums = _context.Albums.Where(x => x.Artist.UserId == userID).Include(a => a.Artist).AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                currAlbums = currAlbums.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()) ||
                a.Year.ToString().ToLower().Contains(searchTerm.ToLower()) ||
                a.Format.ToLower().Contains(searchTerm.ToLower()));
            }

            var result = new AllAlbumsViewModel
            {
                Albums = currAlbums
                              .OrderBy(x => x.Name)
                              .Skip(p * s - s)
                              .Take(s)
                              .ToList(),
                SearchTerm = searchTerm,
                PageNum = p,
                PageSize = s,
                TotalRec = currAlbums.Count(),
                ArtistId = artistId,
                UserId = userID,
            };

            return result;
        }

        public int Create(string name, string imageUrl, int year, string format, string mediaCondition, string sleeveCondition, string notes, int artistId)
        {
            var album = new Album
            {
                Name = name,
                ImageUrl = imageUrl,
                Year = year,
                Format = format,
                MediaCondition = mediaCondition,
                SleeveCondition = sleeveCondition,
                Notes = notes,
                ArtistId = artistId
            };

            _context.Albums.AddAsync(album);
            _context.SaveChangesAsync();

            return album.Id;
        }

        public bool Delete(int albumId)
        {
            var album = _context.Albums.Find(albumId);

            if (album == null)
            {
                return false;
            }

            _context.Remove(album);
            _context.SaveChangesAsync();

            return true;
        }

        public bool Edit(int albumId, string name, string imageUrl, int year, string format, string mediaCondition, string sleeveCondition, string notes)
        {
            throw new NotImplementedException();
        }

        public bool AlbumExist(int albumId)
        {
            var album = _context.Albums.Find(albumId);

            if (album == null)
            {
                return false;
            }

            return true;
        }

        public async Task<AllAlbumsViewModel> AllAlbums(string userId, int artistId, string searchTerm, int p, int s)
        {
            var currAlbums = _context.Albums.Where(x => x.ArtistId == artistId).Include(a => a.Artist).AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                currAlbums = currAlbums.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()) ||
                a.Year.ToString().ToLower().Contains(searchTerm.ToLower()) ||
                a.Format.ToLower().Contains(searchTerm.ToLower()));
            }

            var result = new AllAlbumsViewModel
            {
                Albums = currAlbums
                              .OrderBy(x => x.Name)
                              .Skip(p * s - s)
                              .Take(s)
                              .ToList(),
                SearchTerm = searchTerm,
                PageNum = p,
                PageSize = s,
                TotalRec = currAlbums.Count(),
                ArtistId = artistId,
            };

            return result;
        }

        
    }
}
