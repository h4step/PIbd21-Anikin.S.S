using System;
using System.Collections.Generic;
using ComputerSales.Models;

namespace ComputerSales.Repositories
{
    public class SaleProductRepository : ISaleProductRepository
    {
        public IEnumerable<SaleProduct> GetAll()
        {
            return new List<SaleProduct>();
        }

        public void Add(SaleProduct saleProduct)
        {
            throw new NotImplementedException();
        }
    }
}