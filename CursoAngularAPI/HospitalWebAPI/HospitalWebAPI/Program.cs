using HospitalModels.Modelos;
using LogicaDeNegocios.BLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Repositorios.DAL.Interfaces;
using Repositorios.DAL.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddDbContext<HospitalAppContext>(optionsAction: option =>
    option.UseSqlServer("name=DefaultConnection").UseLazyLoadingProxies(false));
builder.Services.AddScoped<IRepositorioMedicos, MedicosRepositorio>();
builder.Services.AddScoped<MedicoBLL>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("allow", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:4200") // Permitir localhost:4200
                     .AllowAnyHeader()                     // Permitir cualquier encabezado
                     .AllowAnyMethod()                     // Permitir todos los métodos HTTP
                     .AllowCredentials();                  // Permitir el uso de credenciales (si es necesario)
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("allow");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
