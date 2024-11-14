
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Features.ViewModels
{
    public sealed record EditUser
    {
        [Key]
        public Guid IsnNode { get; init; }

        [Required, MaxLength(255)]
        public string ClientName { get; init; }

        [Required, MaxLength(255)]
        public string ClientSurname { get; init; }

        [Required, MaxLength(255)]
        public string ClientEmail { get; init; }

        [Required, MaxLength(255)]
        public string ClientPassword { get; init; }
    }
}
