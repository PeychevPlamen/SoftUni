
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("SoldProducts")]
    public class SoldProductsWithCount
    {
        [XmlAttribute("count")]
        public string Count { get; set; }

        [XmlArray("products")]
        public ProductNamePriceDto[] Products { get; set; }
    }
}
