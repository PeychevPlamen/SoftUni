using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static SMS.Data.DataConstants;


namespace SMS.Data.Models
{
    public class Product
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(ProductNameMaxLength)]
        public string Name { get; set; }

        [Range(0.05, 1000)]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [ForeignKey(nameof(Cart))]
        
        public string CartId { get; set; }
        public Cart Cart { get; set; }

    }
}
