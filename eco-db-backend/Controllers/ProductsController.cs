using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using eco_db_backend.Constants;
using eco_db_backend.Database;
using eco_db_backend.Services;
using eco_db_backend.Models;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace eco_db_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [Route("{b_type}/{b_value}")]
        public ActionResult<List<Product>> Get(string b_type, string b_value)
        {
            if (b_type == string.Empty)
                return BadRequest();

            if (b_value == string.Empty)
                return BadRequest();

            List<Product> product;
            if (b_type == "all" && b_value == "all")
                product = _productService.Get();
            else
                product = new List<Product>(new Product[]{ _productService.Get(b_type, b_value) });


            if (product == null)
                return NotFound();

            return product;
        }

        // POST: api/Products
        [HttpPost]
        public string Post(ProductRequest req)
        {
            return req.Type;
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
