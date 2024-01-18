using Microsoft.EntityFrameworkCore;
using MyHomeNet.Models;
using MyHomeNet.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<MyHomeContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MyHomeContext")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();