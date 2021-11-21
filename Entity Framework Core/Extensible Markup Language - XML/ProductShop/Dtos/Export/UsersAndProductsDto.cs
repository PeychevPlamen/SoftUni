
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Users")]
    public class UsersAndProductsDto
    {
        [XmlElement("count")]
        public string Count { get; set; }

        [XmlArray("users")]
        public UsersDto[] Users { get; set; }
    }
}
