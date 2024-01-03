using OTT.Interfaces;
using OTT.Models;
using OTT.Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace OTT.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<string, User> _repository;
        private readonly ITokenService _tokenService;

        public UserService(IRepository<string,User> repository, ITokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;   
        }
        public UserDTO Login(UserDTO userDTO)
        {
            var user = _repository.GetById(userDTO.Email);
            if (user != null)
            {
                HMACSHA512 hmac = new HMACSHA512(user.Key);
                var userpass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                for (int i = 0; i < userpass.Length; i++)
                {
                    if (user.Password[i] != userpass[i])
                        return null;
                }
                userDTO.Role = user.Role;
                userDTO.Password = "";
                userDTO.Email = user.Email;
                return userDTO;
            }
            return null;
        }

        public UserRegisterDTO Register(UserRegisterDTO userDTO)
        {
            HMACSHA512 hmac = new HMACSHA512();
            User user = new User()
            {
                Email = userDTO.Email,
                phoneNumber = userDTO.phoneNumber,
                Name = userDTO.Name,
                Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password)),
                Role = userDTO.Role,
                Key = hmac.Key
            };
            var result = _repository.Add(user);
            if(user != null)
            {
                userDTO.Token = _tokenService.GetToken(userDTO);
                userDTO.Password = "";
                userDTO.RetypePassword = "";
                return userDTO;
            }
            return null;
        }
    }
}
