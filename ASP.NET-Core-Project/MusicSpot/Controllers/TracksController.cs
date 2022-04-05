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
using MusicSpot.Data.Models;
using MusicSpot.Infrastructure.Extensions;
using MusicSpot.Models.Tracks;

namespace MusicSpot.Controllers
{
    public class TracksController : Controller
    {
        private readonly MusicSpotDbContext _context;

        public TracksController(MusicSpotDbContext context)
        {
            _context = context;
        }

        // GET: Tracks
        [Authorize]
        public async Task<IActionResult> Index(string searchTerm)
        {
            var userId = User.Id();
            var albumId = _context.Albums.Where(x => x.Artist.UserId == userId).FirstOrDefault().Id;

            var musicSpotDbContext = _context.Tracks.Where(x => x.AlbumId == albumId).AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                musicSpotDbContext = musicSpotDbContext.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()) ||
                a.Album.Name.ToString().ToLower().Contains(searchTerm.ToLower()));
            }

            return View(new AllTracksViewModel
            {
                Tracks = musicSpotDbContext,
                SearchTerm = searchTerm
            });



            //var musicSpotDbContext = _context.Tracks.Include(t => t.Album);
            //return View(await musicSpotDbContext.ToListAsync());
        }

        // GET: Tracks/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = await _context.Tracks
                .Include(t => t.Album)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        // GET: Tracks/Create
        [Authorize]
        public async Task<IActionResult> Create(int? id)
        {
            //var userId = User.Id();
            //var artistId = _context.Artists.Where(x => x.UserId == userId).FirstOrDefault().Id;
            //var albumId = _context.Albums.Include(x=>x.Id);

            //var album = _context.Albums.SingleOrDefault(a => a.Id == id);

            ViewData["AlbumId"] = new SelectList(_context.Albums.Where(x => x.Id == id), "Id", "Name");
            return View();
        }

        // POST: Tracks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTrackFormModel track)
        {
            var currAlbum = await _context.Albums.FirstOrDefaultAsync(x => x.Id == track.AlbumId);

            var currTrack = new Track
            {
                Name = track.Name,
                Duration = track.Duration,
                AlbumId = currAlbum.Id
            };


            //_context.Tracks.Add(currTrack);
            //var albumTracks = _context.Albums.Where(x => x.Id == track.AlbumId).Select(x => x.Tracks).ToList();

            currAlbum.Tracks.Add(currTrack);


            if (ModelState.IsValid)
            {
                _context.Add(currTrack);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            ViewData["AlbumId"] = new SelectList(_context.Albums, "Id", "Name", track.AlbumId);
            return View(track);
        }

        // GET: Tracks/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = await _context.Tracks.FindAsync(id);
            if (track == null)
            {
                return NotFound();
            }

            ViewData["AlbumId"] = new SelectList(_context.Albums, "Id", "Name", track.AlbumId);
            return View(track);
        }

        // POST: Tracks/Edit/5

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Duration,AlbumId")] Track track)
        {
            if (id != track.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(track);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrackExists(track.Id))
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

            ViewData["AlbumId"] = new SelectList(_context.Albums, "Id", "Name", track.AlbumId);
            return View(track);
        }

        // GET: Tracks/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = await _context.Tracks
                .Include(t => t.Album)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        // POST: Tracks/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var track = await _context.Tracks.FindAsync(id);

            _context.Tracks.Remove(track);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool TrackExists(int id)
        {
            return _context.Tracks.Any(e => e.Id == id);
        }

        [Authorize]
        public IActionResult AllTracks(int id)
        {
            var albumTracks = _context.Tracks.Where(x => x.AlbumId == id).AsQueryable();
            return View(albumTracks);
        }
    }
}
