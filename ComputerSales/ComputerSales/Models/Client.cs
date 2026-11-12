using System;
using System.Collections.Generic;

namespace ComputerSales.Models
{
    public class Client
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Phone { get; private set; }

        public ICollection<Sale> Sales { get; private set; } = new List<Sale>();

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

            return new Client(id, fullName, phone);
        }
    }
}