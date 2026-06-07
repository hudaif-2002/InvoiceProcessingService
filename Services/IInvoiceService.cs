using InvoiceProcessingService.DTOs;
using InvoiceProcessingService.Models;

namespace InvoiceProcessingService.Services
{
    public interface IInvoiceService
    {
            Task<Invoice> CreateInvoice(CreateInvoiceDto dto);
            Task<List<Invoice>> GetAllInvoiceAsync();
            Task<Invoice> GetById(int id);
    }
}
