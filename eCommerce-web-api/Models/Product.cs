namespace eCommerce_web_api.Models
{
    public class Product
    {
        public int productId { get; set; }
        public string productTitle { get; set; }

        public int productPrice { get; set; }

        public string productDescription { get; set; }

        public string productImages { get; set; }

       // public int categoryId { get; set; }
        public Category productCategory { get; set; }
    }
}
