using BookMyHome.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Database
// https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/projects?tabs=dotnet-core-cli
// Add-Migration InitialMigration -Context BookMyHomeContext -Project BookMyHome.DatabaseMigration
// Update-Database -Context BookMyHomeContex
builder.Services.AddDbContext<BookMyHomeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookMyHomeDbConnection"),
        x =>
            x.MigrationsAssembly("BookMyHome.DatabaseMigration")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();