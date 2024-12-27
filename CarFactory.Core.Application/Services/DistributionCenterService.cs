using CarFactory.Core.Application.Interfaces;
using CarFactory.Core.Domain.Entities;
using CarFactory.Infrastructure.Persistence.Interfaces;

namespace CarFactory.Core.Application.Services
{
    /// <summary>
    /// Class service for Distribution center operations
    /// </summary>
    public class DistributionCenterService : IDistributionCenterService
    {
        private readonly IUnitOfWork _uow;

        public DistributionCenterService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //TODO: Do CRUDS Operations
        public Task<IEnumerable<DistributionCenter>> GetAllAsync()
        {
            return _uow.DistributionCentersRepository.GetAllAsync();
        }
    }
}
