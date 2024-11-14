using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Galaxy.Storage.Models
{
    public class Feedback
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid IsnNode { get; set; }

        [Required, MaxLength(255)]
        public string ClientName { get; set; }


        [Required, MaxLength(255)]
        public string ClientEmail { get; set; }

        [Required]
        public string  feedBackText { get; set; }

        [Required]
        public bool forPublic { get; set; }
    }
}
