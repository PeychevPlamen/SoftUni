using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MusicSpot.Data.DataConstants;

namespace MusicSpot.Data.Models
{
    public class Album
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(AlbumMaxNameLength)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }

        public int Year { get; set; }

        [Required]
        public string Format { get; set; }

        [Display(Name = "Media Condition")]
        public string MediaCondition { get; set; }

        [Display(Name = "Sleeve Condition")]
        public string SleeveCondition { get; set; }

        public string Notes { get; set; }

        //public bool IsPublic { get; set; }

        public ICollection<Track> Tracks { get; set; } = new List<Track>();

        [Required]
        [ForeignKey(nameof(Artist))]
        [Display(Name = "Artist")]
        public int ArtistId { get; set; }

        public Artist Artist { get; set; }  

    }
}
