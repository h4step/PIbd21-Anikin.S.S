using System;
using System.Collections.Generic;
using System.Linq;
using ComputerSales.Data;
using ComputerSales.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ComputerSales.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<ClientRepository> _logger;

        public ClientRepository(DataContext context, ILogger<ClientRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IEnumerable<Client> GetAll()
        {
            _logger.LogInformation("Запрос списка всех клиентов.");
            return _context.Clients.AsNoTracking().ToList();
        }

        public Client GetById(int id)
        {
            _logger.LogInformation("Запрос клиента по Id={ClientId}.", id);
            return _context.Clients.AsNoTracking().FirstOrDefault(c => c.Id == id)!;
        }

        public void Add(Client client)
        {
            ArgumentNullException.ThrowIfNull(client);
            _logger.LogInformation("Добавление клиента: {@Client}", client);

            _context.Clients.Add(client);
            _context.SaveChanges();

            _logger.LogInformation("Клиент успешно добавлен, Id={ClientId}.", client.Id);
        }

        public void Update(Client client)
        {
            ArgumentNullException.ThrowIfNull(client);
            _logger.LogInformation("Обновление клиента: {@Client}", client);

            _context.Clients.Update(client);
            _context.SaveChanges();

            _logger.LogInformation("Клиент обновлён, Id={ClientId}.", client.Id);
        }

        public void Delete(int id)
        {
            _logger.LogInformation("Удаление клиента по Id={ClientId}.", id);

            var entity = _context.Clients.Find(id);
            if (entity == null)
            {
                _logger.LogWarning("Клиент с Id={ClientId} не найден для удаления.", id);
                return;
            }

            _context.Clients.Remove(entity);
            _context.SaveChanges();

            _logger.LogInformation("Клиент удалён, Id={ClientId}.", id);
        }
    }
}