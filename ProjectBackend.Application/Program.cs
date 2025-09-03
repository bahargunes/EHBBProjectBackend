using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProjectBackend.Business.DTOs;
using ProjectBackend.Business.Mappers;
using ProjectBackend.Business.Services;
using ProjectBackend.Business.Validations;
using ProjectBackend.Data.Repositories;
using ProjectBackend.Contracts.RepositoryInterfaces;
using ProjectBackend.Contracts.ServiceInterfaces;

using ProjectBackend.Data.Entities;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


// Dependency Injection 
builder.Services.AddScoped<IPlatformRepository<Platform>, PlatformRepository>();
builder.Services.AddScoped<IPlatformService<PlatformDTO>, PlatformService>();
builder.Services.AddScoped<IValidator<PlatformDTO>, PlatformValidator>();

builder.Services.AddScoped<ILaserRepository<Laser>, LaserRepository>();
builder.Services.AddScoped<ILaserService<LaserDTO>, LaserService>();
builder.Services.AddScoped<IValidator<LaserDTO>, LaserValidator>();

builder.Services.AddScoped<IEmitterRepository<Emitter>, EmitterRepository>();
builder.Services.AddScoped<IEmitterService<EmitterDTO>, EmitterService>();
builder.Services.AddScoped<IValidator<EmitterDTO>, EmitterValidator>();



builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));





builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", policy =>
    {
        policy.WithOrigins("https://localhost:56437")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();



app.UseCors("AllowReact");

app.MapControllers();
app.Run();
