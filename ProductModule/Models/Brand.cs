using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductModule.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        [Required]
        public string BrandName { get; set; }
        public virtual Category ? Category { get; set; }
        [ForeignKey(nameof(Category))]  
        public int? CategoryId { get; set; }
    }
}
