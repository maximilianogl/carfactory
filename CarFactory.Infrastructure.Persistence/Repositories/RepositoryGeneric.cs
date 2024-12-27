using CarFactory.Infrastructure.Persistence.Interfaces;

namespace CarFactory.Infrastructure.Persistence.Repositories
{
    /// <summary>
    /// Base class for all repostories with common method
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        protected List<T> _entitiesMemory = new();
        protected readonly IMockRepositoryService _mockRepositoryService;

        public GenericRepository(IMockRepositoryService mockRepositoryService)
        {
            _mockRepositoryService = mockRepositoryService;
        }
        public async Task AddAsync(T entity)
        {
            await Task.Run(() => _entitiesMemory.Add(entity));
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.FromResult(_entitiesMemory.AsEnumerable());
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await Task.Run(() => _entitiesMemory.FirstOrDefault(e => e.GetType().GetProperty("Id")?.GetValue(e).Equals(id) == true));
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
