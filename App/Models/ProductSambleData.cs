namespace App.Models
{
    public class ProductSambleData
    {
        List<Product> products;
        public ProductSambleData()
        {
            products = new List<Product>();
            products.Add(new Product() { Id = 1,Name = "Ahmed",Image = "1.jpg", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s." });
            products.Add(new Product() { Id = 2,Name = "Amr",Image = "2.jpg", Description = "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s." });
            products.Add(new Product() { Id = 3,Name = "Ali",Image = "3.jpg",Description = "Dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s." });
        }
        public List<Product> GetProducts()
        {
            return products;
        }
        public Product GetProduct(int id) {
            var result = products.FirstOrDefault(e => e.Id == id);
            return result;
        }
    }
}
