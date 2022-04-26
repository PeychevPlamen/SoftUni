using System.ComponentModel.DataAnnotations;

namespace MusicSpot.Models.Books
{
    public class DetailsBooksFormModel
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Genre { get; set; }

        [Display(Name = "Image")]
        public string? ImageUrl { get; set; }

        public string? Description { get; set; }
    }
}
