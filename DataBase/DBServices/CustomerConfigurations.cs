using DataBase.Entities;
using Microsoft.EntityFrameworkCore; 
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.DBServices
{
    public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey("Id");
            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.Phone).HasMaxLength(9).HasColumnName("CustomerPhone"); //  перейменувати поле, щоб в БД називалось по-іншому
            builder.Property(p => p.EMail).HasMaxLength(25);

            //зв'язок таблиць, один до багатьох (один кастомер - багато замовлень)
            builder.HasMany(c => c.Orders)
                   .WithOne(o => o.Customer)
                   .HasForeignKey(o => o.CustomerID);

        }
    }
}
