#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicSpot.Data;
using MusicSpot.Data.Models;
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
        public async Task<IActionResult> Index()
        {
            var musicSpotDbContext = _context.Albums.Include(a => a.Artist);
            return View(await musicSpotDbContext.ToListAsync());
        }

        // GET: Albums/Details/5
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
        public IActionResult Create()
        {
            ViewData["ArtistId"] = new SelectList(_context.Artists, "Id", "Name");
            return View();
        }

        // POST: Albums/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateAlbumFormModel album)
        {
            var currArtist = _context.Artists.FirstOrDefault(x => x.Id == album.ArtistId);

            //var tracks = _context.Tracks
            //    .Where(t => t.AlbumId == album.Id)
            //    .OrderBy(t => t.Id)
            //    .Select(t => new CreateTrackFormModel
            //    {
            //        Name = t.Name,
            //        Duration = t.Duration,
            //    }).ToList();


            // album.Tracks = tracks;

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
            //_context.Artists.Add(currAlbum);

            currArtist.Albums.Add(currAlbum);

            if (ModelState.IsValid)
            {
                _context.Add(currAlbum);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ArtistId"] = new SelectList(_context.Artists, "Id", "Name", album.ArtistId);
            return View(album);
        }

        // GET: Albums/Edit/5
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
                    await _context.SaveChangesAsync();
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var album = await _context.Albums.FindAsync(id);
            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.Id == id);
        }
    }
}
