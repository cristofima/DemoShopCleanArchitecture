using System.ComponentModel.DataAnnotations;

namespace Shop.Core.DTO.Requests
{
    public class RegisterUserRequest
    {
        [Required]
        [EmailAddress]
        [StringLength(50, MinimumLength = 10)]
        public string Email { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 5)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}