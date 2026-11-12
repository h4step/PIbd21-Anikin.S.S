using System.Collections.Generic;
using ComputerSales.Models;

namespace ComputerSales.Repositories
{
    public interface ISaleProductRepository
    {
        IEnumerable<SaleProduct> GetAll();
        void Add(SaleProduct saleProduct);
    }
}