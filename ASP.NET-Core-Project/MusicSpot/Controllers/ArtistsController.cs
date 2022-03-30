#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicSpot.Data;
using MusicSpot.Data.Models;
using MusicSpot.Infrastructure.Extensions;
using MusicSpot.Models.Albums;
using MusicSpot.Models.Artists;

namespace MusicSpot.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly MusicSpotDbContext _context;

        public ArtistsController(MusicSpotDbContext context)
        {
            _context = context;
        }

        // GET: Artists
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userId = User.Id();
            //var userId = _context.Users.Select(u => u.Id).FirstOrDefault();

            if (userId != null)
            {
                var currArtist = await _context.Artists.Where(a => a.UserId == userId).ToListAsync();

                return View(currArtist);
            }

            return View(_context.Artists.AsQueryable());
        }

        // GET: Artists/Details
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists
                .FirstOrDefaultAsync(m => m.Id == id);

            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // GET: Artists/Create
        [Authorize]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Artists/Create

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateArtistFormModel artist)
        {
            //var userId = await _context.Users.Select(u => u.Id).FirstOrDefaultAsync();
            var userId = User.Id();

            var currArtist = new Artist
            {
                Name = artist.Name,
                Genre = artist.Genre,
                UserId = userId,
            };


            if (ModelState.IsValid)
            {
                await _context.AddAsync(currArtist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }

        // GET: Artists/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists.FindAsync(id);

            if (artist == null)
            {
                return NotFound();
            }
            return View(artist);
        }

        // POST: Artists/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditArtistFormModel artist)
        {
            if (id != artist.Id)
            {
                return NotFound();
            }

            var currArtist = new Artist
            {
                Id = artist.Id,
                Name = artist.Name,
                Genre = artist.Genre,
            };

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(currArtist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistExists(artist.Id))
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
            return View(artist);
        }

        // GET: Artists/Delete
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists
                .FirstOrDefaultAsync(m => m.Id == id);

            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // POST: Artists/Delete
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artist = _context.Artists.Find(id);
            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtistExists(int id)
        {
            return _context.Artists.Any(e => e.Id == id);
        }
    }
}
