
using Microsoft.EntityFrameworkCore;
using Banco.WebApi.Infrastructure;
using Banco.WebApi.Core.ServiceContracts;
using Banco.WebApi.Core.Services;
using Banco.WebApi.Infrastructure.Repositories;
using RepositoryContracts;
using Banco.WebApi.UI.Middlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<BancoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Banco")));
builder.Services.AddControllers();
builder.Services.AddScoped<IClientesRepository, ClientesRepository>();
builder.Services.AddScoped<ICuentasRepository, CuentasRepository>();
builder.Services.AddScoped<IMovimientosRepository, MovimientosRepository>();
builder.Services.AddScoped<IPersonasRepository, PersonasRepository>();
builder.Services.AddScoped<IClienteGetterService, ClienteGetService>();
builder.Services.AddScoped<IClienteAdderService, ClienteAddService>();
builder.Services.AddScoped<IClienteUpdaterService, ClienteUpdateService>();
builder.Services.AddScoped<ICuentaAdderService, CuentaAddService>();
builder.Services.AddScoped<ICuentaDeleterService, CuentaDeleteService>();
builder.Services.AddScoped<ICuentaGetterService, CuentaGetService>();
builder.Services.AddScoped<IPersonaAdderService, PersonaAddService>();
builder.Services.AddScoped<IPersonaDeleterService, PersonaDeleteService>();
builder.Services.AddScoped<IPersonaGetterService, PersonaGetService>();
builder.Services.AddScoped<IMovimientoAdderService, MovimientoAddService>();
builder.Services.AddScoped<IMovimientoGetterService, MovimientoGetService>();



var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
   
    app.UseExceptionHandlingMiddleware();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
public partial class Program { }
