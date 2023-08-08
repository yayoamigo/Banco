using Banco.WebApi.Entity;
using Microsoft.EntityFrameworkCore;
using Banco.WebApi.Infrastructure; 


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<BancoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Banco")));
builder.Services.AddControllers();

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
