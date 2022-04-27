using System.ComponentModel.DataAnnotations;
using static MusicSpot.Data.DataConstants;


namespace MusicSpot.Models.Games
{
    public class CreateGameFormModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(GameTitleMaxLength)]
        public string? Title { get; set; }

        [Required]
        [MaxLength(GameGenreMaxLength)]
        public string? Genre { get; set; }

        [Required]
        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }

        [Required]
        [MaxLength(GameDescriptionMaxLength)]
        public string? Description { get; set; }

        public string? UserId { get; set; }
    }
}
