
using Microsoft.EntityFrameworkCore;
using Banco.WebApi.Infrastructure;
using Banco.WebApi.Core.ServiceContracts;
using Banco.WebApi.Core.Services;
using Banco.WebApi.Infrastructure.Repositories;
using RepositoryContracts;


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
builder.Services.AddScoped<IClienteGetterService, ClienteGetService>();

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
   
    //app.UseExceptionHandlingMiddleware();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
