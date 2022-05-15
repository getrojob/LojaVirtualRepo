using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Services;

namespace VShop.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerator<CategoryDTO>>> Get()
        {
            var categoriesDto = await _categoryService.GetCategories();
            if (categoriesDto is null)
                return NotFound("Categories not found");
            return Ok(categoriesDto);
        }

        [HttpGet("Products")]
        public async Task<ActionResult<IEnumerator<CategoryDTO>>> GetCategoriasProducts()
        {
            var categoriesDto = await _categoryService.GetCategoriesProducts();
            if (categoriesDto == null)
                return NotFound("Categories not found");

            return Ok(categoriesDto);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<IEnumerator<CategoryDTO>>> Get(int id)
        {
            var categoriesDto = await _categoryService.GetCategoryById(id);
            if (categoriesDto == null)
                return NotFound("Categories not found");

            return Ok(categoriesDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDto)
        {
            if (categoryDto == null)
                return BadRequest("Invalid Data");
            await _categoryService.AddCategory(categoryDto);

            return new CreatedAtRouteResult("GetCategory", new { id = categoryDto.CategoryId }, categoryDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDto)
        {
            if (id != categoryDto.CategoryId)
                return BadRequest();

            if (categoryDto == null)
            {
                return BadRequest();
            }

            await _categoryService.UpdateCategory(categoryDto);

            return Ok(categoryDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var categoriesDto = await _categoryService.GetCategoryById(id);
            if (categoriesDto == null)
                return NotFound("Categories not found");

            await _categoryService.RemoveCategory(id);

            return Ok(categoriesDto);
        }

    }
}
