
using Scalar.AspNetCore;
using TechDaniels.IdentityServer.Core;
using TechDaniels.IdentityServer.Services;
using TechDaniels.IdentityServer.Data;
using TechDaniels.IdentityServer.Domain;

var builder = WebApplication.CreateBuilder(args);

var appSettings = builder.Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();
builder.Services.AddSingleton<AppSettings>(appSettings);

builder.Services.InjectDataDependencies(appSettings);
builder.Services.InjectAdminServicesDependencies();
builder.Services.InjectDomainServices();


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.RouteTemplate = "openapi/{documentName}.json";
    });
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
