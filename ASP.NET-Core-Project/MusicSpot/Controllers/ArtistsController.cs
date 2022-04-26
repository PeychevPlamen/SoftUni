#nullable disable
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicSpot.Data.Models;
using MusicSpot.Infrastructure.Extensions;
using MusicSpot.Models.Artists;
using MusicSpot.Services.Artists;

namespace MusicSpot.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly IArtistService _service;

        public ArtistsController(IArtistService service)
        {
            _service = service;
        }

        // GET: Artists
        [Authorize]
        public async Task<IActionResult> Index(string userId, string searchTerm, int p = 1, int s = 5)
        {
            var userID = User.Id();

            var model = await _service.AllArtists(userID, searchTerm, p, s);

            return View(model);
        }

        // GET: Artists/Details
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _service.ArtistDetails(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
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
            var userId = User.Id();
            artist.UserId = userId;

            if (ModelState.IsValid)
            {
                var artistId = _service.Create(artist.Name, artist.Genre, userId);

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

            var artist = await _service.ArtistDetails(id);

            if (artist == null)
            {
                return NotFound();
            }

            var currArtist = new Artist { Name = artist.Name, Genre = artist.Genre };

            return View(currArtist);
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

            var editedArtist = _service.Edit(id, artist.Name, artist.Genre);

            if (!editedArtist)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Edit(artist.Id, artist.Name, artist.Genre);
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

                if (!User.IsAdmin())
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction("Index", "Admin", new { area = "Home" });
                }
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

            var artist = await _service.ArtistDetails(id);

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
            var artist = _service.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        private bool ArtistExists(int id)
        {
            return _service.ArtistExist(id);
        }
    }
}
