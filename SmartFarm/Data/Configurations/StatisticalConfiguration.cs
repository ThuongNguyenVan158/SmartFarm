using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartFarm.Data.Entities;

namespace SmartFarm.Data
{
    public class StatisticalConfiguration : IEntityTypeConfiguration<Statistical>
    {
        public void Configure(EntityTypeBuilder<Statistical> builder)
        {
            builder.ToTable("STATISTICAL");
            builder.HasKey(statistical => statistical.Id);
            builder.Property(statistical => statistical.TenThongKe);
            builder.Property(statistical => statistical.LoaiThongKe);
            builder.Property(statistical => statistical.MoTaThongKe);
        }
    }
}
