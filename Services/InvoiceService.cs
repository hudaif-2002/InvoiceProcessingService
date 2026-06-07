using InvoiceProcessingService.DTOs;
using InvoiceProcessingService.Models;
using InvoiceProcessingService.Repositories;
using Serilog;

namespace InvoiceProcessingService.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly Serilog.ILogger _logger;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
            _logger = Log.ForContext<InvoiceService>();
        }

        public async Task<Invoice> GetById(int id)
        {
            _logger.Information("Fetching invoice with ID {InvoiceId}", id);
            var invoice = await _invoiceRepository.GetByIdAsync(id);
            if (invoice == null)
            {
                _logger.Warning("Invoice with ID {InvoiceId} not found", id);
                throw new KeyNotFoundException($"Invoice with ID {id} not found.");
            }
            return invoice;
        }

        public async Task<IEnumerable<Invoice>> GetAllInvoiceAsync()
        {
            _logger.Information("Fetching all invoices");
            return await _invoiceRepository.GetAllAsync();
        }

        public async Task<Invoice> CreateInvoice(CreateInvoiceDto dto)
        {
            if (dto.Amount <= 0)
            {
                _logger.Warning("Attempted to create an invoice with invalid amount: {Amount}", dto.Amount);
                throw new ArgumentException("Amount must be greater than zero.");
            }
            _logger.Information("Creating a new invoice for {CustomerName}", dto.CustomerName);
            var invoice = new Invoice
            {
                CustomerName = dto.CustomerName,
                Amount = dto.Amount,
                CreatedAt = DateTime.UtcNow
            };
            await _invoiceRepository.AddAsync(invoice);
            _logger.Information("Invoice created with ID {InvoiceId}", invoice.Id);
            return invoice;
        }
    }
}