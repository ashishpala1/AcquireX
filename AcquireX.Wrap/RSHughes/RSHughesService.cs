using AcquireX.Wrap.AcquireXClientConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AcquireX.Wrap.RSHughes
{
    public class RSHughesService
    {
        private readonly AcquireXClient client;
        public RSHughesService(AcquireXClient client) { 
          this.client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<RSHughesResponse> GetProductDataFromRSHughes()
        {
            try
            {
                var response = await client.GetAsync($"/products/json");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<RSHughesResponse>(responseBody);
            }
            catch(HttpRequestException ex)
            {
                throw new RSHughesException(ex.Message);
            }
        }


        public async Task<ProductsResponse> GetProductDataFromBanner()
        {
            try
            {
                ProductsResponse result;
                var response = await client.GetAsync($"/products/xml");
                var responseBody = await response.Content.ReadAsStringAsync();
                XmlSerializer serializer = new XmlSerializer(typeof(ProductsResponse));
                using (TextReader reader = new StringReader(responseBody))
                {
                 result = (ProductsResponse)serializer.Deserialize(reader);
                }
                return result;
            }
            catch (HttpRequestException ex)
            {
                throw new RSHughesException(ex.Message);
            }
        }

    }
}
