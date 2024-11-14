
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Galaxy.Storage.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid IsnNode { get; set; }

        [Required, MaxLength(255)]
        public string ClientName { get; set; }

        [Required, MaxLength(255)]
        public string ClientSurname { get; set; }

        [Required, MaxLength(255)]
        public string ClientEmail { get; set; }

        [Required, MaxLength(255)]
        public string ClientPassword { get; set; }

        [InverseProperty(nameof(Order.User))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
