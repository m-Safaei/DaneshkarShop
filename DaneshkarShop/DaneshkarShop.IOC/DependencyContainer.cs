using DaneshkarShop.Application.Services.Implementation;
using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Data.Repositories;
using DaneshkarShop.Domain.IRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace DaneshkarShop.IOC;

public class DependencyContainer
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IContactUsRepository, ContactUsRepository>();
        services.AddScoped<IContactUsService, ContactUsService>();
        services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
        services.AddScoped<IProductCategoryService, ProductCategoryService>();
    }
}

