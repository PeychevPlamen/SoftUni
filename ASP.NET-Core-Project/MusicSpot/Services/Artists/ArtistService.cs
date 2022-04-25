using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicSpot.Data;
using MusicSpot.Data.Identity;
using MusicSpot.Data.Models;
using MusicSpot.Data.Repositories;
using MusicSpot.Infrastructure.Extensions;
using MusicSpot.Models.Artists;

namespace MusicSpot.Services.Artists
{
    public class ArtistService : Controller, IArtistService
    {
        private readonly MusicSpotDbContext _context;

        public ArtistService(MusicSpotDbContext context)
        {
            _context = context;
        }

        public async Task<AllArtistViewModel> AllArtists(string UserId, string searchTerm, int p, int s)
        {
            var currArtist = await _context.Artists.Where(a => a.UserId == UserId).ToListAsync();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                currArtist = currArtist.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
            }

            var result = new AllArtistViewModel
            {
                Artists = currArtist
                              .OrderBy(x => x.Name)
                              .Skip(p * s - s)
                              .Take(s)
                              .ToList(),
                SearchTerm = searchTerm,
                PageNum = p,
                PageSize = s,
                TotalRec = currArtist.Count(),
                UserId = UserId
            };

            return result;

        }

        public async Task<DetailsArtistFormModel> ArtistDetails(int? id)
        {
            var artist = await _context.Artists
                         .FirstOrDefaultAsync(m => m.Id == id); // or findAsync(id)

            var result = new DetailsArtistFormModel
            {
                Id = artist.Id,
                Name = artist.Name,
                Genre = artist.Genre
            };

            return result;

        }

        public bool ArtistExist(int artistId)
        {
            var artist = _context.Artists.Find(artistId);

            if (artist == null)
            {
                return false;
            }

            return true;
        }

        //public async Task<ArtistsListFormModel> ArtistsList(string userId)
        //{
        //    var artists = await _context.Artists.Where(x => x.UserId == userId).ToListAsync();

        //    return new ArtistsListFormModel { Artists = artists };
        //}

        public int Create(string name, string genre, string userId)
        {
            var newArtist = new Artist
            {
                Name = name,
                Genre = genre,
                UserId = userId
            };

            // Ако има вече съществуващ артист !!!!!!!

            //if (_context.Artists.Select(a => a.Name).Contains(newArtist.Name))
            //{

            //    ModelState.AddModelError("name", "Artist already exists.");

            //    throw new ArgumentException("Artist already exists.");
            //}


            _context.Artists.AddAsync(newArtist);
            _context.SaveChangesAsync();

            return newArtist.Id;

        }

        public bool Delete(int artistId)
        {
            var artist = _context.Artists.Find(artistId);

            if (artist == null)
            {
                return false;
            }

            _context.Remove(artist);
            _context.SaveChangesAsync();

            return true;
        }

        public bool Edit(int artistId, string name, string genre)
        {
            var artistData = _context.Artists.Find(artistId);

            if (artistData == null)
            {
                return false;
            }

            artistData.Name = name;
            artistData.Genre = genre;

            _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Artist>> ArtistsList(string userId)
        {
            var artists = await _context.Artists.Where(x => x.UserId == userId).ToListAsync();

            return artists;
        }
    }
}
