using Microsoft.EntityFrameworkCore;
using Store.Domain.Handlers.UserHandlers;
using Store.Domain.Repositories.Interfaces;
using Store.Infra.Data;
using Store.Infra.Repositories;

namespace Store.Api.Extensions;

public static class ProgramExtensions
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<StoreDataContext>(opt => opt.UseInMemoryDatabase("Database"));
        builder.Services.AddTransient<IUserRepository, UserRepository>();
        builder.Services.AddTransient<UserHandler, UserHandler>();
    }
}