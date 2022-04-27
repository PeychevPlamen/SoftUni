using Microsoft.EntityFrameworkCore;
using MusicSpot.Data;
using MusicSpot.Data.Models;
using MusicSpot.Models.Movies;

namespace MusicSpot.Services.Movies
{

    public class MovieService : IMovieService
    {
        private readonly MusicSpotDbContext _context;

        public MovieService(MusicSpotDbContext context)
        {
            _context = context;
        }

        public async Task<AllMoviesViewModel> AllMovies(string userId, string searchTerm, int p, int s)
        {
            var currMovie = await _context.Movies.Where(a => a.UserId == userId).ToListAsync();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                currMovie = currMovie.Where(a => a.Title.ToLower().Contains(searchTerm.ToLower()) ||
                a.Year.ToString().ToLower().Contains(searchTerm.ToLower()) || a.Description.ToString().ToLower().Contains(searchTerm.ToLower())).ToList();
            }

            var result = new AllMoviesViewModel
            {
                Movies = currMovie
                              .OrderBy(x => x.Title)
                              .ThenBy(x => x.Year)
                              .Skip(p * s - s)
                              .Take(s)
                              .ToList(),
                SearchTerm = searchTerm,
                PageNum = p,
                PageSize = s,
                TotalRec = currMovie.Count(),
                UserId = userId
            };

            return result;
        }

        public int Create(string title, string genre, string imageUrl, int year, string description, string userId)
        {
            var newMovie = new Movie
            {
                Title = title,
                Genre = genre,
                ImageUrl = imageUrl,
                Year = year,
                Description = description,
                UserId = userId
            };

            _context.Movies.AddAsync(newMovie);
            _context.SaveChangesAsync();

            return newMovie.Id;
        }

        public bool Delete(int movieId)
        {
            var movie = _context.Movies.Find(movieId);

            if (movie == null)
            {
                return false;
            }

            _context.Remove(movie);
            _context.SaveChangesAsync();

            return true;
        }

        public bool Edit(int movieId, string title, string genre, string imageUrl, int year, string description)
        {
            var movieData = _context.Movies.Find(movieId);

            if (movieData == null)
            {
                return false;
            }

            movieData.Title = title;
            movieData.Genre = genre;
            movieData.ImageUrl = imageUrl;
            movieData.Year = year;
            movieData.Description = description;

            _context.Update(movieData);
            _context.SaveChangesAsync();

            return true;
        }

        public async Task<DetailsMovieFormModel> MovieDetails(int? movieId)
        {
            var movie = await _context.Movies
                          .FirstOrDefaultAsync(m => m.Id == movieId);

            var result = new DetailsMovieFormModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                ImageUrl = movie.ImageUrl,
                Year = movie.Year,
                Description = movie.Description
            };

            return result;
        }

        public bool MovieExist(int movieId)
        {
            var movie = _context.Movies.Find(movieId);

            if (movie == null)
            {
                return false;
            }

            return true;
        }
    }
}
