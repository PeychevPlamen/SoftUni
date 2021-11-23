
using System.Collections.Generic;

using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Users")]
    public class MainDto
    {
        [XmlAttribute("Count")]
        public int Count { get; set; }

        [XmlElement("users")]
        public UserSoldProductsDto[] Users { get; set; }
    }
}