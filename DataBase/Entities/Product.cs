using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    [Index(nameof(Name))]//робимо некластирізований індекс для поля Name (щоб швидко відпрацьовував пошук по цьому полю)
                         //оголошується перед назвою класу (не на самій властивості)
                         //якщо через FluentAPI:
                         //modelBuilder.Entity<Product>().HasIndex(p => p.Name)


    //[PrimaryKey(nameof(Name), nameof(Price))]//ПЕРЕПИТАТИ
    public class Product
    {
        public Product() { }

        public Product(string name, decimal price)
        {
            Name = name;
            PriceWithNDS = price;
        }
        public int Id { get; private set; }//робимо властивість readonly

        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal? PriceWithNDS { get; set; }

        public decimal RawPrice { get; set; }

        public List<OrderDetailes> Detailes { get; set; } = []; //навігаційна властивість
                                                                //для того, щоб ми могли переглядати списки ордерів, в яких певний продукт був замовлений

    }
}
