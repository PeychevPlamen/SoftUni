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
using MusicSpot.Services.Albums;
using MusicSpot.Services.Tracks;

namespace MusicSpot.Controllers
{
    public class TracksController : Controller
    {
        private readonly ITrackService _service;
        private readonly IAlbumService _albums;

        public TracksController(IAlbumService albums, ITrackService service)
        {
            _albums = albums;
            _service = service;
        }

        // GET: Tracks
        [Authorize]
        public async Task<IActionResult> Index(string searchTerm, int p = 1, int s = 5)
        {
            var userId = User.Id();

            var currTracks = await _service.Index(userId, searchTerm, p, s);

            return View(currTracks);

        }

        // GET: Tracks/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = await _service.TrackDetails(id);

            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        // GET: Tracks/Create
        [Authorize]
        public async Task<IActionResult> Create(int id)
        {
            var userId = User?.Id();
            var album = await _albums.Albums(id);


            ViewData["AlbumId"] = new SelectList(album, "Id", "Name");
            return View();
        }

        // POST: Tracks/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTrackFormModel track)
        {
            var currAlbum = await _albums.Albums(track.AlbumId);

            if (ModelState.IsValid)
            {
                var trackId = _service.Create(
                    track.Name,
                    track.Duration,
                    track.AlbumId);

                return RedirectToAction(nameof(Create));
            }

            ViewData["AlbumId"] = new SelectList(currAlbum, "Id", "Name", track.AlbumId);
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

            var track = await _service.TrackEdit(id);

            var currAlbum = await _albums.Albums(track.AlbumId);

            if (track == null)
            {
                return NotFound();
            }

            ViewData["AlbumId"] = new SelectList(currAlbum, "Id", "Name", track.AlbumId);
            return View(track);
        }

        // POST: Tracks/Edit/5

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditTrackFormModel track)
        {
            if (id != track.Id)
            {
                return NotFound();
            }

            var currTrack = new Track
            {
                Id = track.Id,
                Name = track.Name,
                Duration = track.Duration,
                AlbumId = track.AlbumId
            };

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Edit(
                        id,
                        track.Name,
                        track.Duration,
                        track.AlbumId
                        );
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

            var currAlbum = await _albums.Albums(track.AlbumId);

            ViewData["AlbumId"] = new SelectList(currAlbum, "Id", "Name", track.AlbumId);
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

            var track = await _service.TrackDetails(id);

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
            var track = _service.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        private bool TrackExists(int id)
        {
            return _service.TrackExist(id);
        }

        [Authorize]
        public async Task<IActionResult> AllTracks(int id)
        {

            var tracks = await _service.AllTracks(id);

            return View(tracks);
        }
    }
}
