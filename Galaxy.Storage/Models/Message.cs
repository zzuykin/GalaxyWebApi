
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Galaxy.Storage.Models
{
    public class Message
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid IsnNode { get; set; }

        [Required, MaxLength(255)]
        public string ClientName { get; set; }


        [Required, MaxLength(255)]
        public string ClientEmail { get; set; }

        [Required, MaxLength(50)]
        public string MessageSubj { get; set; }

        [Required]
        public string MessageText { get; set; }

    }
}
