using System;
using ComputerSales.Data;
using ComputerSales.Forms;
using ComputerSales.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ComputerSales
{
    public static class DependencyInjection
    {
        public static IServiceProvider ConfigureServices()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            var services = new ServiceCollection();

            services.AddSingleton<IConfiguration>(configuration);

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddSerilog(Log.Logger, dispose: true);
            });

            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? "Host=localhost;Port=5432;Database=computer_sales_db;Username=postgres;Password=";

            services.AddDbContext<DataContext>((sp, options) =>
            {
                var loggerFactory = sp.GetService<ILoggerFactory>();
                if (loggerFactory != null)
                {
                    options.UseLoggerFactory(loggerFactory);
                }

                options.UseNpgsql(connectionString);
            });

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<ISaleRepository, SaleRepository>();
            services.AddTransient<ISaleProductRepository, SaleProductRepository>();

            services.AddTransient<MainForm>();
            services.AddTransient<ProductEditForm>();
            services.AddTransient<SaleEditForm>();
            services.AddTransient<SalesForm>();

            return services.BuildServiceProvider();
        }
    }
}