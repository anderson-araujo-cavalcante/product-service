using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WT.Product.Data.Entities;
using WT.Product.Domain.Models.DTO;
using WT.Product.Domain.Services.Interfaces;

namespace WT.Product.API.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController(ILogger<ProductController> logger,
                                                       IMapper mapper,
                                                       ICategoryService categoryService) : ControllerBase
    {
        private readonly ILogger<ProductController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        private readonly ICategoryService _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryDTO>>(categories));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Find(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return Ok(_mapper.Map<CategoryDTO>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryDTO product)
        {
            var categoryDTO = _mapper.Map<Category>(product);
            await _categoryService.CreateAsync(categoryDTO);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            await _categoryService.UpdateAsync(id, category);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);
            return Ok();
        }
    }
}
