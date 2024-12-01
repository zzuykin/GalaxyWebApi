

using System.ComponentModel.DataAnnotations;

namespace Galaxy.Storage.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid CartId { get; set; }
        public Cart Cart { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; } // Количество продуктов
    }
}
