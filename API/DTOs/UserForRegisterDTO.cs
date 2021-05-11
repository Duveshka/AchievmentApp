using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class UserForRegisterDTO
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 4, ErrorMessage = "between 4 and 12 symbols")]
        public string Password { get; set; }
    }
}