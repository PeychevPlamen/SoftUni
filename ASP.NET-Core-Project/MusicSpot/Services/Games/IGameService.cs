using MusicSpot.Data.Models;
using MusicSpot.Models.Games;

namespace MusicSpot.Services.Games
{
    public interface IGameService
    {
        Task<AllGamesViewModel> AllGames(string userId, string searchTerm, int p, int s);

        Task<DetailsGameFormModel> GameDetails(int? gameId);

        int Create(
           string title,
           string genre,
           string imageUrl,
           string description,
           string userId);

        bool Edit(
           int gameId,
           string title,
           string genre,
           string imageUrl,
           string description);

        bool Delete(int gameId);

        bool GameExist(int gameId);
    }
}
