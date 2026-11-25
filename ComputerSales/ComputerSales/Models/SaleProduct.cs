using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ComputerSales.Models
{
    [Table("sale_products")]
    public class SaleProduct
    {
        [Key]
        [Column("id")]
        public int Id { get; protected set; }

        [Required]
        [Column("sale_id")]
        public int SaleId { get; protected set; }

        [Required]
        [Column("product_id")]
        public int ProductId { get; protected set; }

        [Required]
        [Column("count")]
        public int Count { get; protected set; }

        [Required]
        [Column("price_at_sale", TypeName = "numeric(18,2)")]
        public decimal PriceAtSale { get; protected set; }

        [ForeignKey(nameof(SaleId))]
        public virtual Sale? Sale { get; protected set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product? Product { get; protected set; }

        protected SaleProduct()
        {
        }

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