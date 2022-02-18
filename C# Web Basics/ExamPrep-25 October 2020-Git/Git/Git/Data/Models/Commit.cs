using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Git.Data.DataConstants;

namespace Git.Data.Models
{
    public class Commit
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [MinLength(DescriptionMinLength)]
        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public string CreatorId { get; set; }

        public User Creator { get; set; }

        public string RepositoryId { get; set; }

        public Repository Repository { get; set; }
    }
}
//•	Has an Id – a string, Primary Key
//•	Has a Description – a string with min length 5 (required)
//•	Has a CreatedOn – a datetime (required)
//•	Has a CreatorId – a string
//•	Has Creator – a User object
//•	Has RepositoryId – a string
//•	Has Repository– a Repository object
