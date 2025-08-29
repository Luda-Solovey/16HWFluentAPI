using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Entities
{
    public class Order
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        //[Column(TypeName = "DateTime")]//в БД це поле буде створено як DateTime
        public DateTime Date { get; set; }
        public string? Description { get; set; }

        //[ForeignKey()]
        //для того, щоб уникнути зайвих join-ів в БД
        //створюємо в класі властивості-первичні_ключі
        //тип властивості повинен бути такий, який тип Id-властивості (первинного ключа )
        public Guid? CustomerID { get; set; }
        public Customer? Customer { get; set; }//навігаційна властивість

        //для того, щоб уникнути зайвих join-ів в БД
        //створюємо в класі властивості-первичні_ключі
        //тип властивості повинен бути такий, який тип Id-властивості (первинного ключа )
        public Guid ManagerId { get; set; }
        public Manager Manager { get; set; } = null!;//навігаційна властивість
        public List<OrderDetailes> OrderDetailes { get; set; } = new List<OrderDetailes>(); //навігаційна властивість

        public decimal? GetSum()
        {
            var sum = OrderDetailes.Sum(od => od.Quantity * od.Product.PriceWithNDS);
            return sum;
        }
    }
}
