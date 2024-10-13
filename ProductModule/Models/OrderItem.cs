using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductModule.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        public virtual Order? Order { get; set; }
        [ForeignKey(nameof(Order))]
        public int? OrderId { get; set; }
        public virtual Product? Product { get; set; }
        [ForeignKey(nameof(Product))]
        [Required]
        public int? ProductId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
    }
}
