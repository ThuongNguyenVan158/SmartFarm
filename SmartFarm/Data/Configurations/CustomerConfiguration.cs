using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartFarm.Data.Entities;

namespace SmartFarm.Data
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("CUSTOMER");
            builder.HasKey(customer => customer.Id);
            builder.Property(customer => customer.Ten);
            builder.Property(customer => customer.Ho);
            builder.Property(customer => customer.DiaChi);
            builder.Property(customer => customer.SoHuuTrangTrai);
            builder.Property(customer => customer.VaiTro);
            builder.Property(customer => customer.TrangThai);
            builder.Property(customer => customer.Image);
            builder.HasOne(farm => farm.Farm)
                .WithMany(customer => customer.Customers)
                .HasForeignKey(customer=>customer.SoHuuTrangTrai);
        }
    }
}
