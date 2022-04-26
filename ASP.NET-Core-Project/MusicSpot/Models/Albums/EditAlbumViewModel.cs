using System.ComponentModel.DataAnnotations;

using static MusicSpot.Data.DataConstants;

namespace MusicSpot.Models.Albums
{
    public class EditAlbumViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(AlbumMaxNameLength)]
        public string Name { get; set; }

        [Required]
        [Url]
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Range(MinYearValue, MaxYearValue)]
        public int Year { get; set; }

        [Required]
        public string Format { get; set; }

        [Required]
        [Display(Name = "Media Condition")]
        public string MediaCondition { get; set; }

        [Required]
        [Display(Name = "Sleeve Condition")]
        public string SleeveCondition { get; set; }

        public string Notes { get; set; }

        public int ArtistId { get; set; }
    }
}
