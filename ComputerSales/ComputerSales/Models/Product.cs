using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ComputerSales.Models.Enums;

namespace ComputerSales.Models
{
    [Table("products")]
    public class Product
    {
        [Key]
        [Column("id")]
        public int Id { get; protected set; }

        [Required]
        [Column("category_id")]
        public int CategoryId { get; protected set; }

        [Required]
        [MaxLength(200)]
        [Column("name")]
        public string Name { get; protected set; }

        [Required]
        [Column("origin")]
        public ProductOrigin Origin { get; protected set; }

        [Required]
        [Column("features")]
        public ProductFeatures Features { get; protected set; }

        [Required]
        [Column("price", TypeName = "numeric(18,2)")]
        public decimal Price { get; protected set; }

        [Required]
        [Column("cost_price", TypeName = "numeric(18,2)")]
        public decimal CostPrice { get; protected set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category? Category { get; protected set; }

        public virtual ICollection<SaleProduct> SaleProducts { get; protected set; } = new List<SaleProduct>();

        protected Product()
        {
            Name = string.Empty;
        }

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

            return new Product(id, categoryId, name.Trim(), origin, features, price, costPrice);
        }
    }
}