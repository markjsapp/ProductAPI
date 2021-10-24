using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restauraunt.Web.Models;
using Restauraunt.Web.Services.IServices;

namespace Restauraunt.Web.Controllers
{
    public class ProductController : Controller
    {
        // Dependency injection
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto> list = new();
            var response = await _productService.GetAllProductsAsync<ResponseDto>();
            // If response returns anything and is successful we deserialize it 
            // If you need to debug this, navigate to where the call is actually made (Web/Services/BaseService.cs)
            if(response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
    }
}
