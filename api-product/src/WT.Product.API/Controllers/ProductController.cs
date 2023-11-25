using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WT.Product.Domain.Models.DTO;
using WT.Product.Domain.Services.Interfaces;

namespace WT.Product.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController(ILogger<ProductController> logger,
                                                    IMapper mapper,
                                                    IProductService productService) : ControllerBase
    {
        private readonly ILogger<ProductController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        private readonly IProductService _productService = productService ?? throw new ArgumentNullException(nameof(productService));

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ProductDTO>>(products));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Find(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(_mapper.Map<ProductDTO>(product));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductDTO productDto)
        {
            var product = _mapper.Map<Data.Entities.Product>(productDto);
            await _productService.CreateAsync(product);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] ProductDTO productDto)
        {
            var product = _mapper.Map<Data.Entities.Product>(productDto);
            await _productService.UpdateAsync(id, product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return Ok();
        }
    }
}
