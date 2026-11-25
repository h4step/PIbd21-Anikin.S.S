using System;
using System.Collections.Generic;
using System.Linq;
using ComputerSales.Data;
using ComputerSales.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ComputerSales.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<CategoryRepository> _logger;

        public CategoryRepository(DataContext context, ILogger<CategoryRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IEnumerable<Category> GetAll()
        {
            _logger.LogInformation("Запрос списка всех категорий.");
            return _context.Categories.AsNoTracking().ToList();
        }

        public Category GetById(int id)
        {
            _logger.LogInformation("Запрос категории по Id={CategoryId}.", id);
            return _context.Categories.AsNoTracking().FirstOrDefault(c => c.Id == id)!;
        }

        public void Add(Category category)
        {
            ArgumentNullException.ThrowIfNull(category);
            _logger.LogInformation("Добавление категории: {@Category}", category);

            _context.Categories.Add(category);
            _context.SaveChanges();

            _logger.LogInformation("Категория успешно добавлена, Id={CategoryId}.", category.Id);
        }

        public void Update(Category category)
        {
            ArgumentNullException.ThrowIfNull(category);
            _logger.LogInformation("Обновление категории: {@Category}", category);

            _context.Categories.Update(category);
            _context.SaveChanges();

            _logger.LogInformation("Категория обновлена, Id={CategoryId}.", category.Id);
        }

        public void Delete(int id)
        {
            _logger.LogInformation("Удаление категории по Id={CategoryId}.", id);

            var entity = _context.Categories.Find(id);
            if (entity == null)
            {
                _logger.LogWarning("Категория с Id={CategoryId} не найдена для удаления.", id);
                return;
            }

            _context.Categories.Remove(entity);
            _context.SaveChanges();

            _logger.LogInformation("Категория удалена, Id={CategoryId}.", id);
        }
    }
}