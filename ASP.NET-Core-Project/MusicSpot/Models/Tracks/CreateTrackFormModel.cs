using System.ComponentModel.DataAnnotations;

using static MusicSpot.Data.DataConstants;

namespace MusicSpot.Models.Tracks
{
    public class CreateTrackFormModel
    {
        [Required]
        [MaxLength(TrackMaxNameLength)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(TrackDurationRegEx, ErrorMessage = "Duration should be in format mm:ss")]
        public string Duration { get; set; }

        [Required]
        public int AlbumId { get; set; }
    }
}
