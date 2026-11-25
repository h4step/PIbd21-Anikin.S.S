using System;
using System.Collections.Generic;
using System.Linq;
using ComputerSales.Data;
using ComputerSales.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ComputerSales.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<SaleRepository> _logger;

        public SaleRepository(DataContext context, ILogger<SaleRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IEnumerable<Sale> GetAll()
        {
            _logger.LogInformation("Запрос списка всех продаж.");
            return _context.Sales
                .AsNoTracking()
                .Include(s => s.Client)
                .Include(s => s.SaleProducts)
                    .ThenInclude(sp => sp.Product)
                .ToList();
        }

        public Sale GetById(int id)
        {
            _logger.LogInformation("Запрос продажи по Id={SaleId}.", id);
            return _context.Sales
                .AsNoTracking()
                .Include(s => s.Client)
                .Include(s => s.SaleProducts)
                    .ThenInclude(sp => sp.Product)
                .FirstOrDefault(s => s.Id == id)!;
        }

        public void Add(Sale sale)
        {
            ArgumentNullException.ThrowIfNull(sale);
            _logger.LogInformation("Создание продажи через транзакцию: {@Sale}", sale);

            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Sales.Add(sale);
                _context.SaveChanges();
                transaction.Commit();

                _logger.LogInformation("Продажа успешно создана, Id={SaleId}.", sale.Id);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                _context.ChangeTracker.Clear();
                _logger.LogError(ex, "Ошибка при создании продажи {@Sale}. Транзакция отменена.", sale);
                throw;
            }
        }
    }
}