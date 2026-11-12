using System;
using System.Collections.Generic;
using ComputerSales.Models.Enums;

namespace ComputerSales.Models
{
    public class Product
    {
        public int Id { get; private set; }
        public int CategoryId { get; private set; }
        public string Name { get; private set; }
        public ProductOrigin Origin { get; private set; }
        public ProductFeatures Features { get; private set; }
        public decimal Price { get; private set; }
        public decimal CostPrice { get; private set; }

        public Category Category { get; private set; } = null!;
        public ICollection<SaleProduct> SaleProducts { get; private set; } = new List<SaleProduct>();

        private Product(int id, int categoryId, string name, ProductOrigin origin, ProductFeatures features, decimal price, decimal costPrice)
        {
            Id = id;
            CategoryId = categoryId;
            Name = name;
            Origin = origin;
            Features = features;
            Price = price;
            CostPrice = costPrice;
        }

        public static Product CreateEntity(int id, int categoryId, string name, ProductOrigin origin, ProductFeatures features, decimal price, decimal costPrice)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название товара не может быть пустым.", nameof(name));

            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Цена не может быть отрицательной.");

            if (costPrice < 0)
                throw new ArgumentOutOfRangeException(nameof(costPrice), "Себестоимость не может быть отрицательной.");

            return new Product(id, categoryId, name, origin, features, price, costPrice);
        }
    }
}