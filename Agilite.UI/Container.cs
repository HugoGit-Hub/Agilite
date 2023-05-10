using Agilite.UI.Services;
using Agilite.UI.Services.Services;
using Agilite.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Linq;

namespace Agilite.UI;

public class Container
{
    public static IMainWindowViewModel? MainWindowViewModel => ConfigureServices().GetService<IMainWindowViewModel>();

    public static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton<MainWindow>();
        services.AddSingleton<IMainWindowViewModel, MainWindowViewModel>();
        services.AddSingleton<ContactViewModel>();
        services.AddSingleton<DefaultViewModel>();

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