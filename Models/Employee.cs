using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiPatternDemo.Models
{

    [Table("employee")]
    public class Employee
    {

        [Key]
        public int EmpId {  get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public decimal Salary { get; set; }
    }
}
