using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MusicSpot.Data.DataConstants;

namespace MusicSpot.Data.Models
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ArtistMaxNameLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(GenreMaxLength)]
        public string Genre { get; set; }

        public IEnumerable<Album> Albums { get; set; } = new List<Album>();

        
    }
}
