using CQRSAndMediatRDemo.Application.Queries;
using CQRSAndMediatRDemo.Domain.AggregatesModel;
using CQRSAndMediatRDemo.Infrastructure.Data;
using CQRSAndMediatRDemo.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddDbContext<DbContextClass>(x => x.UseSqlServer(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IStudentQuery>(new StudentQuery(builder.Configuration.GetValue<string>("DefaultConnection")));
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