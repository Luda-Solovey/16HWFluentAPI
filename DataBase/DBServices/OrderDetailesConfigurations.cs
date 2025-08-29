using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DBServices
{
    public class OrderDetailesConfigurations : IEntityTypeConfiguration<OrderDetailes>
    {
        public void Configure(EntityTypeBuilder<OrderDetailes> builder)
        {
            //builder.HasKey(od => new {od.MyOrder, od.Product});//приклад складеного ключа. Треба брати в якості типу даних прості типи (а не ссилочні)
            builder.HasKey(od => od.Id);

            builder.Property(prop => prop.Quantity).HasDefaultValue(1); //значення за-замовчуванням

        }
    }
}
