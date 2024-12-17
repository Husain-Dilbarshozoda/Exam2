using Domain.Models;
using Infastructure;
using Infastructure.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IGenericService<Users>,UsersService>();
builder.Services.AddScoped<IGenericService<Jobs>, JobSerice>();
builder.Services.AddScoped<IGenericService<Applications>,ApplicationsService>();
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "BankManagment"));
}



app.UseHttpsRedirection();


app.MapControllers();
app.Run();






