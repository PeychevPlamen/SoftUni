using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Data.Models
{
    public class Cart
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        //public string UserId { get; set; }
        [Required]
        public User User { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
