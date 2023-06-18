using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AcquireX.Wrap.RSHughes
{

    [XmlRoot(ElementName = "product")]
    public class ProductBanner
    {

        [XmlElement(ElementName = "itemCode")]
        public string ItemCode { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "manufacturer")]
        public string Manufacturer { get; set; }

        [XmlElement(ElementName = "upc")]
        public string Upc { get; set; }

        [XmlElement(ElementName = "price")]
        public double Price { get; set; }

        [XmlElement(ElementName = "brand")]
        public string Brand { get; set; }
    }

    [XmlRoot(ElementName = "ProductsResponse")]
    public class ProductsResponse
    {

        [XmlElement(ElementName = "product")]
        public List<ProductBanner> Product { get; set; }

        [XmlAttribute(AttributeName = "xsi")]
        public string Xsi { get; set; }

        [XmlAttribute(AttributeName = "xsd")]
        public string Xsd { get; set; }

        [XmlText]
        public string Text { get; set; }

        public object Find(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }

}
