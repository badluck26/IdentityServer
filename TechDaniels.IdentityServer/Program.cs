using System.Configuration;
using TechDaniels.IdentityServer.Core;
using TechDaniels.IdentityServer.Data;
using TechDaniels.IdentityServer.Services;
var builder = WebApplication.CreateBuilder(args);

var appSettings = builder.Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();
builder.Services.AddSingleton<AppSettings>(appSettings);

builder.Services.InjectDataDependencies(appSettings);
builder.Services.InjectAuthServicesDependencies();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

DbManager.TryUpdateDB(app.Configuration.GetConnectionString("IdentityDbConnection"));

app.Run();
