using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerSales.Models
{
    [Table("categories")]
    public class Category
    {
        [Key]
        [Column("id")]
        public int Id { get; protected set; }

        [Required]
        [MaxLength(150)]
        [Column("name")]
        public string Name { get; protected set; }

        [MaxLength(500)]
        [Column("description")]
        public string Description { get; protected set; }

        public virtual ICollection<Product> Products { get; protected set; } = new List<Product>();

        protected Category()
        {
            Name = string.Empty;
            Description = string.Empty;
        }

        private Category(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public static Category CreateEntity(int id, string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название категории не может быть пустым.", nameof(name));

            return new Category(id, name.Trim(), description?.Trim() ?? string.Empty);
        }
    }
}