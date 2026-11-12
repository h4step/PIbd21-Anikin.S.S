using System.Collections.Generic;
using ComputerSales.Models;

namespace ComputerSales.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        public IEnumerable<Sale> GetAll()
        {
            // Заглушка: возвращаем пустой список
            return new List<Sale>();
        }

        public Sale GetById(int id)
        {
            // Заглушка: возвращаем null
            return null;
        }

        public void Add(Sale sale)
        {
            // Заглушка для добавления продажи (операции)
        }
    }
}