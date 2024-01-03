using OTT.Models.DTOs;

namespace OTT.Interfaces
{
    public interface ITokenService
    {
        string GetToken(UserDTO user);
    }
}
