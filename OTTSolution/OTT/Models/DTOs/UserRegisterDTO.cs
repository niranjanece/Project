using System.ComponentModel.DataAnnotations;

namespace OTT.Models.DTOs
{
    public class UserRegisterDTO : UserDTO
    {
        [Compare("Password", ErrorMessage = "Password and retype password do not match")]
        public string RetypePassword { get; set; }

        public string phoneNumber { get; set; }

        public string Name { get; set; }
    }
}
