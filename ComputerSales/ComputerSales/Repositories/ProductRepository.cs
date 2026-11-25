using System;
using System.Collections.Generic;
using ComputerSales.Models;

namespace ComputerSales.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetAll()
        {
            return new List<Product>();
        }

        public Product GetById(int id)
        {
            return null;
        }

        public IEnumerable<Product> GetByCategory(int categoryId)
        {
            return new List<Product>();
        }

        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}