using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AcquireX.Wrap.RSHughes
{
    public class RSHughesResponse
    {
        [JsonPropertyName("products")]
        public List<Product> Products { get; set; }
    }

    public class Product
    {
        [JsonPropertyName("itemCode")]
        public string ItemCode { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonPropertyName("mpn")]
        public string Mpn { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }

        [JsonPropertyName("brand")]
        public string Brand { get; set; }

        [JsonPropertyName("upc")]
        public string Upc { get; set; }
    }


}
