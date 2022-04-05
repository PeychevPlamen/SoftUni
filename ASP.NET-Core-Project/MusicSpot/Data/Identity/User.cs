using Microsoft.AspNetCore.Identity;
using MusicSpot.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static MusicSpot.Data.DataConstants;


namespace MusicSpot.Data.Identity
{
    public class User : IdentityUser
    {
        [MaxLength(UsernameMaxLength)]
        public string? FirstName { get; set; }

        [MaxLength(UsernameMaxLength)]
        public string? LastName { get; set; }

        public ICollection<Artist> Artists { get; set; } = new List<Artist>();

    }
}
