using UsersAPI.Core.Interfaces.Repositories;
using UsersAPI.Core.Interfaces.Services;
using UsersAPI.Core.Services;
using UsersAPI.Repository.Configuration;
using UsersAPI.Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDatabaseConnection, DatabaseConnection>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
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
