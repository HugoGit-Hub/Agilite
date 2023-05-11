using Agilite.UI.Mapper.Configuration;
using Agilite.UI.Services;
using Agilite.UI.Services.Services.Refit;
using Agilite.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Linq;
using Agilite.UI.Services.Services;

namespace Agilite.UI;

public class Container
{
    public static IMainWindowViewModel? MainWindowViewModel => ConfigureServices().GetService<IMainWindowViewModel>();

    public static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.ConfigureMappers();

        services.AddSingleton<MainWindow>();
        services.AddSingleton<IMainWindowViewModel, MainWindowViewModel>();
        services.AddSingleton<ContactViewModel>();
        services.AddSingleton<DefaultViewModel>();
        services.AddSingleton<ContactService>();

        foreach (var type in 
                typeof(IBaseRefitClient).Assembly
                    .GetTypes()
                    .Where(type => type.GetInterfaces().Contains(typeof(IBaseRefitClient))))
        {
            services.AddRefitClient(type)
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(EndPointConstantes.API_ADDRESS));
        }

        return services.BuildServiceProvider();
    }
}