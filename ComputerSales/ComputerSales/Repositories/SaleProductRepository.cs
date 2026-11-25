using System;
using System.Collections.Generic;
using System.Linq;
using ComputerSales.Data;
using ComputerSales.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ComputerSales.Repositories
{
    public class SaleProductRepository : ISaleProductRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<SaleProductRepository> _logger;

        public SaleProductRepository(DataContext context, ILogger<SaleProductRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IEnumerable<SaleProduct> GetAll()
        {
            _logger.LogInformation("Запрос всех позиций продаж (SaleProducts).");
            return _context.SaleProducts
                .AsNoTracking()
                .Include(sp => sp.Product)
                .Include(sp => sp.Sale)
                .ToList();
        }

        public void Add(SaleProduct saleProduct)
        {
            ArgumentNullException.ThrowIfNull(saleProduct);
            _logger.LogInformation("Добавление позиции продажи через транзакцию: {@SaleProduct}", saleProduct);

            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.SaleProducts.Add(saleProduct);
                _context.SaveChanges();
                transaction.Commit();

                _logger.LogInformation("Позиция продажи сохранена, Id={SaleProductId}.", saleProduct.Id);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                _logger.LogError(ex, "Ошибка при сохранении позиции продажи {@SaleProduct}. Транзакция отменена.", saleProduct);
                throw;
            }
        }
    }
}