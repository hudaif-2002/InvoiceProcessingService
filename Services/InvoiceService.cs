using InvoiceProcessingService.DTOs;
using InvoiceProcessingService.Models;
using InvoiceProcessingService.Repositories;
using Microsoft.Extensions.Logging;

namespace InvoiceProcessingService.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ILogger _logger;

        public InvoiceService(IInvoiceRepository invoiceRepository, ILogger logger)
        {
            _invoiceRepository = invoiceRepository;
            _logger = logger;
        }

        public async Task<Invoice> GetById(int id)
        {
            _logger.LogInformation("Fetching invoice with ID {InvoiceId}", id);
            var invoice = await _invoiceRepository.GetByIdAsync(id);
            if (invoice == null)
            {
                _logger.LogWarning("Invoice with ID {InvoiceId} not found", id);
                throw new KeyNotFoundException($"Invoice with ID {id} not found.");
            }
            return invoice;
        }

        public async Task<IEnumerable<Invoice>> GetAllInvoiceAsync()
        {
            _logger.LogInformation("Fetching all invoices");
            return await _invoiceRepository.GetAllAsync();
        }

        public async Task<Invoice> CreateInvoice(CreateInvoiceDto dto)
        {
            if (dto.Amount <= 0)
            {
                _logger.LogWarning("Attempted to create an invoice with invalid amount: {Amount}", dto.Amount);
                throw new ArgumentException("Amount must be greater than zero.");
            }
            _logger.LogInformation("Creating a new invoice for {CustomerName}", dto.CustomerName);
            var invoice = new Invoice
            {
                CustomerName = dto.CustomerName,
                Amount = dto.Amount,
                CreatedAt = DateTime.UtcNow
            };
            await _invoiceRepository.AddAsync(invoice);
            _logger.LogInformation("Invoice created with ID {InvoiceId}", invoice.Id);
            return invoice;
        }
    }
}
