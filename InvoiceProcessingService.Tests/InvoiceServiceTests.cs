using Moq;
using Xunit;
using InvoiceProcessingService.Services;
using InvoiceProcessingService.Repositories;
using InvoiceProcessingService.DTOs;
using InvoiceProcessingService.Models;

namespace InvoiceProcessingService.Tests
{
    public class InvoiceServiceTests
    {
        [Fact]
        public async Task GetById_ShouldReturnInvoice_WhenInvoiceExists()
        {
            // Arrange
            var mockRepository = new Mock<IInvoiceRepository>();
            var invoice = new Invoice { Id = 1, CustomerName = "Test Customer", Amount = 100 };
            mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(invoice);
            var service = new InvoiceService(mockRepository.Object);

            // Act
            var result = await service.GetById(1);

            // Assert
            Assert.Equal(invoice, result);
        }

        [Fact]
        public async Task CreateInvoiceAmountZero_ShouldThrowArgumentException()
        {
            // Arrange
            var mockRepository = new Mock<IInvoiceRepository>();
            var service = new InvoiceService(mockRepository.Object);
            var dto = new CreateInvoiceDto { CustomerName = "Test Customer", Amount = 0 };
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => service.CreateInvoice(dto));
            mockRepository.Verify(repo => repo.AddAsync(It.IsAny<Invoice>()), Times.Never);

        }

        [Fact]
        public async Task CreateInvoiceAmountNegative_ShouldThrowArgumentException()
        {
            // Arrange
            var mockRepository = new Mock<IInvoiceRepository>();
            var service = new InvoiceService(mockRepository.Object);
            var dto = new CreateInvoiceDto { CustomerName = "Test Customer", Amount = -50 };
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => service.CreateInvoice(dto));
            mockRepository.Verify(repo => repo.AddAsync(It.IsAny<Invoice>()), Times.Never);
        }

        [Fact]
        public async Task CreateInvoice_ValidAmount_CallsRepositoryAndReturnsInvoice()
        {
            // Arrange
            var mockRepository = new Mock<IInvoiceRepository>();
            var service = new InvoiceService(mockRepository.Object);
            var dto = new CreateInvoiceDto { CustomerName = "Test Customer", Amount = 100 };
            var createdInvoice = new Invoice { Id = 1, CustomerName = dto.CustomerName, Amount = dto.Amount };
            mockRepository.Setup(repo => repo.AddAsync(It.IsAny<Invoice>())).ReturnsAsync(createdInvoice);
            // Act
            var result = await service.CreateInvoice(dto);
            // Assert
            Assert.Equal(dto.CustomerName, result.CustomerName);
            Assert.Equal(dto.Amount, result.Amount);
            Assert.True(result.CreatedAt > DateTime.MinValue);

            mockRepository.Verify(repo => repo.AddAsync(It.Is<Invoice>(i => i.CustomerName == dto.CustomerName && i.Amount == dto.Amount)), Times.Once);

        }

        [Fact]
        public async Task GetById_InvoiceNotFound_ThrowsKeyNotFoundException()
        {
            // Arrange
            var mockRepository = new Mock<IInvoiceRepository>();
            mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Invoice)null);
            var service = new InvoiceService(mockRepository.Object);
            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => service.GetById(1));
        }

        [Fact]
        public async Task GetById_InvoiceExists_ReturnsInvoice()
        {
            // Arrange
            var mockRepository = new Mock<IInvoiceRepository>();
            var invoice = new Invoice { Id = 1, CustomerName = "Test Customer", Amount = 100 };
            mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(invoice);
            var service = new InvoiceService(mockRepository.Object);
            // Act
            var result = await service.GetById(1);
            // Assert
            Assert.Equal(invoice, result);
        }

        [Fact]
        public async Task GetAllInvoiceAsync_ReturnsAllInvoices()
        {
            // Arrange
            var mockRepository = new Mock<IInvoiceRepository>();
            var invoices = new List<Invoice>
            {
                new Invoice { Id = 1, CustomerName = "Customer 1", Amount = 100 },
                new Invoice { Id = 2, CustomerName = "Customer 2", Amount = 200 }
            };
            mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(invoices);
            var service = new InvoiceService(mockRepository.Object);
            // Act
            var result = await service.GetAllInvoiceAsync();
            // Assert
            Assert.Equal(invoices, result);
        }

    }
}