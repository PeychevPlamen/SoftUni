using System.ComponentModel.DataAnnotations;
using static MusicSpot.Data.DataConstants;

namespace MusicSpot.Models.Books
{
    public class CreateBookFormModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(BookTitleMaxLength)]
        public string? Title { get; set; }

        [Required]
        [MaxLength(BookGenreMaxLength)]
        public string? Genre { get; set; }

        [Required]
        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }

        [Required]
        [MaxLength(BookDescriptionMaxLength)]
        public string? Description { get; set; }

        public string? UserId { get; set; }
    }
}