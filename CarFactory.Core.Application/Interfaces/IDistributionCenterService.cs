using CarFactory.Core.Domain.Entities;

namespace CarFactory.Core.Application.Interfaces
{
    public interface IDistributionCenterService
    {
        Task<IEnumerable<DistributionCenter>> GetAllAsync();
    }
}
