using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SkinShopAPI.Data;
using SkinShopAPI.DTOs;
using SkinShopAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Net.Http.Headers;
using System.Text.Json;
using SkinShopAPI.Services.IService;


namespace SkinShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FaceAnalysisController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _aiApiKey;
        private readonly string _aiApiBaseUrl;
        private readonly SkincareShopForMenContext _context;

        private readonly ISkinAnalysisService _service;

        public FaceAnalysisController(IConfiguration configuration, SkincareShopForMenContext context, ISkinAnalysisService service)
        {
            _configuration = configuration;
            _context = context;
            _service = service;
            _aiApiKey = _configuration["AIApi:ApiKey"];
            _aiApiBaseUrl = _configuration["AIApi:BaseUrl"];
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetSkinAnalysisAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetSkinAnalysisByIdAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        //[HttpPost("analyze")]
        //public async Task<IActionResult> AnalyzeFace(IFormFile image)
        //{
        //    if (image == null || image.Length == 0)
        //        return BadRequest("No image provided");

        //    try
        //    {
        //        // Validate image
        //        if (!IsValidImage(image))
        //            return BadRequest("Invalid image format");

        //        // Call third-party API
        //        var analysisResult = await CallAIAnalysisApi(image);

        //        return Ok(analysisResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Error analyzing image: {ex.Message}");
        //    }
        //}
        [HttpPost("analyze")]
        public async Task<IActionResult> AnalyzeFace(IFormFile image)
        {
            if (image == null || image.Length == 0)
                return BadRequest("No image provided");

            try
            {
                if (!IsValidImage(image))
                    return BadRequest("Invalid image format");

                var analysisResult = await CallAIAnalysisApi(image);
                var suggestions = await _service.SuggestProductsFromAnalysisAsync(analysisResult);

                return Ok(new
                {
                    analysis = analysisResult,
                    suggestions
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error analyzing image: {ex.Message}");
            }
        }


        private async Task<object> CallAIAnalysisApi(IFormFile image)
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("ailabapi-api-key", _aiApiKey);

            using var content = new MultipartFormDataContent();
            using var stream = new MemoryStream();
            await image.CopyToAsync(stream);
            stream.Position = 0;

            var imageContent = new StreamContent(stream);
            imageContent.Headers.ContentType = new MediaTypeHeaderValue(image.ContentType);

            content.Add(imageContent, "image", image.FileName);

            var response = await httpClient.PostAsync($"{_aiApiBaseUrl}/api/portrait/analysis/skin-analysis-advanced", content);
            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception($"AI API call failed: {response.StatusCode} - {responseString}");

            return JsonSerializer.Deserialize<object>(responseString);
        }


        private bool IsValidImage(IFormFile image)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".bmp" };
            var extension = Path.GetExtension(image.FileName).ToLowerInvariant();
            return allowedExtensions.Contains(extension) && image.Length < 10 * 1024 * 1024; // Max 10MB
        }
    }
}

