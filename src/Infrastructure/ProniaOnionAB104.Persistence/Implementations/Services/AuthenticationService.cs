using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProniaOnionAB104.Application.Abstractions.Services;
using ProniaOnionAB104.Application.DTOs.Tokens;
using ProniaOnionAB104.Application.DTOs.Users;
using ProniaOnionAB104.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProniaOnionAB104.Persistence.Implementations.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IMapper _mapper;
        private readonly ITokenHandler _handler;
        private readonly UserManager<AppUser> _userManager;

        public AuthenticationService(IMapper mapper, ITokenHandler handler , UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _handler = handler;
            _userManager = userManager;
        }

        public async Task Register(RegisterDto registerDto)
        {
            AppUser user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == registerDto.UserName || u.Email == registerDto.Email);
            if (user is not null) throw new Exception("User already exist");
            user = _mapper.Map<AppUser>(registerDto);

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                StringBuilder message = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    message.AppendLine(error.Description);
                }
                throw new Exception(message.ToString());
            }
        }
        public async Task<TokenResponseDto> Login(LoginDto dto)
        {
            AppUser user = await _userManager.FindByNameAsync(dto.UserNameOrEmail);
            if (user is null)
            {
                user = await _userManager.FindByEmailAsync(dto.UserNameOrEmail);
                if (user is null) throw new Exception("Username or email,password incorrect");

            }

            if (!await _userManager.CheckPasswordAsync(user, dto.Password)) throw new Exception("Username or email,password incorrect");

            return _handler.CreateJwt(user, 1);
        }
    }
}
