using System;
using System.Collections.Generic;
using ComputerSales.Models;

namespace ComputerSales.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        public IEnumerable<Sale> GetAll()
        {
            return new List<Sale>();
        }

        public Sale GetById(int id)
        {
            return null;
        }

        public void Add(Sale sale)
        {
            throw new NotImplementedException();
        }
    }
}