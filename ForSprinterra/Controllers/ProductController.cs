using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ForSprinterra.Models;
using ForSprinterra.Models.ProductModels;

namespace ForSprinterra.Controllers
{
    public class ProductController : ApiController
    {
        ProductManagement _pm;
        public ProductController()
        {
            _pm = new ProductManagement();
        }

        [HttpGet]
        [Route("api/products")]
        public IEnumerable<Product> GetProducts()
        {
            IEnumerable <Product> products = _pm.GetProducts();
            return products;
        }

        [HttpGet]
        [Route("api/products/find/{keyword}")]
        public IEnumerable<Product> GetProductsByKeyword(string keyword)
        {
            IEnumerable<Product> products = _pm.GetProductsByKeyword(keyword);
            return products;
        }

        [HttpGet]
        [Route("api/products/images/{productId}")]
        public IEnumerable<ProductImage> GetProductImages(int productId)
        {
            IEnumerable<ProductImage> images = _pm.GetProductImages(productId);
            return images;
        }

        [HttpGet]
        [Route("api/products/{id}")]
        public Product GetProductById(int id)
        {
            Product product = _pm.GetProductById(id);
            return product;
        }

        [HttpDelete]
        [Route("api/products/delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid collection id");
            bool deleted = _pm.Delete(id);
            if (deleted)
                return Ok(id);
            else
                return BadRequest("This content collection does not exist");
        }


        [HttpGet]
        [Route("api/token/{clientId}/{token}")]
        public IHttpActionResult Validate(string clientId, string token, string baseUrl)
        {
            if (string.IsNullOrWhiteSpace(clientId) || string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(baseUrl))
                return BadRequest("Please, enter all fields");
            else
            {
                var correct = Token.Validate(clientId, token, baseUrl);
                if (correct) {
                    return Ok();
                }
                else return BadRequest("Please, check correctness of entered fields");
            }
        }
    }
}
