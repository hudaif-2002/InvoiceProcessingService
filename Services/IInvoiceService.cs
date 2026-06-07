using InvoiceProcessingService.DTOs;
using InvoiceProcessingService.Models;

namespace InvoiceProcessingService.Services
{
    public interface IInvoiceService
    {
            Task<Invoice> CreateInvoice(CreateInvoiceDto dto);
            Task<IEnumerable<Invoice>> GetAllInvoiceAsync();
            Task<Invoice> GetById(int id);
    }
}
