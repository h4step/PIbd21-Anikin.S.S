using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerSales.Models
{
    [Table("clients")]
    public class Client
    {
        [Key]
        [Column("id")]
        public int Id { get; protected set; }

        [Required]
        [MaxLength(200)]
        [Column("full_name")]
        public string FullName { get; protected set; }

        [MaxLength(50)]
        [Column("phone")]
        public string Phone { get; protected set; }

        public virtual ICollection<Sale> Sales { get; protected set; } = new List<Sale>();

        protected Client()
        {
            FullName = string.Empty;
            Phone = string.Empty;
        }

        private Client(int id, string fullName, string phone)
        {
            Id = id;
            FullName = fullName;
            Phone = phone;
        }

        public static Client CreateEntity(int id, string fullName, string phone)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("ФИО клиента не может быть пустым.", nameof(fullName));

            return new Client(id, fullName.Trim(), phone?.Trim() ?? string.Empty);
        }
    }
}