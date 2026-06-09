using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using InvoiceProcessingService.DTOs;
using InvoiceProcessingService.Models;
using InvoiceProcessingService.Repositories;

namespace InvoiceProcessingService.Services;
public class  AuthService :IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly IUserRepository _userRepository;

    public AuthService(IConfiguration configuration, IUserRepository userRepository)
    {
        _configuration = configuration;
        _userRepository = userRepository;
    }


    public async Task<bool> RegisterAsync(RegisterDto dto)
    {
        var existingUser = await _userRepository.GetUserByUsernameAsync(dto.Username);
        if (existingUser != null)
        {
            return false; // User already exists
        }

        // In a real application, you would hash the password and store it securely
        var user = new Users
        {
            Username = dto.Username,
            Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
        };
        await _userRepository.AddUserAsync(user);
        return true;
    }

        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var user = await _userRepository.GetUserByUsernameAsync(dto.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                return null; // Invalid username or password
            }
    
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username)
            };
    
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: creds
                );
    
            return new JwtSecurityTokenHandler().WriteToken(token);
    }
}