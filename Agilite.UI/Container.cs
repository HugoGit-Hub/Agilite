﻿using Agilite.UI.Mapper;
using Agilite.UI.Mapper.Configuration;
using Agilite.UI.Services;
using Agilite.UI.Services.Refit;
using Agilite.UI.Services.Services;
using Agilite.UI.ViewModels;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Linq;

namespace Agilite.UI;

public class Container
{
    public static MainWindowViewModel? MainWindowViewModel => ConfigureServices().GetService<MainWindowViewModel>();

    public static LoginViewModel? LoginViewModel => ConfigureServices().GetService<LoginViewModel>();

    public static DefaultViewModel? DefaultViewModel => ConfigureServices().GetService<DefaultViewModel>();

    public static TeamViewModel? TeamViewModel => ConfigureServices().GetService<TeamViewModel>();

    public static SprintViewModel? SprintViewModel => ConfigureServices().GetService<SprintViewModel>();

    public static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.ConfigureMappers();
        services.AddMediatR(AssemblyMarker.Assembly);

        services.AddSingleton<MainWindow>();

        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<LoginViewModel>();
        services.AddSingleton<DefaultViewModel>();
        services.AddSingleton<TeamViewModel>();
        services.AddSingleton<SprintViewModel>();

        services.AddSingleton<IAuthenticationService, AuthenticationService>();
        services.AddSingleton<IUserService, UserService>();
        services.AddSingleton<ITeamService, TeamService>();
        services.AddSingleton<IProjectService, ProjectService>();
        services.AddSingleton<ISprintService, SprintService>();
        services.AddSingleton<IObjectiveService, ObjectiveService>();

        foreach (var type in
                typeof(IBaseRefitClient).Assembly
                    .GetTypes()
                    .Where(type => type.GetInterfaces().Contains(typeof(IBaseRefitClient))))
        {
            services.AddRefitClient(type)
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(EndPointConstantes.ApiAddress));
        }

        return services.BuildServiceProvider();
    }
}