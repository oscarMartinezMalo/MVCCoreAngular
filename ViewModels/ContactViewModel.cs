using System.ComponentModel.DataAnnotations;

namespace MVCCoreAngular.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MinLength(5)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        [MaxLength(255, ErrorMessage = "Too Long")]
        public string Message { get; set; }
    }
}
