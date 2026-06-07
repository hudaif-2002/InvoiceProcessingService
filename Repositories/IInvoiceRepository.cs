using InvoiceProcessingService.Models;

namespace InvoiceProcessingService.Repositories
{
    public interface IInvoiceRepository
    {
        Task<Invoice> AddAsync(Invoice invoice);
        Task<IEnumerable<Invoice>> GetAllAsync();
        Task<Invoice> GetByIdAsync(int id);
    }
}
