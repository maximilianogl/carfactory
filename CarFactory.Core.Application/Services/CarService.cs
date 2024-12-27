using CarFactory.Core.Application.Interfaces;
using CarFactory.Core.Domain.Entities;
using CarFactory.Infrastructure.Persistence.Interfaces;

namespace CarFactory.Core.Application.Services
{
    /// <summary>
    /// Class service for Car operations
    /// </summary>
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _uow;

        public CarService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //TODO: Do CRUDS Operations
        public Task<IEnumerable<Car>> GetAllAsync()
        {
            return _uow.CarsRepository.GetAllAsync();
        }
    }
}
