using System;
using System.Collections.Generic;
using System.Linq;
using ComputerSales.Data;
using ComputerSales.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ComputerSales.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(DataContext context, ILogger<ProductRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IEnumerable<Product> GetAll()
        {
            _logger.LogInformation("Запрос списка всех товаров.");
            return _context.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .ToList();
        }

        public Product GetById(int id)
        {
            _logger.LogInformation("Запрос товара по Id={ProductId}.", id);
            return _context.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .FirstOrDefault(p => p.Id == id)!;
        }

        public IEnumerable<Product> GetByCategory(int categoryId)
        {
            _logger.LogInformation("Запрос товаров по CategoryId={CategoryId}.", categoryId);
            return _context.Products
                .AsNoTracking()
                .Where(p => p.CategoryId == categoryId)
                .ToList();
        }

        public void Add(Product product)
        {
            ArgumentNullException.ThrowIfNull(product);
            _logger.LogInformation("Добавление товара: {@Product}", product);

            _context.Products.Add(product);
            _context.SaveChanges();

            _logger.LogInformation("Товар добавлен, Id={ProductId}.", product.Id);
        }

        public void Update(Product product)
        {
            ArgumentNullException.ThrowIfNull(product);
            _logger.LogInformation("Обновление товара: {@Product}", product);

            var tracked = _context.ChangeTracker.Entries<Product>()
                .FirstOrDefault(e => e.Entity.Id == product.Id)?.Entity;

            if (tracked == null)
            {
                tracked = _context.Products.FirstOrDefault(p => p.Id == product.Id);
                if (tracked == null)
                {
                    _logger.LogWarning("Товар с Id={ProductId} не найден для обновления.", product.Id);
                    return;
                }
            }

            _context.Entry(tracked).CurrentValues.SetValues(product);
            _context.Entry(tracked).Reference(p => p.Category).CurrentValue = null;

            _context.SaveChanges();

            _logger.LogInformation("Товар обновлён, Id={ProductId}.", product.Id);
        }

        public void Delete(int id)
        {
            _logger.LogInformation("Удаление товара по Id={ProductId}.", id);

            var entity = _context.Products.Find(id);
            if (entity == null)
            {
                _logger.LogWarning("Товар с Id={ProductId} не найден для удаления.", id);
                return;
            }

            _context.Products.Remove(entity);
            _context.SaveChanges();

            _logger.LogInformation("Товар удалён, Id={ProductId}.", id);
        }
    }
}