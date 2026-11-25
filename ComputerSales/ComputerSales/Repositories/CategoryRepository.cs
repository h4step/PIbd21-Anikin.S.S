using System;
using System.Collections.Generic;
using ComputerSales.Models;

namespace ComputerSales.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> GetAll()
        {
            return new List<Category>();
        }

        public Category GetById(int id)
        {
            return null;
        }

        public void Add(Category category)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}