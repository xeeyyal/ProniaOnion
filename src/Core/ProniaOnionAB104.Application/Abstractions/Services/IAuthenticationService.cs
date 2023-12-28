using ProniaOnionAB104.Application.DTOs.Tokens;
using ProniaOnionAB104.Application.DTOs.Users;

namespace ProniaOnionAB104.Application.Abstractions.Services
{
    public interface IAuthenticationService
    {
        Task Register(RegisterDto dto);
        Task<TokenResponseDto> Login(LoginDto dto);
    }
}
