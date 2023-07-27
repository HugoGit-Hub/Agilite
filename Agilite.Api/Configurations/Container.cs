﻿using Agilite.Mapper.Configuration;
using Agilite.Repositories.Repositories;
using Agilite.Services;
using Agilite.UnitOfWork;
using Agilite.UnitOfWork.Context;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
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

    public static void RgisterServices(this IServiceCollection services, IConfiguration configuration)
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

        services.AddScoped<IUnitOfWork, Repositories.UnitOfWork>();

        services.AddScoped(typeof(IService<>), typeof(Service<>));
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITeamService, TeamService>();

        services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITeamRepository, TeamRepository>();
    }

    public static void ConfigureApplication(this WebApplication application)
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