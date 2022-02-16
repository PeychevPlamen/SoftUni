using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Git.Data.DataConstants;

namespace Git.Data.Models
{
    public class Repository
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(RepoNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [Required]
        public bool IsPublic { get; set; }

        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; }

        public User Owner { get; set; }

        public ICollection<Commit> Commits { get; set; } = new List<Commit>();
    }
}

//•	Has an Id – a string, Primary Key
//•	Has a Name – a string with min length 3 and max length 10 (required)
//•	Has a CreatedOn – a datetime (required)
//•	Has a IsPublic – bool (required)
//•	Has a OwnerId – a string
//•	Has a Owner – a User object
//•	Has Commits collection – a Commit type
