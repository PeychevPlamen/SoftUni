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
using MusicSpot.Services.Albums;
using MusicSpot.Services.Artists;

namespace MusicSpot.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumService _service;
        private readonly IArtistService _artists;

        public AlbumsController(IArtistService artists, IAlbumService service)
        {
            _service = service;
            _artists = artists;
        }

        // GET: Albums
        [Authorize]
        public async Task<IActionResult> Index(int artistId, string searchTerm, int p = 1, int s = 5)
        {
            var userId = User.Id();

            var currAlbums = await _service.Index(userId, artistId, searchTerm, p, s);

            return View(currAlbums);
        }

        // GET: Albums/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _service.AlbumDetails(id);

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

            var artistList = await _artists.ArtistsList(userId);


            ViewData["ArtistId"] = new SelectList(artistList, "Id", "Name");
            return View();
        }

        // POST: Albums/Create

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAlbumFormModel album)
        {
            var userId = User.Id();

            var artistList = await _artists.ArtistsList(userId);

            if (ModelState.IsValid)
            {
                
                var albumID = _service.Create(
                    album.Name,
                    album.ImageUrl,
                    album.Year,
                    album.Format,
                    album.MediaCondition,
                    album.SleeveCondition,
                    album.Notes,
                    album.ArtistId);

                return RedirectToAction(nameof(Index));
            }

            ViewData["ArtistId"] = new SelectList(artistList, "Id", "Name", album.ArtistId);

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

            var album = await _service.AlbumDetails(id);

            var userId = User.Id();

            var artistList = await _artists.ArtistsList(userId);



            if (album == null)
            {
                return NotFound();
            }

            ViewData["ArtistId"] = new SelectList(artistList, "Id", "Name", album.ArtistId);
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
                    
                    _service.Edit(
                            id,
                            album.Name,
                            album.ImageUrl,
                            album.Year,
                            album.Format,
                            album.MediaCondition,
                            album.SleeveCondition,
                            album.Notes,
                            album.ArtistId);
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

            var userId = User.Id();

            var artistList = await _artists.ArtistsList(userId);

            ViewData["ArtistId"] = new SelectList(artistList, "Id", "Name", album.ArtistId);
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

            var album = await _service.AlbumDetails(id);

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
            var album = _service.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        private bool AlbumExists(int id)
        {
            return _service.AlbumExist(id);
        }


        public async Task<IActionResult> AllAlbums(int id, string searchTerm, int p = 1, int s = 5)
        {

            var userId = User.Id();
            var albums = await _service.AllAlbums(userId, id, searchTerm, p, s);

            return View(albums);
        }
    }
}
