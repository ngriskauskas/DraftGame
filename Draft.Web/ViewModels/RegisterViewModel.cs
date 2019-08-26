using System.ComponentModel.DataAnnotations;

namespace Draft.Web.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public int TeamId { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}