using Agilite.Mapper.Configuration;
using Agilite.Repositories.Repositories;
using Agilite.Services;
using Agilite.UnitOfWork;
using Agilite.UnitOfWork.Context;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

namespace Agilite.Api.Configurations;

public static class Container
{
    public static WebApplication Configure(this WebApplicationBuilder builder)
    {
        builder.Services.RgisterServices(builder.Configuration);

        var application = builder.Build();
        application.ConfigureApplication();

        return application;
    }

    private static void RgisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.ConfigureMappers();
        services.AddMediatR(AssemblyMarker.Assembly);

        services.AddDbContext<AgiliteContext>(optionBuilder => 
            optionBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Description = "Authorization using Bearer scheme",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });

            options.OperationFilter<SecurityRequirementsOperationFilter>();
        });

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:TokenKey").Value!)),
                };
            });

        services
            .AddControllersWithViews()
            .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

        services.AddScoped<IUnitOfWork, Repositories.UnitOfWork>();

        services.AddScoped(typeof(IService<>), typeof(Service<>));
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITeamService, TeamService>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<ISprintService, SprintService>();
        services.AddScoped<IObjectiveService, ObjectiveService>();
        services.AddScoped<IJobService, JobService>();

        services.AddTransient<IAuthenticationRepository, AuthenticationRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<ITeamRepository, TeamRepository>();
        services.AddTransient<IProjectRepository, ProjectRepository>();
        services.AddTransient<ISprintRepository, SprintRepository>();
        services.AddTransient<IObjectiveRepository, ObjectiveRepository>();
        services.AddTransient<IJobRepository, JobRepository>();
    }

    private static void ConfigureApplication(this WebApplication application)
    {
        if (application.Environment.IsDevelopment())
        {
            application.UseSwagger();
            application.UseSwaggerUI();
        }

        application.UseHttpsRedirection();

        application.UseAuthentication();

        application.UseAuthorization();

        application.MapControllers();

        application.Run();
    }
}