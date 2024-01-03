using System.ComponentModel.DataAnnotations;

namespace OTT.Models
{
    public class User
    {
        [Key]
        public string Email { get; set; }
        public string phoneNumber { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }
        public byte[] Password { get; set; }

        public byte[] Key { get; set; }
    }
}
