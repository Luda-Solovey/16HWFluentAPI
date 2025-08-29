using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.DBServices
{
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey("Id");// одне з перевантажень методу
            builder.Property(p => p.Id).ValueGeneratedOnAdd(); //щоб гуід автогенерувався
            builder.Property(p => p.Date).HasColumnType("datetime");  // змінити тип даних поля

            builder.Property(p => p.Date).HasDefaultValueSql("GETDATE()");
        }
    }
}
