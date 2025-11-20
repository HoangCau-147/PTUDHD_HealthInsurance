using Entity.Email;
using NLog;
using Microsoft.OpenApi.Models;
using NETCore.MailKit.Core;
using Repository;
using WebAPI.Extensions;
using Contracts;
using Microsoft.AspNetCore.HttpOverrides;
using Config;

var builder = WebApplication.CreateBuilder(args);
var configure = builder.Configuration;
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),"/nlog.config"));


builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter Bearer '[jwt]'",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    var scheme = new OpenApiSecurityScheme
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    options.AddSecurityRequirement(new OpenApiSecurityRequirement { { scheme, Array.Empty<string>() } });
});

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(configure);
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureSqlContext(configure);
builder.Services.ConfigureRequiredEmail();
builder.Services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
builder.Services.ConfigureCors();
//register Identity

builder.Services.Configure<MomoConfig>(
    builder.Configuration.GetSection(MomoConfig.ConfigName));

// accept xaml
//builder.Services.AddControllers(config =>
//{
//    config.RespectBrowserAcceptHeader = true;
//}).AddXmlDataContractSerializerFormatters();


//Email configuration
var email = configure.GetSection("EmailConfiguration").Get<EmailConfiguration>();
builder.Services.AddSingleton(email);
//builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddControllers();
//builder.Services.ConfigureSwagger();

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);
if (app.Environment.IsProduction())
    app.UseHsts();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication(); 

app.UseAuthorization();

app.MapControllers();

app.Run();
