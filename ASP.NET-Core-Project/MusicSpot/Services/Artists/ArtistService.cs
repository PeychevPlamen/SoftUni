using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicSpot.Data;
using MusicSpot.Data.Identity;
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
            var userId = _context.Users.FirstOrDefault().Id;

            var currArtist = await _context.Artists.Where(a => a.UserId == userId).ToListAsync();

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
                UserId = userId
            };

            return result;

        }

        public async Task<DetailsArtistFormModel> ArtistDetails(int? id)
        {
            //if (artistId == null)
            //{
            //    return NotFound();
            //}

            var artist = await _context.Artists
                .FirstOrDefaultAsync(m => m.Id == id);

            var result = new DetailsArtistFormModel
            {
                Id = artist.Id,
                Name = artist.Name,
                Genre = artist.Genre
            };

            //if (artist == null)
            //{
            //    return NotFound();
            //}

            return result;

        }
    }
}
