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
using MusicSpot.Infrastructure.Extensions;
using MusicSpot.Models.Movies;
using MusicSpot.Services.Movies;

namespace MusicSpot.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MusicSpotDbContext _context;
        private readonly IMovieService _service;

        public MoviesController(MusicSpotDbContext context, IMovieService service)
        {
            _context = context;
            _service = service;
        }

        // GET: Movies
        public async Task<IActionResult> Index(string searchTerm, int p = 1, int s = 5)
        {
            var userID = User.Id();

            var model = await _service.AllMovies(userID, searchTerm, p, s);
            return View(model);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _service.MovieDetails(id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateMovieFormModel movie)
        {
            var userId = User.Id();
            movie.UserId = userId;

            if (ModelState.IsValid)
            {
                var currGame = _service.Create(
                    movie.Title,
                    movie.Genre,
                    movie.ImageUrl,
                    movie.Year,
                    movie.Description,
                    userId);

                return RedirectToAction(nameof(Index));
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _service.MovieDetails(id);

            if (movie == null)
            {
                return NotFound();
            }
            
            return View(movie);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditMovieFormModel movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Edit(
                        movie.Id,
                        movie.Title,
                        movie.Genre,
                        movie.ImageUrl,
                        movie.Year,
                        movie.Description);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
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
            
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _service.MovieDetails(id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = _service.Delete(id);
            
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _service.MovieExist(id);
        }
    }
}
