using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.DBServices
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
             builder.Property(p => p.RawPrice).HasComputedColumnSql("(PriceWithNDS * 1,2)");// значення буде вираховуватись за вказаною формулою
        }
    }
}
