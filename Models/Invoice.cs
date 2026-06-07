namespace InvoiceProcessingService.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string InvoiceNumber => $"INV-{Id}-{CreatedAt:yyyyMMdd}";


    }
}
