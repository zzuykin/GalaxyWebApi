
using System.ComponentModel.DataAnnotations;
namespace Galaxy.Storage.Models
{
    public class Router
    {
        [Key]
        public int IsnNode { get; set; }

        [Required, MaxLength(50)]
        public string PageName { get; set; }

        [Required, MaxLength(50)]
        public string ControllerName { get; set; }

        [Required, MaxLength(50)]
        public string ActionName { get; set; }

        [Required, MaxLength(50)]
        public string Route { get; set; }
    }
}
