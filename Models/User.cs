using System.ComponentModel.DataAnnotations;

namespace DiPatternDemo.Models
{
    [table("Users")]
    public class User
    {
        //[Required]
        public string? Name { get; set; }

        //[Required]
        //public int Age {  get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string? EmailId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public int Password {  get; set; }

    }
}
