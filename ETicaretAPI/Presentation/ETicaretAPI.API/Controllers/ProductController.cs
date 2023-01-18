using ETicaretAPI.Application.Repositories;
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
        public async void Get()
        {
            _productWriteRepository.AddRangeAsync(new()
            {
                new() { Id = Guid.NewGuid(), Name = "Product 1", Price = 123, CreatedDate = DateTime.UtcNow, Stock = 12 },
                new() { Id = Guid.NewGuid(), Name = "Product 2", Price = 223, CreatedDate = DateTime.UtcNow, Stock = 22 },
                new() { Id = Guid.NewGuid(), Name = "Product 3", Price = 323, CreatedDate = DateTime.UtcNow, Stock = 32 },
            });
            await _productWriteRepository.SaveAsync();
        }
    }
}
