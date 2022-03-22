using System.ComponentModel.DataAnnotations;

namespace MusicSpot.Models.Albums
{
    public class AllAlbumsViewModel
    {
        public IEnumerable<string> AlbumName { get; set; }

        [Display(Name ="Search")]
        public string SearchTerm { get; set; }

        public AlbumSorting Sorting { get; set; }

        public IEnumerable<Data.Models.Album> Albums { get; set; }

            }
}
