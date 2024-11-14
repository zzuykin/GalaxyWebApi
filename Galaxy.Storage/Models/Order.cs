﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Galaxy.Storage.Models
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid IsnNode { get; set; }

        [ForeignKey(nameof(User))]
        public Guid IsnUser { get; set; }


        [Required, MaxLength(255)]
        public string ProductName { get; set; }

        public virtual User User { get; set; }
    }
}