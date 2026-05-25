using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Todo_assginment.custom_exceptions;
using Todo_assginment.Middleware;
using Todo_assginment.Repository;
using Todo_assginment.Service;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Appdbcontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<ITodoService, TodoService>();

builder.Services.AddCors((p) => p.AddDefaultPolicy(
 policy => policy.WithOrigins("*")
         .AllowAnyHeader()
     .AllowAnyMethod()
  ));

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors();

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
