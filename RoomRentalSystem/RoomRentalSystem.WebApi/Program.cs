using System.Text;
using Microsoft.OpenApi.Models;
using RoomRentalSystem.Application.Extensions;
using RoomRentalSystem.Persistence.Extensions;
using RoomRentalSystem.WebApi.Middlewares;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RoomRentalSystem.WebApi.Validators;
using RoomRentalSystem.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserDtoValidator>(ServiceLifetime.Scoped);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Room Rental System API", Version = "v1" });
});

builder.Services
    .AddPersistenceServices(builder.Configuration.GetConnectionString("DefaultConnection"))
    .AddApplicationServices();

builder.Services.AddControllers();
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<RoomRentalSystemDbContext>();

    await dbContext.Database.MigrateAsync();

    await DbSeeder.SeedRolesAsync(dbContext);
}

app.UseMiddleware<UseGlobalErrorHandler>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c=>c.SwaggerEndpoint("/swagger/v1/swagger.json", "Room Rental System API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // TODO: add serilog

app.Run();

