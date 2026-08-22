using Clabber.Backend.Api;
using Clabber.Backend.Application;
using Clabber.Backend.Infrastructure;
using Clabber.Backend.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

// First Infrastructure than Api is mandatory to ensure identity's context uses dev-specific connection string
builder.SetUpInfrastructure();
builder.SetupApi();
builder.SetUpApplication();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // Run development data seeder
    using (var scope = app.Services.CreateScope())
    {
        var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
        await seeder.SeedAsync();
    }
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();