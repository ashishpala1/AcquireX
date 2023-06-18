using AcquireX.API.Service;
using AcquireX.Wrap.AcquireXClientConfiguration;
using AcquireX.Wrap.RSHughes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcquireX.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcquireXController : ControllerBase
    {

        private readonly IProductService _productService;

        public AcquireXController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet(Name = "GetProductMatching")]
        public async Task<IActionResult> ProductMatch()
        {
            try
            {
                var rsHughes = await _productService.GetProductFromRSHughes();
                var banner = await _productService.GetProductFromBanner();
                var matchProduct = _productService.MatchProducts(rsHughes, banner);
                return Ok(matchProduct);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
