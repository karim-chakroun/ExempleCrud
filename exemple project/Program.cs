﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using exemple_project.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<exemple_projectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("exemple_projectContext") ?? throw new InvalidOperationException("Connection string 'exemple_projectContext' not found.")));

// Add services to the container.

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
