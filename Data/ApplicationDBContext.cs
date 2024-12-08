using DiPatternDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace DiPatternDemo.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> op) : base(op) 
        {
        
        }

        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Category>? Categories { get; set; }

        public DbSet<Product>? Products { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
