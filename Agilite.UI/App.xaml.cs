using Agilite.UI.Services;
using Agilite.UI.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;
using System;
using System.Windows;

namespace Agilite.UI
{
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<MainWindow>();

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
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
            startupForm.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e);
        }
    }
}
