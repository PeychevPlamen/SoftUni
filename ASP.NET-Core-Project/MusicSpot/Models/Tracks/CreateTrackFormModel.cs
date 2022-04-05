using System.ComponentModel.DataAnnotations;

using static MusicSpot.Data.DataConstants;

namespace MusicSpot.Models.Tracks
{
    public class CreateTrackFormModel
    {
        //public int Id { get; set; }

        [Required]
        [MaxLength(TrackMaxNameLength)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(TrackDurationRegEx, ErrorMessage = "Duration should be in format mm:ss")]
        public string Duration { get; set; }

        [Required]
        [Display(Name = "Album Name")]
        public int AlbumId { get; set; }
    }
}
