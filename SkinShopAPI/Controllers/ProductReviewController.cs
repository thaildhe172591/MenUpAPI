using Microsoft.AspNetCore.Mvc;
using SkinShopAPI.DTOs;
using SkinShopAPI.Services.IService;
using System;

namespace SkinShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductReviewController : ControllerBase
    {
        private readonly IProductReviewService _service;


        public ProductReviewController(IProductReviewService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProductId(int productId)
            => Ok(await _service.GetByProductIdAsync(productId));

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductReviewDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.ReviewId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductReviewDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => await _service.DeleteAsync(id) ? NoContent() : NotFound();

        [HttpGet("product/{productId}/average-rating")]
        public async Task<IActionResult> GetAverageRating(int productId)
        {
            var average = await _service.GetAverageRatingAsync(productId);
            return Ok(new { productId, averageRating = average });
        }
    }
}
