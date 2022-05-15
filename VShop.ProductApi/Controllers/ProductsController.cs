using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Services;

namespace VShop.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerator<ProductDTO>>> Get()
        {
            var productDto = await _productService.GetProducts();
            if (productDto is null)
                return NotFound("Categories not found");
            return Ok(productDto);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<IEnumerator<ProductDTO>>> Get(int id)
        {
            var productDto = await _productService.GetProductById(id);
            if (productDto == null)
                return NotFound("Categories not found");

            return Ok(productDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO productDto)
        {
            if (productDto == null)
                return BadRequest("Invalid Data");
            await _productService.AddProduct(productDto);

            return new CreatedAtRouteResult("GetProduct", new { id = productDto.Id }, productDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO productDto)
        {
            if (id != productDto.Id)
                return BadRequest();

            if (productDto == null)
            {
                return BadRequest();
            }

            await _productService.UpdateProduct(productDto);

            return Ok(productDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var productDto = await _productService.GetProductById(id);
            if (productDto == null)
                return NotFound("Categories not found");

            await _productService.RemoveProduct(id);

            return Ok(productDto);
        }

    }
}
