using InvoiceProcessingService.Models;
using InvoiceProcessingService.Data;
using Microsoft.EntityFrameworkCore;

namespace InvoiceProcessingService.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext _dbcontext;

        public InvoiceRepository(AppDbContext dbcontext) =>
            _dbcontext = dbcontext;

        public async Task<IEnumerable<Invoice>> GetAllAsync() =>
            await _dbcontext.Invoices.ToListAsync();

        public async Task<Invoice?> GetByIdAsync(int id) =>
            await _dbcontext.Invoices.FindAsync(id);

        public async Task<Invoice> AddAsync(Invoice invoice)
        {
            _dbcontext.Invoices.Add(invoice);
            await _dbcontext.SaveChangesAsync();
            return invoice;
        }
    }
}
