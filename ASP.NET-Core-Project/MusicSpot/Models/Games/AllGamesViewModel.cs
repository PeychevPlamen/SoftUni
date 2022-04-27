using MusicSpot.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MusicSpot.Models.Games
{
    public class AllGamesViewModel
    {
        [Display(Name = "Search")]
        public string? SearchTerm { get; set; }

        public IEnumerable<Game> Games { get; set; }

        public int PageNum { get; set; }

        public int TotalRec { get; set; }

        public int PageSize { get; set; }

        public string? UserId { get; set; }
    }
}
