using DataBase.Entities;
//працюєте з проєктом MyEpicentre
//1-використат FluentApi підхід
//DataAnnotation закоментувати.
//2-Розбити всі наоаштування по пиофілям
//3-продумати зручні конструктори в класах-сутностях
//5-Створити 1 поле розраховуєме, а одне з дефоултним значенням. Продумати яке

namespace _16HWFluentAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new DataBaseContext();

            //1) заповнюємо БД

            var customer1 = new Customer("Solovey Ludmila");

            var customer2 = new Customer("Martiniva T", "980781111");

            Manager manager1 = new Manager()
            {
                FirstName = "Pavlo",
                LastName = "Pavlov"
            };

            var order1 = new Order()
            {
                //Id = Guid.NewGuid(), коментую, так як підключила [DatabaseGenerated(DatabaseGeneratedOption.Identity)] (в FluentAPI це: builder.Property(p => p.Id).ValueGeneratedOnAdd(); )
                //Date = DateTime.Now,  //можна вказати значення за-замовчуванням через FluentAPI (builder.Property(p => p.Date).HasDefaultValueSql("GETDATE()");)
                Customer = customer1,
                Manager = manager1
            };

            var order2 = new Order()
            {
                //Id = Guid.NewGuid(),коментую, так як підключила [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  (в FluentAPI це: builder.Property(p => p.Id).ValueGeneratedOnAdd(); )
                //Date = DateTime.Now, // можна вказати значення за-замовчуванням через FluentAPI (builder.Property(p => p.Date).HasDefaultValueSql("GETDATE()");)
                Customer = customer1,
                Manager = new()
                {
                    FirstName = "Jack",
                    LastName = "Petterson"
                }
            };

            var product1 = new Product()
            {
                //Id = 1, первинний ключ типу int БД генерує і автоінкрементує самостійно
                Name = "Цитрамон",
                PriceWithNDS = 56.10m
            };

            var product2 = new Product()
            {
                //Id = 2, первинний ключ типу int БД генерує і автоінкрементує самостійно
                Name = "Аналгін",
                PriceWithNDS = 7.10m
            };

            var product3 = new Product("Вода мінеральна", 255.80m);

            db.Products.AddRange(product1, product2, product3);
            db.Customers.AddRange(customer1, customer2);
            //db.Orders.AddRange(order1, order2);

            db.SaveChanges();

            // 2) Дістаємо кастомера з бази
            Customer? customer = db.Customers.FirstOrDefault(c => c.Name == "Martinova");

            Product? product4 = db.Products.FirstOrDefault(p => p.Name == "Цитрамон");
            var product5 = db.Products.FirstOrDefault(p => p.Name == "Аналгін");

            var order3 = new Order()
            {
                //Id = Guid.NewGuid(), коментую, так як підключила [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                Customer = customer ?? new Customer(), // кастомера, якого дістали з БД використовуємо (передаємо ссилку) для створення замовлення
                Date = DateTime.Now,
                Manager = new()
                {
                    FirstName = "Anton",
                    LastName = "Barbara"
                }
            };

            var orderDetailes = new List<OrderDetailes>()
            {
                new OrderDetailes()
                {
                MyOrder = order3,
                Product = product4 ?? new(),
                //Quantity = 2 //коментую, щоб перевірити відпрацювання значення за-замовчуванням
                },

                new OrderDetailes()
                {
                MyOrder = order3,
                Product = product5 ?? new(),
                Quantity = 4
                }
            };

            order3.OrderDetailes.FirstOrDefault();

            db.OrdersDetailes.AddRange(orderDetailes);

            db.SaveChanges();

        }
    }
}
