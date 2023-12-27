using eCommerce_web_api.Database;
using eCommerce_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce_web_api.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly DatabaseContext _context;
        public ProductService(DatabaseContext context) 
        {
            _context = context;
        }

        public Product AddProduct(int catId, Product product)
        {
            //find the category by catId
            Category category = _context.Categories.FirstOrDefault(cat=>cat.CategoryId == catId);
            //set category for the product
            product.productCategory = category;
            //add new product
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;

           // Product data = product;
           // data.productCategory = _context.Categories.FirstOrDefault(x => x.CategoryId == product.categoryId);
           //_context.Products.Add(data);
           // _context.SaveChanges();
           // return product;
        }

        public void DeleteProduct(int id)
        {
            Product product = GetProductById(id);
            _context.Products.Remove(product);
            _context.SaveChanges();

        }

        public Product GetProductById(int id)
        {
            return _context.Products.Where(x=>x.productId ==id).Include(x=>x.productCategory).FirstOrDefault();
        }


        public List<Product> GetProducts()
        {
            //include is used to create a join statement to fetch data from category table based on common col
           return _context.Products.Include(c=>c.productCategory).ToList();   //include will create a join in the database which will give the category details along with catid in the productd
        }

        public List<Product> GetProductsByCatId(int catId)
        {
            return _context.Products.Where(x=>x.productCategory.CategoryId == catId).Include(x=>x.productCategory).ToList();
        }

        public Product UpdateProduct(int id, Product product)
        {
            var productSaved = GetProductById(id);

            productSaved.productTitle = product.productTitle;
            productSaved.productPrice = product.productPrice;
            productSaved.productDescription = product.productDescription;
            productSaved.productImages = product.productImages;

            productSaved.productCategory = _context.Categories.FirstOrDefault(x => x.CategoryId == productSaved.productCategory.CategoryId);


            _context.SaveChanges();


            return productSaved;
          }
    }
}
