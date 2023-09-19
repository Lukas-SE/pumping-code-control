using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PumpingControl.Application.Common;
using PumpingControl.Data.Core;
using PumpingControl.Data.Repositories;

namespace PumpingControl.Infrastructure;

public static class DependencyInjection
{
    public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationContext>(options =>
            options.UseInMemoryDatabase("Test"));
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services
            .AddScoped(typeof(INationRepository), typeof(NationRepository))
            .AddScoped(typeof(IPlayerRepository), typeof(PlayerRepository));
    }

    public static void AddMediatorAndHandlers(this IServiceCollection services)
    {
        services
            .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()))
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }

    public static void AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(ApplicationEntrypoint).Assembly);
    }
}