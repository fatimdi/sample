using Microsoft.AspNetCore.Mvc;
using tgworkshop.database.repositories;
using tgworkshop.domain.models;
using tgworkshop.models.ProductModels;

namespace tgworkshop.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route(nameof(CreateProduct))]
        public async Task<IActionResult> CreateProduct(AddProductModel product)
        {
            await _repository.AddProduct(product);
            Console.WriteLine($"Product '{product.Name}' added successfully.");
            return Ok();
        }

        [HttpGet]
        [Route(nameof(ListAllProducts))]
        public async Task<IActionResult> ListAllProducts()
        {            
            var products = await _repository.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"Product: {product.Name}, Price: {product.Price}, Stock: {product.Stock}");
            }
            return Ok(products);
        }
    }
}
