﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("SoldProducts")]
    public class SoldProductsCountDto
    {

        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public SoldProductsDto[] Products { get; set; }
    }
}
