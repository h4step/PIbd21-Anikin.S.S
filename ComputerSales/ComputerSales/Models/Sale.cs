using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace ComputerSales.Models
{
    public class Sale
    {
        public int Id { get; private set; }
        public int ClientId { get; private set; }
        public DateTime SaleDate { get; private set; }
        public decimal TotalAmount { get; private set; }

        private Sale(int id, int clientId, DateTime saleDate, decimal totalAmount)
        {
            Id = id;
            ClientId = clientId;
            SaleDate = saleDate;
            TotalAmount = totalAmount;
        }

        public static Sale CreateEntity(int id, int clientId, DateTime saleDate, decimal totalAmount)
        {
            if (totalAmount < 0)
                throw new ArgumentOutOfRangeException(nameof(totalAmount), "Сумма продажи не может быть отрицательной.");

            return new Sale(id, clientId, saleDate, totalAmount);
        }
    }
}