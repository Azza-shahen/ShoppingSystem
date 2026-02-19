using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingSystem.API.Errors;
using ShoppingSystem.Core.Entities;
using ShoppingSystem.Core.Interfaces.Repositories;
using ShoppingSystem.Core.Specifications;
using ShoppingSystem.Core.Specifications.ProductSpecifications;

namespace ShoppingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IGenericRepository<Product> _productsRepo,IMapper _mapper) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var spec = new ProductWithBrandAndCategorySpecifications();
            var products = await _productsRepo.GetAllWithSpecAsync(spec);

            return Ok(_mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var spec = new ProductWithBrandAndCategorySpecifications(id);
            var product = await _productsRepo.GetWithSpecAsync(spec);
            if (product is null)
                return NotFound(new ApiResponse(404));

            return Ok(_mapper.Map<Product,ProductDto>(product));//200
        }
    }
}
