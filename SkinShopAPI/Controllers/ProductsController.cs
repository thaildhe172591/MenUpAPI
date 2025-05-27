using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkinShopAPI.Data;
using SkinShopAPI.DTOs;
using SkinShopAPI.Models;
using SkinShopAPI.Services.IService;

namespace SkinShopAPI.Controllers
{
    [Authorize] // Update the attribute to [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _service;
        private readonly SkincareShopForMenContext _context;
        public ProductsController(IProductService service, SkincareShopForMenContext context)
        {
            _service = service;
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Staff")] // Only allow Admins to create products
        public async Task<IActionResult> Create([FromBody] ProductCreateDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Quantity = dto.Quantity,
                CategoryId = dto.CategoryId,
                BrandId = dto.BrandId,
                ImageUrl = dto.ImageUrl,
                GenderTarget = dto.GenderTarget,
                AffiliateLink = dto.AffiliateLink
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = product.ProductId }, product);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Staff")] // Only allow Admins and Staff to update products
        public async Task<IActionResult> Update(int id, [FromBody] ProductUpdateDto dto)
        {
            if (id != dto.ProductId)
                return BadRequest("Product ID mismatch.");

            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.Quantity = dto.Quantity;
            product.CategoryId = dto.CategoryId;
            product.BrandId = dto.BrandId;
            product.ImageUrl = dto.ImageUrl;
            product.GenderTarget = dto.GenderTarget;
            product.AffiliateLink = dto.AffiliateLink;

            await _context.SaveChangesAsync();
            return Ok(); // 204
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Staff")] // Only allow Admins and Staff to delete products
        public async Task<IActionResult> Delete(int id)
        {
            var existingProduct = await _service.GetProductByIdAsync(id);
            if (existingProduct == null)
                return NotFound();

            await _service.DeleteProductAsync(id);
            return Ok();
        }

        [HttpPost("import-excel")]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<IActionResult> ImportFromExcel(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Vui lòng chọn file Excel hợp lệ.");

            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);

            using var package = new OfficeOpenXml.ExcelPackage(stream);
            var worksheet = package.Workbook.Worksheets.FirstOrDefault();
            if (worksheet == null) return BadRequest("File Excel không có dữ liệu.");

            var products = new List<Product>();
            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                var product = new Product
                {
                    Name = worksheet.Cells[row, 1].Text,
                    Description = worksheet.Cells[row, 2].Text,
                    Price = decimal.TryParse(worksheet.Cells[row, 3].Text, out var price) ? price : 0,
                    Quantity = int.TryParse(worksheet.Cells[row, 4].Text, out var quantity) ? quantity : 0,
                    CategoryId = int.TryParse(worksheet.Cells[row, 5].Text, out var categoryId) ? categoryId : null,
                    BrandId = int.TryParse(worksheet.Cells[row, 6].Text, out var brandId) ? brandId : null,
                    ImageUrl = worksheet.Cells[row, 7].Text,
                    GenderTarget = worksheet.Cells[row, 8].Text,
                    CreatedAt = DateTime.UtcNow,
                    AffiliateLink = worksheet.Cells[row, 9].Text
                };
                products.Add(product);
            }

            foreach (var p in products)
            {
                await _service.AddProductAsync(p);
            }

            return Ok(new { Message = $"Đã nhập {products.Count} sản phẩm từ Excel." });
        }

    }

}
