using MusicSpot.Models.Movies;

namespace MusicSpot.Services.Movies
{
    public interface IMovieService
    {
        Task<AllMoviesViewModel> AllMovies(string userId, string searchTerm, int p, int s);

        Task<DetailsMovieFormModel> MovieDetails(int? movieId);

        int Create(
           string title,
           string genre,
           string imageUrl,
           int year,
           string description,
           string userId);

        bool Edit(
           int movieId,
           string title,
           string genre,
           string imageUrl,
           int year,
           string description);

        bool Delete(int movieId);

        bool MovieExist(int movieId);
    }
}
