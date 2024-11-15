
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Galaxy.Storage.Models
{
    [Index(nameof(ProductName))]
    public class Product
    {
        [Key]
        public int IsnNode { get; set; }

        [Required, MaxLength(50)]
        public string ProductName { get; set; }

        [Required]

        public string ProductDescription { get; set; }

        public string ProductImgUrl { get; set; }

        [Required]

        public string ProductUrl { get; set; }

    }
}
