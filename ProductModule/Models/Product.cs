using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductModule.Models
{
    public class Product
    {
        [Key]

        public int ProductId { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is required")]

        public double Price { get; set; }
        public virtual Category Category { get; set; }
        [Required(ErrorMessage = "Category is required")]

        [ForeignKey(nameof(Category))]
        public int? CategoryId { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int StockQuatity { get; set; }
        public Brand Brand { get; set; }
    }
}

