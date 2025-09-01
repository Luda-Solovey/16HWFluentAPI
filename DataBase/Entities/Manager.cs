using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    //[Table("SuperUsers")] назвати таблюцю в БД по-іншому, ніж в проекті
    public class Manager
    {
        public Manager() { }

        public Manager(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]//щоб значення гуіда на боці БД генерувалось автоматично
        public Guid Id { get; private set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? AdditionalInformation { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
