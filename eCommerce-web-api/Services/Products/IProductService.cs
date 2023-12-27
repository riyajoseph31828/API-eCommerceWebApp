using eCommerce_web_api.Models;

namespace eCommerce_web_api.Services.Products
{
    public interface IProductService
    {
        List<Product> GetProducts();
        List<Product> GetProductsByCatId(int catId);
        Product GetProductById(int id);
        Product AddProduct(int catId, Product product);
        Product UpdateProduct(int id, Product product);
        void DeleteProduct(int id);
    }
}
