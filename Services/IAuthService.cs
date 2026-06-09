using InvoiceProcessingService.DTOs;

namespace InvoiceProcessingService.Services;
public interface IAuthService
{
    Task<bool> RegisterAsync(RegisterDto dto);

    Task<string?> LoginAsync(LoginDto dto);
}