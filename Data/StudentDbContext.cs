using DiPatternDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace DiPatternDemo.Data
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> op):base(op)
        {
            
        }

        public DbSet<Student>? Students { get; set; }
    }
}
