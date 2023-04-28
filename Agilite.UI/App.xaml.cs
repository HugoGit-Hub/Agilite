using Agilite.UI.Data;
using Agilite.UI.Services;
using Agilite.UI.Services.Services;
using Agilite.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Windows;

namespace Agilite.UI;

public partial class App : Application
{
    public App()
    {
        var services = new ServiceCollection();

        services.AddSingleton<MainWindow>();
        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<ContactsViewModel>();
        services.AddSingleton<IContactDataProvider, ContactDataProvider>();

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

        services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
    }
}
