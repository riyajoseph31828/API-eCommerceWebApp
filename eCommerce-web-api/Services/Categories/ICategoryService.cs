using eCommerce_web_api.Models;

namespace eCommerce_web_api.Services.Categories
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        Category GetCategoryById(int id);
        Category AddCategory(Category category);
        Category UpdateCategory(int id ,Category category);
        void DeleteCategory(int id);
    }
}
