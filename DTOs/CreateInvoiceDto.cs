namespace InvoiceProcessingService.DTOs
{
    public class CreateInvoiceDto
    {
        public string CustomerName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}
