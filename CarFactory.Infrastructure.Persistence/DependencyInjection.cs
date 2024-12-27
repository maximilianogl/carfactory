using CarFactory.Infrastructure.Persistence.Interfaces;
using CarFactory.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CarFactory.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static void RegisterInfrastructurePersistence(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddSingleton<IMockRepositoryService, MockRepositoryService>();
        }
    }
}
