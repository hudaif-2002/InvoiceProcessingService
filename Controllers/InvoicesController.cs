using Microsoft.AspNetCore.Mvc;
using InvoiceProcessingService.DTOs;
using InvoiceProcessingService.Services;
using Microsoft.AspNetCore.Authorization;

namespace InvoiceProcessingService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController : Controller
    {
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceService invoiceService) =>
            _invoiceService = invoiceService;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _invoiceService.GetAllInvoiceAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var invoice = await _invoiceService.GetById(id);
            if (invoice != null)
                return Ok(invoice);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInvoiceDto dto)
        {
            try
            {
                var invoice = await _invoiceService.CreateInvoice(dto);
                return CreatedAtAction(nameof(GetById), new { id = invoice.Id }, invoice);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
