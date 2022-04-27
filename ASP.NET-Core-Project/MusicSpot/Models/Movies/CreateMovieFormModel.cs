using System.ComponentModel.DataAnnotations;
using static MusicSpot.Data.DataConstants;

namespace MusicSpot.Models.Movies
{
    public class CreateMovieFormModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string? Title { get; set; }

        [Required]
        [MaxLength(GenreMaxLength)]
        public string? Genre { get; set; }

        [Required]
        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }

        [Required]
        [Range(MinYearValue, MaxYearValue)]
        public int Year { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        public string? UserId { get; set; }
    }
}
