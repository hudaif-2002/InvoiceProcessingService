using InvoiceProcessingService.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceProcessingService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
