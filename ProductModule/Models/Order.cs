using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductModule.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public virtual User User { get; set; }
        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public double TotalPrice { get; set; }
        [Required]
        public string OrderStatus { get; set; }
    }
}
