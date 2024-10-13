using System.ComponentModel.DataAnnotations;

namespace ProductModule.Models
{
    public class Category
    {
        [Key]

        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Enter the name")]
        public string CategoryName { get; set; }
    }
}
