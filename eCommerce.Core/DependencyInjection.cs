using eCommerce.Core.Domain.IdentityEntities;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using eCommerce.Core.Validators;

using FluentValidation;

using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;
public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add core services to the IoC container.
    /// </summary>
    /// <param name="services">The service collection to add services to.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddTransient<IUsersService, UsersService>();
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

        return services;
    }
}