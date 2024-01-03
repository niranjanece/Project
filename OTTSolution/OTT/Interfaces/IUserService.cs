using OTT.Models.DTOs;

namespace OTT.Interfaces
{
    public interface IUserService
    {
        public UserRegisterDTO Register(UserRegisterDTO userDTO);

        public UserDTO Login(UserDTO userDTO);
    }
}
