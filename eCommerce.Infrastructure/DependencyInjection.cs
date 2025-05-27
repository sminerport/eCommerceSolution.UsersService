using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using eCommerce.Infrastructure.Repositories;

using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;
public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add infrastructure services to the IoC container.
    /// </summary>
    /// <param name="services">The service collection to add services to.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IUsersRepository, UsersRepository>();
        services.AddTransient<DapperDbContext>();
        return services;
    }
}