using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MusicSpot.Data.DataConstants;

namespace MusicSpot.Data.Models
{
    public class Track
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TrackMaxNameLength)]
        public string Name { get; set; }

        [Required]
        public string Duration { get; set; }

        [Required]
        [ForeignKey(nameof(Album))]
        public int AlbumId { get; set; }

        public Album Album { get; set; }
    }
}
