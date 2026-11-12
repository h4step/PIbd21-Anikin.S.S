using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSales.Models
{
    public class SaleProduct
    {
        public int Id { get; private set; }
        public int SaleId { get; private set; }
        public int ProductId { get; private set; }
        public int Count { get; private set; }
        public decimal PriceAtSale { get; private set; }

        private SaleProduct(int id, int saleId, int productId, int count, decimal priceAtSale)
        {
            Id = id;
            SaleId = saleId;
            ProductId = productId;
            Count = count;
            PriceAtSale = priceAtSale;
        }

        public static SaleProduct CreateEntity(int id, int saleId, int productId, int count, decimal priceAtSale)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count), "Количество товара должно быть больше нуля.");

            if (priceAtSale < 0)
                throw new ArgumentOutOfRangeException(nameof(priceAtSale), "Цена продажи не может быть отрицательной.");

            return new SaleProduct(id, saleId, productId, count, priceAtSale);
        }
    }
}