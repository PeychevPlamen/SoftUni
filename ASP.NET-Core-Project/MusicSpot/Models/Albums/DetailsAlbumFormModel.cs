using MusicSpot.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MusicSpot.Models.Albums
{
    public class DetailsAlbumFormModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        [Display(Name = "Image")]
        public string? ImageUrl { get; set; }

        public int Year { get; set; }

        public string? Format { get; set; }

        public string? MediaCondition { get; set; }

        public string? SleeveCondition { get; set; }

        public string? Notes { get; set; }

        public Artist? Artist { get; set; }

        public int? ArtistId { get; set; }  // added for edit album
    }
}
