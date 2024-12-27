namespace CarFactory.Infrastructure.Persistence.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();

        ICarRepository CarsRepository { get; }
        IDistributionCenterRepository DistributionCentersRepository { get; }
        ISaleRepository SalesRepository { get; }
    }
}
