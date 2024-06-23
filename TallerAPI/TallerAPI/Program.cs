using Microsoft.AspNetCore.Mvc.RazorPages;
using TallerAPI.Models;
using TallerAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<AutoDbSettings>(
    builder.Configuration.GetSection("AutoDbSettings"));
builder.Services.AddSingleton<TallerServices>();

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


{
    app.MapGet("/autos", async (TallerServices TallerServices) => {
        var padres = await TallerServices.GetAsync();
        return padres;
    });
    app.MapGet("/autos/{id}", async (TallerServices TallerServices, string id) => {
        var padres = await TallerServices.GetAsync(id);
        return padres is null ? Results.NotFound() : Results.Ok(padres);
    });
    app.MapPost("/autos", async (TallerServices TallerServices, Automovil padre) => {
        await TallerServices.CreateAsync(padre);
        return padre;
    });
    app.MapPut("/autos/{id}", async (TallerServices TallerServices, string id, Automovil Automovil) => {
        await TallerServices.UpdateAsync(id, Automovil);
        return Automovil;
    });
    app.MapDelete("/autos/{id}", async (TallerServices TallerServices, string id) => {
        await TallerServices.RemoveAsync(id);
        return Results.Ok();
    });
}

app.Run();
