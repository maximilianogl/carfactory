using CarFactory.Core.Application.DTOs;
using CarFactory.Core.Application.Exceptions;
using CarFactory.Core.Application.Services;
using CarFactory.Core.Domain.Entities;
using CarFactory.Core.Domain.Enums;
using CarFactory.Infrastructure.Persistence.Interfaces;
using Moq;
using System;
using System.Xml.Linq;
using Xunit;

namespace CarFactory.UnitTest
{
    public class SaleServiceTest
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly SaleService _saleService;
        private readonly List<Car> CarsMock = new List<Car>()
            {
                new Car()
        {
            Id = new Guid("07DB0B4C-3BD8-48A3-821B-B98F849DF2FE"),
                    BasePrice = 8000,
                    CarModelId = (int)Core.Domain.Enums.CarModel.Sedan
                },
                new Car()
        {
            Id = new Guid("6B41AE07-6F66-43EE-9084-21E78AECFCB7"),
                    BasePrice = 9500,
                    CarModelId = (int)Core.Domain.Enums.CarModel.Suv
                },
                new Car()
        {
            Id = new Guid("9B15CB4E-A177-4888-AC6E-819F08BE7422"),
                    BasePrice = 12500,
                    CarModelId = (int)Core.Domain.Enums.CarModel.OffRoad
                },
                new Car()
        {
            Id = new Guid("7BC1300E-F7C3-4399-AA9F-F841D648C92C"),
                    BasePrice = 18200,
                    CarModelId = (int)Core.Domain.Enums.CarModel.Sport
                },
            };

        private readonly List<DistributionCenter> DistributionCentersMock = new List<DistributionCenter>()
            {
                new DistributionCenter()
                {
                    Id = new Guid("74F1A75F-D521-4B43-96C3-C07572025C3E"),
                                Location = "Buenos Aires",
                                Name = "Casa central"
                            },
                            new DistributionCenter()
                {
                    Id = new Guid("0465B6CD-9D37-4639-B44D-BC94F5E79DDE"),
                                Location = "Rosario, Santa Fe",
                                Name = "Santa Fe"
                            },
                            new DistributionCenter()
                {
                    Id = new Guid("7BAE3BDD-63EB-4E8B-B507-3ED41DDB4F02"),
                                Location = "San Rafael, Mendoza",
                                Name = "Mendoza"
                            },
                            new DistributionCenter()
                {
                    Id = new Guid("BE38B77F-1A49-4E2E-B2A6-6BAF9EC63FB9"),
                                Location = "Iguazu, Misiones",
                                Name = "Misiones"
                            }

            };

