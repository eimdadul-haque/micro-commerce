using Catalog.Share.Products.Dtos;
using Catalog.Share.Products.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(
            IProductService productService)
        {
            _productService = productService;
        }

        public async Task Add(ProductDto input) 
            => await _productService.Add(input);
        
        public Task Delete(int id) 
            => _productService.Delete(id);

        public Task<IList<ProductDto>> Get(ProductFilterDto filter) 
            => _productService.Get(filter);

        public Task<ProductDto> Get(int id) 
            => _productService.Get(id);

        public Task Update(ProductDto input) 
            => _productService.Update(input);
    }
}
