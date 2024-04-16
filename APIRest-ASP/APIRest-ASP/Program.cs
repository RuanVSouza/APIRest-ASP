using APIRest_ASP.Business;
using APIRest_ASP.Business.Implementations;
using APIRest_ASP.HyperMedia.Enricher;
using APIRest_ASP.HyperMedia.Filters;
using APIRest_ASP.Model.Context;
using APIRest_ASP.Repository.Generic;
using EvolveDb;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using MySqlConnector;
using Serilog;


var builder = WebApplication.CreateBuilder(args);
var appName = "APIRestFull ASP";
var appVersion1 = "v1";

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

builder.Services.AddMvc(options =>
{
    options.RespectBrowserAcceptHeader = true;

    options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
    options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
})
.AddXmlSerializerFormatters();

var filterOptions = new HyperMediaFilterOptions();
filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());
filterOptions.ContentResponseEnricherList.Add(new BookEnricher());

builder.Services.AddSingleton(filterOptions);

builder.Services.AddCors(options => options.AddDefaultPolicy(builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

//Versioning API
builder.Services.AddApiVersioning();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = appName,
            Version = appVersion1,
            Description = "APIRestFull ASP - Pratica",
            Contact = new OpenApiContact { Name = "Ruan" }
        });
});


//Dependency Injection - Bussines
builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
builder.Services.AddScoped<IBookBusiness, BookBusinessImplementation>();

//Dependency Injection - Repository Generic
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIRestFull ASP");
});

var option = new RewriteOptions();
option.AddRedirect("^$", "swagger");
app.UseRewriter(option);

app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute("DefaultApi", "{controller=values}/v{version=apiVersion}/{id?}");

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