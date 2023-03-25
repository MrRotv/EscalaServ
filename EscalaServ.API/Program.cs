using EscalaServ.API.Models;
using EscalaServ.Application.Services.Implemetations;
using EscalaServ.Application.Services.Interfaces;
using EscalaServ.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ClosingTimeOption>(builder.Configuration.GetSection("ClosingTime"));

var connectionString = (builder.Configuration.GetConnectionString("EscalaServCS"));
builder.Services.AddDbContext<EscalaServDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IMilitaryService, MilitaryService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
