using System.ComponentModel.DataAnnotations;

namespace MusicSpot.Models.Artists
{
    public class AllArtistViewModel
    {
        public IEnumerable<string> ArtistsName { get; set; }

        [Display(Name = "Search")]
        public string SearchTerm { get; set; }

        public IEnumerable<Data.Models.Artist> Artists { get; set; }

    }
}
