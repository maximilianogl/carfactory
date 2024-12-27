using CarFactory.Core.Domain.Entities;
using CarFactory.Infrastructure.Persistence.Interfaces;

namespace CarFactory.Infrastructure.Persistence.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(IMockRepositoryService mockRepositoryService) : base(mockRepositoryService)
        {
            _entitiesMemory = _mockRepositoryService.Cars;
        }
    }
}
