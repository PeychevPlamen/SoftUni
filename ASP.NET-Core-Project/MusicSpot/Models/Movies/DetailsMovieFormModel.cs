using System.ComponentModel.DataAnnotations;

namespace MusicSpot.Models.Movies
{
    public class DetailsMovieFormModel
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Genre { get; set; }

        [Display(Name = "Image")]
        public string? ImageUrl { get; set; }

        public int Year { get; set; }

        public string? Description { get; set; }
    }
}
