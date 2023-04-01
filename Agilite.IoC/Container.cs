using Agilite.UI.Services;
using Agilite.UI.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Agilite.UI.IoC;

internal static class Container
{
    public static void ConfigureService(IServiceCollection services)
    {
        services
            .AddRefitClient<IContactService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(EndPointConstantes.API_ADDRESS));

        services
            .AddRefitClient<IMessageService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(EndPointConstantes.API_ADDRESS));

        services
            .AddRefitClient<IObjectiveService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(EndPointConstantes.API_ADDRESS));

        services
            .AddRefitClient<IPlanningService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(EndPointConstantes.API_ADDRESS));

        services
            .AddRefitClient<IProjectService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(EndPointConstantes.API_ADDRESS));

        services
            .AddRefitClient<ISprintService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(EndPointConstantes.API_ADDRESS));

        services
            .AddRefitClient<ITaskService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(EndPointConstantes.API_ADDRESS));

        services
            .AddRefitClient<ITeamRoleService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(EndPointConstantes.API_ADDRESS));

        services
            .AddRefitClient<ITeamService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(EndPointConstantes.API_ADDRESS));

        services
            .AddRefitClient<IUserMessageContactService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(EndPointConstantes.API_ADDRESS));

        services
            .AddRefitClient<IUserService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(EndPointConstantes.API_ADDRESS));

        services
            .AddRefitClient<IUserTeamTeamRoleService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(EndPointConstantes.API_ADDRESS));
    }
}