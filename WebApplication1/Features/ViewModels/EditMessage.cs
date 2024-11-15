
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Features.ViewModels
{
    public class EditMessage
    {
        [Key]
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
