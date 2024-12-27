using CarFactory.Core.Domain.Entities;
using CarFactory.Infrastructure.Persistence.Interfaces;

namespace CarFactory.Infrastructure.Persistence.Repositories
{
    public class DistributionCenterRepository : GenericRepository<DistributionCenter>, IDistributionCenterRepository
    {
        public DistributionCenterRepository(IMockRepositoryService mockRepositoryService) : base(mockRepositoryService)
        {
            _entitiesMemory = _mockRepositoryService.DistributionCenters;
        }
    }
}
