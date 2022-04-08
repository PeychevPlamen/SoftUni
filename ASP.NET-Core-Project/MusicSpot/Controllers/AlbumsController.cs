#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicSpot.Data;
using MusicSpot.Data.Identity;
using MusicSpot.Data.Models;
using MusicSpot.Infrastructure.Extensions;
using MusicSpot.Models.Albums;
using MusicSpot.Models.Tracks;

namespace MusicSpot.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly MusicSpotDbContext _context;

        public AlbumsController(MusicSpotDbContext context)
        {
            _context = context;
        }

        // GET: Albums
        [Authorize]
        public async Task<IActionResult> Index(string searchTerm)
        {
            var userId = User.Id();

            var musicSpotDbContext = _context.Albums.Where(x => x.Artist.UserId == userId).Include(a => a.Artist).AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                musicSpotDbContext = musicSpotDbContext.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()) ||
                a.Year.ToString().ToLower().Contains(searchTerm.ToLower()) ||
                a.Format.ToLower().Contains(searchTerm.ToLower()));
            }

            return View(new AllAlbumsViewModel
            {
                Albums = musicSpotDbContext,
                SearchTerm = searchTerm
            });
        }

        // GET: Albums/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .Include(a => a.Artist)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // GET: Albums/Create
        [Authorize]
        public async Task<IActionResult> Create()
        {
            var userId = User.Id();

            ViewData["ArtistId"] = new SelectList(_context.Artists.Where(x => x.UserId == userId), "Id", "Name");
            return View();
        }

        // POST: Albums/Create

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAlbumFormModel album)
        {
            var currArtist = await _context.Artists.FirstOrDefaultAsync(x => x.Id == album.ArtistId);

            var currAlbum = new Album
            {
                Id = album.Id,
                Name = album.Name,
                ImageUrl = album.ImageUrl,
                Year = album.Year,
                Format = album.Format,
                MediaCondition = album.MediaCondition,
                SleeveCondition = album.SleeveCondition,
                Notes = album.Notes,
                ArtistId = currArtist.Id,

            };

            await _context.Albums.AddAsync(currAlbum);

            if (ModelState.IsValid)
            {
                await _context.AddAsync(currAlbum);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ArtistId"] = new SelectList(_context.Artists, "Id", "Name", album.ArtistId);
            return View(album);
        }

        // GET: Albums/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums.FindAsync(id);

            if (album == null)
            {
                return NotFound();
            }

            ViewData["ArtistId"] = new SelectList(_context.Artists, "Id", "Name", album.ArtistId);
            return View(album);
        }

        // POST: Albums/Edit/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditAlbumViewModel album)
        {
            if (id != album.Id)
            {
                return NotFound();
            }

            var currAlbum = new Album
            {
                Id = album.Id,
                Name = album.Name,
                ImageUrl = album.ImageUrl,
                Year = album.Year,
                Format = album.Format,
                MediaCondition = album.MediaCondition,
                SleeveCondition = album.SleeveCondition,
                Notes = album.Notes,
                ArtistId = album.ArtistId,
            };

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(currAlbum);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Artists, "Id", "Name", album.ArtistId);
            return View(album);
        }

        // GET: Albums/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .Include(a => a.Artist)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // POST: Albums/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var album = await _context.Albums.FindAsync(id);
            _context.Albums.Remove(album);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.Id == id);
        }


        public IActionResult AllAlbums(int id, string searchTerm)
        {
            var artistAlbums = _context.Albums
                .Where(x => x.ArtistId == id)
                .Include(a => a.Artist)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                artistAlbums = artistAlbums.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()) ||
                a.Year.ToString().ToLower().Contains(searchTerm.ToLower()) ||
                a.Format.ToLower().Contains(searchTerm.ToLower()));
            }

            return View(new AllAlbumsViewModel
            {
                Albums = artistAlbums,
                SearchTerm = searchTerm
            });
        }
    }
}
