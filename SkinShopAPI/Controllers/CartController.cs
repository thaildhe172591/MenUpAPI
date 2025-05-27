using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkinShopAPI.Data;
using SkinShopAPI.DTOs;
using SkinShopAPI.Models;
using SkinShopAPI.Services.IService;
using System;
using System.Security.Claims;

namespace SkinShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartItemService _service;
        private readonly SkincareShopForMenContext _context;


        public CartItemsController(ICartItemService service, SkincareShopForMenContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCart(int userId)
        {
            return Ok(await _service.GetUserCartAsync(userId));
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> AddItem(int userId, [FromBody] CartItemRequestDto dto)
        {
            var result = await _service.AddToCartAsync(userId, dto);
            return Ok(result);
        }

        [HttpPut("{cartItemId}")]
        public async Task<IActionResult> UpdateItem(int cartItemId, [FromQuery] int newQuantity)
        {
            var cartItem = await _context.CartItems.FindAsync(cartItemId);
            if (cartItem == null)
            {
                return NotFound();
            }

            cartItem.Quantity = newQuantity;
            await _context.SaveChangesAsync();

            return Ok(cartItem);
        }

        [HttpDelete("{cartItemId}")]
        public async Task<IActionResult> RemoveItem(int cartItemId)
        {
            var success = await _service.RemoveFromCartAsync(cartItemId);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("clear/{userId}")]
        public async Task<IActionResult> ClearCart(int userId)
        {
            var success = await _service.ClearCartAsync(userId);
            return success ? NoContent() : NotFound();
        }
    }
}
