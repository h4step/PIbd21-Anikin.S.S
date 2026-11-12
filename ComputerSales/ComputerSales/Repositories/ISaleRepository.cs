using System.Collections.Generic;
using ComputerSales.Models;

namespace ComputerSales.Repositories
{
    public interface ISaleRepository
    {
        IEnumerable<Sale> GetAll();
        Sale GetById(int id);
        void Add(Sale sale);
    }
}