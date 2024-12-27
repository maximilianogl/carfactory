using CarFactory.Core.Domain.Entities;

namespace CarFactory.Infrastructure.Persistence.Interfaces
{
    public interface IMockRepositoryService
    {
        List<Car> Cars { get; set; }
        List<DistributionCenter> DistributionCenters { get; set; }
        List<Sale> Sales { get; set; }
    }
}
