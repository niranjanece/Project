using System.ComponentModel.DataAnnotations;

namespace OTT.Models.DTOs
{
    public class UserDTO
    {
        public string Email { get; set; }

        public string? Role { get; set; }
        public string Password { get; set; }
        public string? Token { get; set; }

        
    }
}
