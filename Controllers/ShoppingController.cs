using backapi.Models;
using backapi.Services;
using Microsoft.AspNetCore.Mvc;


namespace backapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly InterfaceProductService _productService;

        public ShoppingController(InterfaceProductService productService )
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }
        [HttpPost("UpdateStock")]
        public async Task<IActionResult> UpdateStock([FromBody] List<StockUpdate> stockUpdates)
        {
            foreach (var update in stockUpdates)
            {
                await _productService.UpdateStock(update.ProductId, update.Amount);
            }
            return Ok();
        }

    }
}
