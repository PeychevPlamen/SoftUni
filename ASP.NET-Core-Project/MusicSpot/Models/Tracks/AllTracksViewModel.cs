using MusicSpot.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MusicSpot.Models.Tracks
{
    public class AllTracksViewModel
    {
        public IEnumerable<string> TrackName { get; set; }

        [Display(Name = "Search")]
        public string SearchTerm { get; set; }


        public IEnumerable<Track> Tracks { get; set; }

        public int AlbumId { get; set; } // new added track service

        public int PageNum { get; set; }

        public int TotalRec { get; set; }

        public int PageSize { get; set; }

        public string? UserId { get; set; }
    }
}
