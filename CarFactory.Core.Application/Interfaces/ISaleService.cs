using CarFactory.Core.Application.DTOs;
using CarFactory.Core.Domain.Entities;

namespace CarFactory.Core.Application.Interfaces
{
    public interface ISaleService
    {
        Task<IEnumerable<GetTotalSalesDetailPercentageResponse>> GetTotalSalesDetailPercentage();
        Task<IEnumerable<GetTotalSalesByDistributionCenterResponse>> GetTotalSalesByDistributionCenter();
        Task<GetTotalSalesResponse> GetTotalSalesAsync();
        Task<IEnumerable<Sale>> GetAllAsync();
        Task<Sale> CreateSaleAsync(CreateSaleRequest createSaleRequest);
    }
}
