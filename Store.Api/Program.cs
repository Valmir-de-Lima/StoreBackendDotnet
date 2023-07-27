using Microsoft.EntityFrameworkCore;
using Store.Domain.Handlers;
using Store.Domain.Repositories.Interfaces;
using Store.Infra.Data;
using Store.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<StoreDataContext>(opt => opt.UseInMemoryDatabase("Database"));
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<CreateUserHandler, CreateUserHandler>();

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
