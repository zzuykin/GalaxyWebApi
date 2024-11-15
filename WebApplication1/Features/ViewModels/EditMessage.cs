
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Features.ViewModels
{
    public class EditMessage
    {
        [Key]
        public Guid IsnNode { get; init; }

        [Required, MaxLength(255)]
        public string ClientName { get; init; }


        [Required, MaxLength(255)]
        public string ClientEmail { get; init; }

        [Required]
        public string feedBackText { get; init; }

        [Required]
        public bool forPublic { get; init; }
    }
}
