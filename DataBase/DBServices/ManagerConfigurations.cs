using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.DBServices
{
    public class ManagerConfigurations : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();//щоб гуід автогенерувався
            builder.Property(p => p.FirstName).HasMaxLength(50);
            builder.Property(p => p.LastName).HasMaxLength(50);
        }
    }
}
