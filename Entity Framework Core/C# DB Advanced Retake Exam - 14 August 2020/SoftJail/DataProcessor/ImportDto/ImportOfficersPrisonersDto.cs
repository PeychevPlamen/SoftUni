using SoftJail.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class ImportOfficersPrisonersDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(3),MaxLength(30)]
        public string Name { get; set; }

        [XmlElement("Money")]
        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Money { get; set; }

        [XmlElement("Position")]
        [Required]
        [EnumDataType(typeof(Position))]
        public string Position { get; set; }

        [XmlElement("Weapon")]
        [Required]
        [EnumDataType(typeof (Weapon))]
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")]
        [Required]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public PrisonersDto Prisoners { get; set; }
    }

    [XmlType("Prisoner")]
    public class PrisonersDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
