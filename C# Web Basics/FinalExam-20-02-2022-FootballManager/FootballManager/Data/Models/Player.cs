using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static FootballManager.Data.DataConstants;

namespace FootballManager.Data.Models
{
    public class Player
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(PlayerFullNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(PositionMaxLength)]
        public string Position { get; set; }

        [Required]
        [Range(SpeedMin, SpeedMax)]
        public byte Speed { get; set; }

        [Required]
        [Range(EnduranceMin, EnduranceMax)]
        public byte Endurance { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public ICollection<UserPlayer> UserPlayers { get; set; } = new List<UserPlayer>();
    }
}

//•	Has Id – an int, Primary Key
//•	Has FullName – a string (required); min.length: 5, max.length: 80
//•	Has ImageUrl – a string (required)
//•	Has Position – a string (required); min.length: 5, max.length: 20
//•	Has Speed – a byte (required); cannot be negative or bigger than 10
//•	Has Endurance – a byte (required); cannot be negative or bigger than 10
//•	Has a Description – a string with max length 200 (required)
//•	Has UserPlayers collection
