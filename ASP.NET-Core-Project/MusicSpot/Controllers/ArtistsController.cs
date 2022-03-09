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
        public IActionResult Index()
        {
            return View(_context.Artists.ToList());
        }

        // GET: Artists/Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = _context.Artists
                .FirstOrDefault(m => m.Id == id);

            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // GET: Artists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateArtistFormModel artist)
        {
            var currArtist = new Artist
            {
                Name = artist.Name,
                Genre = artist.Genre,
               
            };
            
            if (ModelState.IsValid)
            {
                _context.Add(currArtist);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }

        // GET: Artists/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = _context.Artists.Find(id);

            if (artist == null)
            {
                return NotFound();
            }
            return View(artist);
        }

        // POST: Artists/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditArtistFormModel artist)
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
                    _context.SaveChanges();
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
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = _context.Artists
                .FirstOrDefault(m => m.Id == id);

            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // POST: Artists/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var artist = _context.Artists.Find(id);
            _context.Artists.Remove(artist);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtistExists(int id)
        {
            return _context.Artists.Any(e => e.Id == id);
        }
    }
}
