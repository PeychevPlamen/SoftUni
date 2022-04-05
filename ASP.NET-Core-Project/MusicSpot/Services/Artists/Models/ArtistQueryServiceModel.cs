namespace MusicSpot.Services.Artists.Models
{
    public class ArtistQueryServiceModel
    {
        public int CurrentPage { get; set; }

        public int CarsPerPage { get; set; }

        public int TotalCars { get; set; }

        public IEnumerable<ArtistServiceModel> Artists { get; set; }
    }
}
