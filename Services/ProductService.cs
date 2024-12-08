using DiPatternDemo.Models;
using DiPatternDemo.Repositories;

namespace DiPatternDemo.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository repo;

        public ProductService(IProductRepository repo)
        {
            this.repo = repo;   
        }

        public int AddProduct(Product prod)
        {
            return repo.AddProduct(prod);
        }

        public int DeleteProduct(int id)
        {
            return repo.DeleteProduct(id);
        }

        public Product GetProductById(int id)
        {
           return repo.GetProductById(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return repo.GetProducts();
        }

        public int UpdateProduct(Product prod)
        {
           return repo.UpdateProduct(prod);
        }
    }
}
