using System.Collections.Generic;
using ComputerSales.Models;

namespace ComputerSales.Repositories
{
    public class ClientRepository : IClientRepository
    {
        public IEnumerable<Client> GetAll()
        {
            // Заглушка: возвращаем пустой список
            return new List<Client>();
        }

        public Client GetById(int id)
        {
            // Заглушка: возвращаем null
            return null;
        }

        public void Add(Client client)
        {
            // Заглушка для добавления
        }

        public void Update(Client client)
        {
            // Заглушка для обновления
        }

        public void Delete(int id)
        {
            // Заглушка для удаления
        }
    }
}