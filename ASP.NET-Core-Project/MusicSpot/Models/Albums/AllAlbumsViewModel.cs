using System.ComponentModel.DataAnnotations;

namespace MusicSpot.Models.Albums
{
    public class AllAlbumsViewModel
    {
        public IEnumerable<string> AlbumName { get; set; }

        [Display(Name = "Search")]
        public string SearchTerm { get; set; }


        public IEnumerable<Data.Models.Album> Albums { get; set; }


        public int PageNum { get; set; }

        public int TotalRec { get; set; }

        public int PageSize { get; set; }

        public int ArtistId { get; set; }

        public string UserId { get; set; }

    }
}
