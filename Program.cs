using cars_api.Application.Features.Cars.Commands;
using cars_api.Application.Features.Cars.Queries;
using cars_api.ApplicationDBContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CarContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"));
});
builder.Services.AddMediatR(typeof(GetCars.Handler).Assembly);
builder.Services.AddAutoMapper(typeof(GetCars.Handler));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin 
    .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
