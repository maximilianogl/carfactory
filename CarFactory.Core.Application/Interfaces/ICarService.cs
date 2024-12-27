using CarFactory.Core.Domain.Entities;

namespace CarFactory.Core.Application.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAllAsync();
    }
}
