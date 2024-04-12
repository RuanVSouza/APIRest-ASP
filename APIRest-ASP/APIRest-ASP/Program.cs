using APIRest_ASP.Business;
using APIRest_ASP.Business.Implementations;
using APIRest_ASP.Model.Context;
using APIRest_ASP.Repository;
using APIRest_ASP.Repository.Generic;
using APIRest_ASP.Repository.Implementations;
using EvolveDb;
using EvolveDb.Migration;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MySqlConnector;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(
    connection,
    new MySqlServerVersion(new Version(8, 0, 29)))
);

if (builder.Environment.IsDevelopment())
{
    MigrateDatabase(connection);
}

//Versioning API
builder.Services.AddApiVersioning();

//Dependency Injection - Bussines
builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
builder.Services.AddScoped<IBookBusiness, BookBusinessImplementation>();

//Dependency Injection - Repository
//builder.Services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();

//Dependency Injection - Repository Generic
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void MigrateDatabase(string connection)
{
    try
    {
        var evolveConnection = new MySqlConnection(connection);
        var evolve = new Evolve(evolveConnection, Log.Information)
        {
            Locations = new List<string> { "db/migrations", "db/dataset" },
            IsEraseDisabled = true,
        };
        evolve.Migrate();
    }
    catch (Exception ex)
    {
        Log.Error("Database migration failed", ex);
        throw;
    }
}