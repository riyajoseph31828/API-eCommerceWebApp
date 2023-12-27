using eCommerce_web_api.Models;
using eCommerce_web_api.Services;
using eCommerce_web_api.Services.Categories;
using eCommerce_web_api.Services.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //all products
        [HttpGet]
        public ActionResult<List<Product>> GetAllProducts()
        {
            var data = _productService.GetProducts();
            return Ok(data);
        }


        //get products by catId
        [HttpGet("category/{catId}")]

        public ActionResult<List<Product>> GetProductsByCatId(int catId)
        {
            var data =_productService.GetProductsByCatId(catId);
            if (data == null)
                return NotFound("no product found with catId: " + catId);
            return Ok(data);
        }

        //get products by id
        [HttpGet("{id}")]

        public ActionResult<Product>GetProductById(int id)
        {
            var data = _productService.GetProductById(id);
            if (data == null)
                return NotFound("no product found with product id: "+id);
            return Ok(data);
        }


        //add product
        [HttpPost("{catId}")]
        public ActionResult<Product> AddProduct(int catId, Product product)
        {
           var data = _productService.AddProduct(catId,product);
            if (data == null)
                return BadRequest();
            return Created("",data);
        }




        //update product
        [HttpPut("{id}")]

        public ActionResult<Product> PutProduct(int id, [FromBody] Product product) 
        {
            var data = _productService.GetProductById(id);
            if (data == null)
                return NotFound("no product found with Id: " + id);
            var response = _productService.UpdateProduct(id, product);
            return Ok(response);
            
        }



        //delete product
        [HttpDelete("{id}")]
        public ActionResult<string> DeleteProduct(int id)
        {
            var data = _productService.GetProductById(id);
            if (data == null)
                return NotFound("no product is found with id: " + id);
            _productService.DeleteProduct(id);
            return Ok("Product Deleted");
        }
    }
}