        public SaleServiceTest()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _saleService = new SaleService(_mockUnitOfWork.Object);
        }
        /// <summary>
        /// Test for calculate total sales and profit
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetTotalSalesAsync_ShouldReturnCorrectTotalSalesAndProfit()
        {
            List<Sale> mockSales = GetMockSales();

            _mockUnitOfWork.Setup(uow => uow.SalesRepository.GetAllAsync())
                .ReturnsAsync(mockSales);

            var result = await _saleService.GetTotalSalesAsync();

            Assert.NotNull(result);
            Assert.Equal(3, result.TotalSales);
            Assert.Equal(36974, result.TotalProfit);
        }
        /// <summary>
        /// Generate a mock for sales
        /// </summary>
        /// <returns></returns>
        private List<Sale> GetMockSales()
        {
            var mockSales = new List<Sale>
        {
            new Sale {
                Id = Guid.NewGuid(),
                    DistributionCenterId = DistributionCentersMock[0].Id,
                    DistributionCenter = DistributionCentersMock[0],
                    CarId = CarsMock[0].Id,
                Car = CarsMock[0],
                    SaleDate = DateTime.UtcNow.AddDays(-1),
            },

               new Sale {
                Id = Guid.NewGuid(),
                    DistributionCenterId = DistributionCentersMock[0].Id,
                    DistributionCenter = DistributionCentersMock[0],
                    CarId = CarsMock[1].Id,
                Car = CarsMock[1],
                    SaleDate = DateTime.UtcNow.AddDays(-1),
            },
                  new Sale {
                Id = Guid.NewGuid(),
                    DistributionCenterId = DistributionCentersMock[2].Id,
                    DistributionCenter = DistributionCentersMock[2],
                    CarId = CarsMock[3].Id,
                Car = CarsMock[3],//Model sport
                    SaleDate = DateTime.UtcNow.AddDays(-1),
            }
        };
            return mockSales;
        }
        /// <summary>
        /// Test for calculate sales by distribution center
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetTotalSalesByDistributionCenter_ShouldGroupSalesByDistributionCenter()
        {
            List<Sale> mockSales = GetMockSales();
            _mockUnitOfWork.Setup(uow => uow.SalesRepository.GetAllAsync())
                .ReturnsAsync(mockSales);

            var result = await _saleService.GetTotalSalesByDistributionCenter();

            Assert.NotNull(result);
            var resultList = result.ToList();
            Assert.Equal(2, resultList.Count);

            var center1 = resultList.First(r => r.DistributionCenterName == "Casa central");
            Assert.Equal(2, center1.TotalSales);
            Assert.Equal(17500, center1.TotalProfit);

            var center2 = resultList.First(r => r.DistributionCenterName == "Mendoza");
            Assert.Equal(1, center2.TotalSales);
            Assert.Equal(19474, center2.TotalProfit);
        }
        /// <summary>
        /// Test for calculate percentages based in Car type and distribution center
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetTotalSalesDetailPercentage_ShouldCalculateCorrectPercentages()
        {
            List<Sale> mockSales = GetMockSales();

            _mockUnitOfWork.Setup(uow => uow.SalesRepository.GetAllAsync())
                .ReturnsAsync(mockSales);

            var result = await _saleService.GetTotalSalesDetailPercentage();

            Assert.NotNull(result);
            var resultList = result.ToList();
            Assert.Equal(3, resultList.Count);

            var center1ModelA = resultList.First(r => r.DistributionCenterName == "Casa central" && r.CarModel == CarModel.Sedan);
            Assert.Equal(33, center1ModelA.Percentage);

            var center1ModelB = resultList.First(r => r.DistributionCenterName == "Mendoza" && r.CarModel == CarModel.Sport);
            Assert.Equal(33, center1ModelB.Percentage);

        }
        /// <summary>
        /// Test for validate sucesslly sale creation
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateSaleAsync_ValidRequest_ReturnsSale()
        {
            var saleDate = DateTime.UtcNow;
                        
            _mockUnitOfWork.Setup(u => u.CarsRepository.GetByIdAsync(CarsMock[0].Id)).ReturnsAsync(CarsMock[0]);
            _mockUnitOfWork.Setup(u => u.DistributionCentersRepository.GetByIdAsync(DistributionCentersMock[0].Id)).ReturnsAsync(DistributionCentersMock[0]);
            _mockUnitOfWork.Setup(u => u.SalesRepository.AddAsync(It.IsAny<Sale>())).Returns(Task.CompletedTask);
            _mockUnitOfWork.Setup(u => u.CommitAsync()).Returns(Task.CompletedTask);

            var createSaleRequest = new CreateSaleRequest
            {
                CarId = CarsMock[0].Id,
                DistributionCenterId = DistributionCentersMock[0].Id,
                SaleDate = saleDate
            };

            var result = await _saleService.CreateSaleAsync(createSaleRequest);

            Assert.NotNull(result);
            // Valid created object had the same properties request
            Assert.Equal(CarsMock[0].Id, result.CarId);
            Assert.Equal(DistributionCentersMock[0].Id, result.DistributionCenterId);
            Assert.Equal(saleDate, result.SaleDate);

        }
        /// <summary>
        /// Test for validation of car id invalid
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateSaleAsync_CarNotFound_ThrowsNotFoundException()
        {
            // Random Car
            var carId = Guid.NewGuid();
            
            _mockUnitOfWork.Setup(u => u.CarsRepository.GetByIdAsync(carId)).ReturnsAsync((Car)null);

            var createSaleRequest = new CreateSaleRequest
            {
                CarId = carId,
                DistributionCenterId = DistributionCentersMock[0].Id,
                SaleDate = DateTime.UtcNow
            };

            var exception = await Assert.ThrowsAsync<NotFoundException>(() => _saleService.CreateSaleAsync(createSaleRequest));
            Assert.Equal($"The car with ID {carId} does not exist.", exception.Message);
        }
        /// <summary>
        /// Test for validation of distribution center
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateSaleAsync_DistributionCenterNotFound_ThrowsNotFoundException()
        {
            // Random distribution center
            var distributionCenterId = Guid.NewGuid();

            
            _mockUnitOfWork.Setup(u => u.CarsRepository.GetByIdAsync(CarsMock[0].Id)).ReturnsAsync(CarsMock[0]);
            _mockUnitOfWork.Setup(u => u.DistributionCentersRepository.GetByIdAsync(distributionCenterId)).ReturnsAsync((DistributionCenter)null);

            var createSaleRequest = new CreateSaleRequest
            {
                CarId = CarsMock[0].Id,
                DistributionCenterId = distributionCenterId,
                SaleDate = DateTime.UtcNow
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() => _saleService.CreateSaleAsync(createSaleRequest));
            Assert.Equal($"The distribution center with ID {distributionCenterId} does not exist.", exception.Message);
        }
    }
}