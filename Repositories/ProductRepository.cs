using DiPatternDemo.Data;
using DiPatternDemo.Models;

namespace DiPatternDemo.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly ApplicationDBContext db;

        public ProductRepository(ApplicationDBContext db)
        {
            this.db = db;   
        }

        public int AddProduct(Product prod)
        {
            int result = 0;
            db.Products.Add(prod);
            result=db.SaveChanges();
            return result;
        }

        public int DeleteProduct(int id)
        {
            int result = 0;
            var p = db.Products.Where(x=>x.ProductId==id).FirstOrDefault();
            if (p != null)
            {
                db.Products?.Remove(p);
                result = db.SaveChanges();
            }
            return result;
        }

        public Product GetProductById(int id)
        {
            // return db.Products?.Where(x => x.ProductId == id).SingleOrDefault();
            var res = (from p in db.Products
                       join c in db.Categories on p.CategoryId equals c.CategoryId
                       where p.ProductId == id
                       select new Product
                       {
                           ProductId = p.ProductId,
                           ProductName = p.ProductName,
                           Price = p.Price,
                           CategoryId = p.CategoryId,
                           CategoryName = p.CategoryName,
                           ImageURL=p.ImageURL
                       }).FirstOrDefault();
            return res;
        }

        public IEnumerable<Product> GetProducts()
        {
            var result = (from p in db.Products
                         join c in db.Categories on p.CategoryId equals c.CategoryId
                         select new Product
                         {
                             ProductId = p.ProductId,
                             ProductName = p.ProductName,
                             Price = p.Price,
                             CategoryId = c.CategoryId,
                             CategoryName = c.CategoryName,
                             ImageURL = p.ImageURL,
                         }).ToList();
            return result;
        }

        public int UpdateProduct(Product prod)
        {

            int result = 0;
            var p = db.Products?.Where(x => x.ProductId == prod.ProductId).SingleOrDefault();
            if (p != null)
            {
                //db.Entry(prod).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                //or both methods can be used
                p.ProductName = prod.ProductName;
                p.Price = prod.Price;
                p.CategoryId = prod.CategoryId;
                p.ImageURL = prod.ImageURL;
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
