using AcquireX.API.Model;
using AcquireX.Wrap.AcquireXClientConfiguration;
using AcquireX.Wrap.RSHughes;

namespace AcquireX.API.Service
{

    public interface IProductService
    {
        Task<RSHughesResponse> GetProductFromRSHughes();

        Task<ProductsResponse> GetProductFromBanner();


        List<ProductMatch> MatchProducts(RSHughesResponse rshughes, ProductsResponse banner);

    }
    public class ProductService : IProductService
    {
        public async Task<ProductsResponse> GetProductFromBanner()
        {
            var config = new AcquireXClientConfigBuilder()
               .SetAuthorizationBaseAddress(AcquireXClientConfigBuilder.AuthBaseAddress)
               .SetClientBaseAddress(AcquireXClientConfigBuilder.BaseAddress)
               .SetClientId(AcquireXClientConfigBuilder.ClientId)
               .SetClientSecret(AcquireXClientConfigBuilder.ClientSecret)
               .SetGrantType(AcquireXClientConfigBuilder.GrantType)
               .SetScope(AcquireXClientConfigBuilder.Scope)
               ;

            var configuration = await config.Build();
            var client = new AcquireXClient(configuration);
            RSHughesService rSHughesService = new RSHughesService(client);
            var leadRs = await rSHughesService.GetProductDataFromBanner();
            return leadRs;
        }

        public async Task<RSHughesResponse> GetProductFromRSHughes()
        {
            var config = new AcquireXClientConfigBuilder()
               .SetAuthorizationBaseAddress(AcquireXClientConfigBuilder.AuthBaseAddress)
               .SetClientBaseAddress(AcquireXClientConfigBuilder.BaseAddress)
               .SetClientId(AcquireXClientConfigBuilder.ClientId)
               .SetClientSecret(AcquireXClientConfigBuilder.ClientSecret)
               .SetGrantType(AcquireXClientConfigBuilder.GrantType)
               .SetScope(AcquireXClientConfigBuilder.Scope)
               ;

            var configuration = await config.Build();
            var client = new AcquireXClient(configuration);
            RSHughesService rSHughesService = new RSHughesService(client);
            var leadRs = await rSHughesService.GetProductDataFromRSHughes();
            return leadRs;
        }

        public List<ProductMatch> MatchProducts(RSHughesResponse rshughes, ProductsResponse banner)
        {
            var matchedProducts = new List<ProductMatch>();

            foreach (var rshughesProduct in rshughes.Products)
            {
                var matchingBannerProduct = banner.Product.Find(p => p.Upc == rshughesProduct.Upc && p.Upc != null && rshughesProduct.Upc != null);

                if (matchingBannerProduct != null)
                {
                    matchedProducts.Add(new ProductMatch
                    {
                        UPC = rshughesProduct.Upc,
                        BannerItemCode = matchingBannerProduct.ItemCode,
                        RSHughesItemCode = rshughesProduct.ItemCode
                    });
                }
            }

            return matchedProducts;
        }
    }
}
