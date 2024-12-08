using DiPatternDemo.Models;

namespace DiPatternDemo.Repositories
{
    public interface IProductRepository
    {

        IEnumerable<Product> GetProducts();

        Product GetProductById(int id);

        int AddProduct(Product prod);    

        int UpdateProduct(Product prod); 

        int DeleteProduct(int id);
    }
}
