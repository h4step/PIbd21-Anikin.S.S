using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerSales.Models
{
    [Table("sales")]
    public class Sale
    {
        [Key]
        [Column("id")]
        public int Id { get; protected set; }

        [Required]
        [Column("client_id")]
        public int ClientId { get; protected set; }

        [Required]
        [Column("sale_date")]
        public DateTime SaleDate { get; protected set; }

        [Required]
        [Column("total_amount", TypeName = "numeric(18,2)")]
        public decimal TotalAmount { get; protected set; }

        [ForeignKey(nameof(ClientId))]
        public virtual Client? Client { get; protected set; }

        public virtual ICollection<SaleProduct> SaleProducts { get; protected set; } = new List<SaleProduct>();

        protected Sale()
        {
        }

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