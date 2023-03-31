using EscalaServ.Application.Commands.CreateMilitary;
using EscalaServ.Core.Repositories;
using EscalaServ.Infrastructure.Persistence;
using EscalaServ.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = (builder.Configuration.GetConnectionString("EscalaServCS"));
builder.Services.AddDbContext<EscalaServDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IMilitaryRepository, MilitaryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();
builder.Services.AddMediatR(typeof(CreateMilitaryCommand));
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
