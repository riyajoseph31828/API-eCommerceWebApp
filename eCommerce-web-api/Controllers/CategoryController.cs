using eCommerce_web_api.Models;
using eCommerce_web_api.Services.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //all categories
        [HttpGet]
        public ActionResult<List<Category>> GetAllCategories()
        {
            var data = _categoryService.GetCategories();
            return Ok(data);
        }

        //get categories by id
        [HttpGet("{id}")]
        public ActionResult<Category> GetCategoryById(int id)
        {
            var data = _categoryService.GetCategoryById(id);
            if (data == null)
                return NotFound("not category found with Id: " + id);
            return Ok(data);
        }

        //add category
        [HttpPost]
        public ActionResult<Category> PostCategory([FromBody] Category category)
        {
            var data = _categoryService.AddCategory(category);
            if (data == null)
                return BadRequest();
            return Created("", data);

        }

        //update category
        [HttpPut("{id}")]
        public ActionResult<Category> PutCategory(int id, [FromBody] Category category)
        {
            var data = _categoryService.GetCategoryById(id);
            if (data == null)
                return NotFound("no category found with Id: " + id);
            var response = _categoryService.UpdateCategory(id, category);
            return Ok(response);
        }

        //delete category
        [HttpDelete("{id}")]
        public ActionResult<string> DeleteCategory(int id)
        {
            var data = _categoryService.GetCategoryById(id);
            if (data == null)
                return NotFound("no category found with Id: " + id);
            _categoryService.DeleteCategory(id);
            return Ok("category deleted");
        }

    
    }
}
