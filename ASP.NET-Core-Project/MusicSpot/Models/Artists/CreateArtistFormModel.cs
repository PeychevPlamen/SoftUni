using System.ComponentModel.DataAnnotations;

using static MusicSpot.Data.DataConstants;


namespace MusicSpot.Models.Artists
{
    public class CreateArtistFormModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ArtistMaxNameLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(GenreMaxLength)]
        public string Genre { get; set; }

    }
}
