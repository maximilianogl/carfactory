using CarFactory.Core.Domain.Entities;
using CarFactory.Infrastructure.Persistence.Interfaces;

namespace CarFactory.Infrastructure.Persistence.Repositories
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        public SaleRepository(IMockRepositoryService mockRepositoryService) : base(mockRepositoryService)
        {
            _entitiesMemory = _mockRepositoryService.Sales;
        }
    }
}
