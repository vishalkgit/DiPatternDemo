using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiPatternDemo.Models
{
    [Table("student")]
    public class Student
    {
        [Key]
        public int RollNo { get; set; }

        public string? Name { get; set; }

        public string? Branch { get; set; }

        public int Percentage { get; set; }
    }
}
