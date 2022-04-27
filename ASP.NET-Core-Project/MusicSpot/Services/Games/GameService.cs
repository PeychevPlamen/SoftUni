using Microsoft.EntityFrameworkCore;
using MusicSpot.Data;
using MusicSpot.Data.Models;
using MusicSpot.Models.Games;

namespace MusicSpot.Services.Games
{
    public class GameService : IGameService
    {
        private readonly MusicSpotDbContext _context;

        public GameService(MusicSpotDbContext context)
        {
            _context = context;
        }

        public async Task<AllGamesViewModel> AllGames(string userId, string searchTerm, int p, int s)
        {
            var currGames = await _context.Games.Where(a => a.UserId == userId).ToListAsync();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                currGames = currGames.Where(a => a.Title.ToLower().Contains(searchTerm.ToLower()) ||
                a.Description.ToString().ToLower().Contains(searchTerm.ToLower())).ToList();
            }

            var result = new AllGamesViewModel
            {
                Games = currGames
                              .OrderBy(x => x.Title)
                              .Skip(p * s - s)
                              .Take(s)
                              .ToList(),
                SearchTerm = searchTerm,
                PageNum = p,
                PageSize = s,
                TotalRec = currGames.Count(),
                UserId = userId
            };

            return result;
        }

        public int Create(string title, string genre, string imageUrl, string description, string userId)
        {
            var newGame = new Game
            {
                Title = title,
                Genre = genre,
                ImageUrl = imageUrl,
                Description = description,
                UserId = userId
            };

            _context.Games.AddAsync(newGame);
            _context.SaveChangesAsync();

            return newGame.Id;
        }

        public bool Delete(int gameId)
        {
            var game = _context.Games.Find(gameId);

            if (game == null)
            {
                return false;
            }

            _context.Remove(game);
            _context.SaveChangesAsync();

            return true;
        }

        public bool Edit(int gameId, string title, string genre, string imageUrl, string description)
        {
            var gameData = _context.Games.Find(gameId);

            if (gameData == null)
            {
                return false;
            }

            gameData.Title = title;
            gameData.Genre = genre;
            gameData.ImageUrl = imageUrl;
            gameData.Description = description;

            _context.Update(gameData);
            _context.SaveChangesAsync();

            return true;
        }

        public async Task<DetailsGameFormModel> GameDetails(int? gameId)
        {
            var game = await _context.Games
                          .FirstOrDefaultAsync(m => m.Id == gameId);

            var result = new DetailsGameFormModel
            {
                Id = game.Id,
                Title = game.Title,
                Genre = game.Genre,
                ImageUrl = game.ImageUrl,
                Description = game.Description
            };

            return result;
        }

        public bool GameExist(int gameId)
        {
            var game = _context.Books.Find(gameId);

            if (game == null)
            {
                return false;
            }

            return true;
        }

    }
}
