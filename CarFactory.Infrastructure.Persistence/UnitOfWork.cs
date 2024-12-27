using CarFactory.Infrastructure.Persistence.Interfaces;
using CarFactory.Infrastructure.Persistence.Repositories;

namespace CarFactory.Infrastructure.Persistence
{
    /// <summary>
    /// Implements the Unit of Work pattern to manage repositories and ensure coordinated data changes.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        public ISaleRepository SalesRepository { get; }
        public ICarRepository CarsRepository { get; }
        public IDistributionCenterRepository DistributionCentersRepository { get; }

        public UnitOfWork(IMockRepositoryService mockRepositoryService)
        {
            SalesRepository = new SaleRepository(mockRepositoryService);
            CarsRepository = new CarRepository(mockRepositoryService);
            DistributionCentersRepository = new DistributionCenterRepository(mockRepositoryService);
        }
        //TODO: Commit data in database
        public Task CommitAsync()
        {
            return Task.CompletedTask;

        }

    }
}
