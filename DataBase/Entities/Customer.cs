using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Entities
{
    public class Customer
    {
        public Customer() { }

        public Customer(string name)
        {
            Name = name;
        }

        public Customer(string name, string? phone)
        {
            Name = name;
            Phone = phone;
        }

        [Key]
        public Guid Id { get; private set; }

        //[StringLength(100)]
        public string Name { get; set; } = string.Empty;

        //[StringLength(9)]
        //[Column("ColumnName")] //називаємо в БД таблицю з телефонами як ColumnName, а не Phone
        public string? Phone { get; set; }

        //[StringLength(25)]
        public string? EMail { get; set; }
        public List<Order>? Orders { get; set; } = null;
    }
}
