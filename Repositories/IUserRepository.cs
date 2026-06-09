using InvoiceProcessingService.Models;

namespace InvoiceProcessingService.Repositories
{
    public interface IUserRepository
    {
            Task<Users?> GetUserByUsernameAsync(string username);
            Task AddUserAsync(Users user);
    }
}
