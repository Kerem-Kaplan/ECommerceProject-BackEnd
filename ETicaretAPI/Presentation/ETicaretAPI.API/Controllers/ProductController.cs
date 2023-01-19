using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;
        public ProductController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            //await _productWriteRepository.AddRangeAsync(new()
            //{
            //    new() { Id = Guid.NewGuid(), Name = "Product 1", Price = 123, CreatedDate = DateTime.UtcNow, Stock = 12 },
            //    new() { Id = Guid.NewGuid(), Name = "Product 2", Price = 223, CreatedDate = DateTime.UtcNow, Stock = 22 },
            //    new() { Id = Guid.NewGuid(), Name = "Product 3", Price = 323, CreatedDate = DateTime.UtcNow, Stock = 32 },
            //});
            //await _productWriteRepository.SaveAsync();

            Product p = await _productReadRepository.GetByIdAsync("4d069ad8-05cc-4973-a2db-eb0b348654d6", false);
            p.Name = "Mehmet";
            await _productWriteRepository.SaveAsync();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);



        }
    }
}
