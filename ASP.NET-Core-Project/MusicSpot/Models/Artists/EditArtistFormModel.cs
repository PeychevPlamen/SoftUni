using System.ComponentModel.DataAnnotations;

using static MusicSpot.Data.DataConstants;

namespace MusicSpot.Models.Artists
{
    public class EditArtistFormModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ArtistMaxNameLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(GenreMaxLength)]
        public string Genre { get; set; }

        public string? UserId { get; set; } // add to use in service
    }
}
