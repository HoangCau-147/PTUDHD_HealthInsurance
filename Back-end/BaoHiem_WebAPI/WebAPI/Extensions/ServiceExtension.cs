using AutoMapper;
using Contracts;
using Entity.Models;
using LoggerService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository;
using Service.Contracts;
using Services;
using System.Text;

namespace WebAPI.Extensions;
public static class ServiceExtension
{
    public static void ConfigureServiceManager(this IServiceCollection service)
        => service.AddScoped<IServiceManager, ServiceManager>();
    public static void ConfigureRepositoryManager(this IServiceCollection service)
        => service.AddScoped<IRepositoryManager, RepositoryManager>();
    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<InsuranceDBContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("InsuranceConnectionString")));
    public static void ConfigureIdentity(this IServiceCollection services)
        =>services.AddIdentity<User, IdentityRole>(o =>
        {
            o.Password.RequireDigit = true;
            o.Password.RequireLowercase = false;
            o.Password.RequireUppercase = false;
            o.Password.RequireNonAlphanumeric = false;
            o.Password.RequiredLength = 6;
            o.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<InsuranceDBContext>()
          .AddDefaultTokenProviders();
    public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        => services.AddAuthentication(options => 
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = configuration["JWT:ValidAudience"],
                ValidIssuer = configuration["JWT:ValidIssuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
            };
        });
    public static void ConfigureRequiredEmail(this IServiceCollection services)
        => services.Configure<IdentityOptions>(
            otps => otps.SignIn.RequireConfirmedEmail = true
            );
    public static void ConfigureSwagger(this IServiceCollection services) 
        => services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "My API",
                Version = "v1"
            });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please insert JWT with Bearer into field",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement 
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });
    public static void ConfigureLoggerService(this IServiceCollection services) =>
 services.AddSingleton<ILoggerManager, LoggerManager>();
    public static void ConfigureCors(this IServiceCollection services) =>
         services.AddCors(options =>
         {
             options.AddPolicy(name: "CorsPolicy", 
                 builder =>
                 {
                     builder.WithOrigins("http://localhost:3000")
                     .AllowAnyMethod()
                     .AllowAnyHeader();
                 });
         });
    public static void ConfigureIISIntegration(this IServiceCollection services) =>
         services.Configure<IISOptions>(options =>
         {
         });

}
