using Microsoft.Extensions.DependencyInjection;
using ComputerSales.Repositories;
using System;

namespace ComputerSales
{
    public static class DependencyInjection
    {
        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Регистрация репозиториев
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<ISaleRepository, SaleRepository>();
            services.AddTransient<ISaleProductRepository, SaleProductRepository>();

            // Регистрация главной формы (обязательно для DI)
            services.AddTransient<MainForm>();

            return services.BuildServiceProvider();
        }
    }
}