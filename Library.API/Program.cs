using FluentValidation;
using Library.Core;
using Library.Core.Books.Commands.Create;
using Library.Core.Common.Behaivors;
using Library.Infastructure.Persistence;
using Library.Infastructure.Persistence.Repositories;
using Library.Infrastructure.Persistence.Mapping;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using SimpleInjector;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseSerilog((context, config) =>
    config.ReadFrom.Configuration(context.Configuration));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Library API", Version = "v1" });
});

builder.Services.AddDbContext<EFContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Connect"));
});

builder.Services.AddMediatR(typeof(Anchor));
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddRepositories();
builder.Services.AddAutoMapper(typeof(BookProfile));
builder.Services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaivor<,>));

builder.Services.ConfigureSwaggerGen(c => c.SchemaGeneratorOptions.SchemaIdSelector = x => x.ToFriendlyName());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
