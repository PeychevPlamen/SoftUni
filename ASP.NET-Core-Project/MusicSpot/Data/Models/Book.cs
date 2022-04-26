using MusicSpot.Data.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSpot.Data.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Genre { get; set; }

        [Display(Name = "Image Url")]
        public string? ImageUrl { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }

        public User? User { get; set; }
    }
}
