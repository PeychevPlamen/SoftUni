using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportProjectionJsonDto
    {
        [Required]
        [MaxLength(30), MinLength(4)]
        public string Name { get; set; }

        [Required]
        [Range(typeof(sbyte), "1", "10")]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [MaxLength(30), MinLength(4)]
        public string Director { get; set; }

        public TicketDto[] Tickets { get; set; }
    }

    public class TicketDto
    {
        [Required]
        [Range(typeof(decimal), "1.00", "100.00")]
        public decimal Price { get; set; }

        [Required]
        [Range(typeof(sbyte), "1", "10")]
        public sbyte RowNumber { get; set; }

        [Required]
        public int PlayId { get; set; }
    }
}

//•	Id – integer, Primary Key
//•	Name – text with length [4, 30] (required)
//•	NumberOfHalls – sbyte between[1…10] (required)
//•	Director – text with length [4, 30] (required)
//•	Tickets - a collection of type Ticket

//•	Price – decimal in the range [1.00….100.00] (required)
//•	RowNumber – sbyte in range[1….10](required)
//•	PlayId – integer, foreign key(required)

