using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class UserForLoginDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}