using System.ComponentModel.DataAnnotations;

namespace DataBase.Entities
{
    public class OrderDetailes
    {
        public OrderDetailes() { }

        public OrderDetailes(Product product, int quantity) 
        {
            Product = product;
            Quantity = quantity;
        }

        [Key]
        public int Id { get; set; }
        public Order MyOrder { get; set; } = new();
        public Product Product { get; set; } = new();

        //public int Quantity { get; set; } = 1;  //значення за-замовчуванням. Тут коментую, бо прописано в FluentAPI
        public int Quantity { get; set; }
    }
}
