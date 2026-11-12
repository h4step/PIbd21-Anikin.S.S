using ComputerSales.Models;
using System.Collections.Generic;

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
             
        }

        public void Update(Category category)
        {
             
        }

        public void Delete(int id)
        {
           
        }
    }
}