using System;
using System.Collections.Generic;
using ComputerSales.Models;

namespace ComputerSales.Repositories
{
    public class ClientRepository : IClientRepository
    {
        public IEnumerable<Client> GetAll()
        {
            return new List<Client>();
        }

        public Client GetById(int id)
        {
            return null;
        }

        public void Add(Client client)
        {
            throw new NotImplementedException();
        }

        public void Update(Client client)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}