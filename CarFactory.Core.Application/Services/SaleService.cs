using CarFactory.Core.Application.DTOs;
using CarFactory.Core.Application.Exceptions;
using CarFactory.Core.Application.Interfaces;
using CarFactory.Core.Domain.Entities;
using CarFactory.Infrastructure.Persistence.Interfaces;

namespace CarFactory.Core.Application.Services
{
    /// <summary>
    ///  Class service for sales operations
    /// </summary>
    public class SaleService : ISaleService
    {
        private readonly IUnitOfWork _uow;

        //TODO: Do CRUDS Operations
        public SaleService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        /// <summary>
        /// Creates a new sale record with the provided details.
        /// </summary>
        /// <param name="createSaleRequest">The sale data to be created.</param>
        /// <returns>The created Sale entity.</returns>
        /// <exception cref="NotFoundException">Thrown if the car or distribution center does not exist.</exception>
        public async Task<Sale> CreateSaleAsync(CreateSaleRequest createSaleRequest)
        {
            var car = await _uow.CarsRepository.GetByIdAsync(createSaleRequest.CarId);
            if (car == null)
            {
                throw new NotFoundException($"The car with ID {createSaleRequest.CarId} does not exist.");
            }

            var distributionCenter = await _uow.DistributionCentersRepository.GetByIdAsync(createSaleRequest.DistributionCenterId);
            if (distributionCenter == null)
            {
                throw new NotFoundException($"The distribution center with ID {createSaleRequest.DistributionCenterId} does not exist.");
            }

            var sale = new Sale
            {
                Id = Guid.NewGuid(),
                CarId = createSaleRequest.CarId,
                Car = car,
                DistributionCenterId = createSaleRequest.DistributionCenterId,
                DistributionCenter = distributionCenter,
                SaleDate = createSaleRequest.SaleDate
            };

            await _uow.SalesRepository.AddAsync(sale);
            await _uow.CommitAsync();

            return sale;
        }

        /// <summary>
        /// Retrieves all sales records.
        /// </summary>
        /// <returns>A collection of all Sale entities.</returns>
        public Task<IEnumerable<Sale>> GetAllAsync()
        {
            return _uow.SalesRepository.GetAllAsync();
        }

        /// <summary>
        /// Calculates the total number of sales and total profit.
        /// </summary>
        /// <returns>A summary of total sales and profit.</returns>
        public async Task<GetTotalSalesResponse> GetTotalSalesAsync()
        {
            var totalSales = await _uow.SalesRepository.GetAllAsync();

            return new GetTotalSalesResponse()
            {
                TotalSales = totalSales.Count(),
                TotalProfit = totalSales.Sum(m => m.TotalPrice)
            };
        }

        /// <summary>
        /// Calculates the total sales and profit for each distribution center.
        /// </summary>
        /// <returns>A collection of sales grouped by distribution center.</returns>
        public async Task<IEnumerable<GetTotalSalesByDistributionCenterResponse>> GetTotalSalesByDistributionCenter()
        {
            var totalSales = await _uow.SalesRepository.GetAllAsync();

            return totalSales
                    .GroupBy(sale => sale.DistributionCenter)
                    .Select(group => new GetTotalSalesByDistributionCenterResponse
                    {
                        DistributionCenterName = group.Key.Name,
                        TotalSales = group.Count(),
                        TotalProfit = group.Sum(sale => sale.TotalPrice)
                    })
                    .ToList();
        }

        /// <summary>
        /// Calculates the percentage of units sold for each car model at each distribution center 
        /// relative to the total company sales.
        /// </summary>
        /// <returns>A collection of sales percentages by model and distribution center.</returns>

        public async Task<IEnumerable<GetTotalSalesDetailPercentageResponse>> GetTotalSalesDetailPercentage()
        {
            List<GetTotalSalesDetailPercentageResponse> result = new List<GetTotalSalesDetailPercentageResponse>();
            var sales = await _uow.SalesRepository.GetAllAsync();
            var totalSales = sales.Count();
            foreach (var distributionCenter in sales.Select(m => m.DistributionCenter).Distinct())
            {
                result.AddRange(sales.Where(m => m.DistributionCenterId == distributionCenter.Id).GroupBy(m => m.Car.CarModel).Select(m =>
                new GetTotalSalesDetailPercentageResponse() { Percentage = (int)((double)m.Count() / totalSales * 100), CarModel = m.Key, DistributionCenterName = distributionCenter.Name })
                );
            }

            return result;
        }
    }
}
