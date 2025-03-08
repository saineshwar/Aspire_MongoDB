using AspireApp6.ApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace AspireApp6.ApiService
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMongoCollection<Product> _productCollection;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iMongoClient"></param>
        public ProductController(IMongoClient iMongoClient)
        {
            var database = iMongoClient.GetDatabase("ProductDatabase");
            _productCollection = database.GetCollection<Product>("products");
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var listofProducts = await _productCollection.Find(FilterDefinition<Product>.Empty).ToListAsync();
            return Ok(listofProducts);
        }

        [HttpPost]
        public async Task<bool> AddProduct([FromBody] ProductRequest product)
        {
            try
            {
                
                var newProduct = new Product
                {
                    Name = product.Name,
                    ProductId = product.ProductId,
                    CreatedAt = DateTime.Now,
                    Description = product.Description,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    CategoryID = product.Quantity,
                    ImageUrl = product.ImageUrl
                };
                await _productCollection.InsertOneAsync(newProduct);

            }
            catch (Exception e)
            {
                throw;
            }
            return true;
        }
    }

}
