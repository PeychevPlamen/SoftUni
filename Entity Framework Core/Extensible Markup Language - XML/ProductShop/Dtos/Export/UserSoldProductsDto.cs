
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("User")]
    public class UserSoldProductsDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public string Age { get; set; }   // for 8 task needed

        [XmlArray("soldProducts")]
        public SoldProductsDto[] SoldProducts { get; set; }
    }
}
