using Stockmain.Data.Entities;
using Stockmain.Models;
using Stockmain.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Stockmain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCorsImplementationPolicy")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        [HttpGet]
        public IActionResult Get()
        {
            var employeeEntities = (_productRepository.GetProducts());
            return Ok(employeeEntities.Select( e => Product.EntitytoModel(e)));
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int  id)
        {
            if (!_productRepository.ProductExists(id))
            {
                return NotFound();
            }
            var product = Product.EntitytoModel(_productRepository.GetProduct(id));
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int  id)
        {
            if (!_productRepository.ProductExists(id))
            {
                return NotFound();
            }
            var succes = _productRepository.DeleteProduct(id);
            return Ok(succes);
        }

        [HttpPost]
        public IActionResult RegisterProduct([FromBody] Productostock newProduct)
        {
            var product = (_productRepository.EnterProduct(Product.ModeltoEntity(newProduct)));
            return Ok(product);
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] Productostock modifiedProduct)
        {
            var product = (_productRepository.UpdateProduct(Product.ModeltoEntityId(modifiedProduct)));
            return Ok(product);
        }
    }
}
