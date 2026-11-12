using System.Collections.Generic;
using ComputerSales.Models;

namespace ComputerSales.Repositories
{
    public class SaleProductRepository : ISaleProductRepository
    {
        public IEnumerable<SaleProduct> GetAll()
        {
            // Заглушка: возвращаем пустой список связок многие-ко-многим
            return new List<SaleProduct>();
        }

        public void Add(SaleProduct saleProduct)
        {
            // Заглушка для добавления связи продажи с товаром
        }
    }
}