using ComputerSales.Models;
using System.Collections.Generic;

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
 
        }

        public void Update(Product product)
        {
 
        }

        public void Delete(int id)
        {
 
        }
    }
}