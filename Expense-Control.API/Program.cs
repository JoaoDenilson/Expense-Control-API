using AutoMapper;
using Expense_Control.API.AutoMapper;
using Expense_Control.API.Data;
using Expense_Control.API.Domain.Repository.Classes;
using Expense_Control.API.Domain.Repository.Interfaces;
using Expense_Control.API.Domain.Services;
using Expense_Control.API.Domain.Services.Interfaces;
using Expense_Control.API.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("standard")), ServiceLifetime.Transient, ServiceLifetime.Transient);

// Add services to the container.
DependencyInjectionConfig.RegisterServices(builder.Services);

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