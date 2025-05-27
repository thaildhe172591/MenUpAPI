using Microsoft.AspNetCore.Mvc;
using SkinShopAPI.DTOs;
using SkinShopAPI.Services.IService;

namespace SkinShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailService _service;

        public OrderDetailsController(IOrderDetailService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetByOrderId(int orderId) =>
            Ok(await _service.GetByOrderIdAsync(orderId));

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDetailDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.OrderDetailId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OrderDetailDto dto)
        {
            if (id != dto.OrderDetailId) return BadRequest("ID mismatch");
            return Ok(await _service.UpdateAsync(id, dto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}
