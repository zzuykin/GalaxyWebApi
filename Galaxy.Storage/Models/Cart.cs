
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Galaxy.Storage.Models
{
    public class Cart
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid IsnNode { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public ICollection<CartItem> CartItems { get; set; } // Связь с CartItem
    }
}
