using Microsoft.Extensions.DependencyInjection;
using ProjectBackend.Contracts.RepositoryInterfaces;
using ProjectBackend.Data.Entities;
using ProjectBackend.Data.Repositories;

namespace ProjectBackend.Data
{
    public static class DataServiceRegistration
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<IEmitterRepository<Emitter>, EmitterRepository>();
            return services;
        }
    }
}
