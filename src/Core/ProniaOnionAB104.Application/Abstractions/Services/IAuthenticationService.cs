using ProniaOnionAB104.Application.DTOs.Users;

namespace ProniaOnionAB104.Application.Abstractions.Services
{
    public interface IAuthenticationService
    {
        Task Register(RegisterDto dto);
        Task<string> Login(LoginDto dto);
    }
}
