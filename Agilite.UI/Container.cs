using Agilite.UI.Mapper;
using Agilite.UI.Mapper.Configuration;
using Agilite.UI.Models.Models;
using Agilite.UI.Services;
using Agilite.UI.Services.Services;
using Agilite.UI.Services.Services.Refit;
using Agilite.UI.ViewModels;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Linq;

namespace Agilite.UI;

public class Container
{
    public static IMainWindowViewModel? MainWindowViewModel => ConfigureServices().GetService<IMainWindowViewModel>();

    public static ILoginViewModel? LoginViewModel => ConfigureServices().GetService<ILoginViewModel>();

    public static IDefaultViewModel? DefaultViewModel => ConfigureServices().GetService<IDefaultViewModel>();

    public static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.ConfigureMappers();
        services.AddMediatR(AssemblyMarker.Assembly);

        services.AddSingleton<MainWindow>();

        services.AddSingleton<IMainWindowViewModel, MainWindowViewModel>();
        services.AddSingleton<ILoginViewModel, LoginViewModel>();
        services.AddSingleton<IDefaultViewModel, DefaultViewModel>();

        services.AddSingleton<IAuthenticationService, AuthenticationService>();
        services.AddSingleton<IUserService, UserService>();

        services.AddSingleton<LoginModel>();
        services.AddSingleton<UserModel>();

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