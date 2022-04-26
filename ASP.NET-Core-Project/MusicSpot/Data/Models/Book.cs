﻿using MusicSpot.Data.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MusicSpot.Data.DataConstants;

namespace MusicSpot.Data.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(BookTitleMaxLength)]
        public string? Title { get; set; }

        [Required]
        [MaxLength(BookGenreMaxLength)]
        public string? Genre { get; set; }

        [Display(Name = "Image Url")]
        public string? ImageUrl { get; set; }

        [MaxLength(BookDescriptionMaxLength)]
        public string? Description { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }

        public User? User { get; set; }
    }
}
