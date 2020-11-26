using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApp.Data;
using CoreApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            var products = _repository.GetAll();
            if (products != null)
            {
                return Ok(products);
            }

            return BadRequest("Product not found");
        }

        [HttpGet("{id}")]
        public ActionResult <Product> GetById(int id)
        {
            var products = _repository.GetById(id);

            if (products != null)
            {
                return Ok(products);
            }

            return BadRequest("Product not found");
        }

        [HttpPost]
        public ActionResult<Product> Add(Product product)
        {
            var products = _repository.Add(product);
            return Ok("Successfully Added a new Product");
        }

        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            Product product = _repository.GetById(id);

            if (product != null)
            {                
                _repository.Delete(product.Id);
                return Ok("Product Deleted successfully");
            }

            return BadRequest("Product not found");
        }

        [HttpPut]
        public ActionResult< Product > Update(Product productChanges)
        {
            var productItems = _repository.Update(productChanges);

            return Ok("Product: " + productItems.PCode + " successfully updated.");
        }
    }
}
