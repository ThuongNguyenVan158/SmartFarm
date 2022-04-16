using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartFarm.Data.Entities;

namespace SmartFarm.Data
{
    public class InputConfiguration : IEntityTypeConfiguration<Input>
    {
        public void Configure(EntityTypeBuilder<Input> builder)
        {
            builder.ToTable("INPUT");
            builder.HasKey(input => new{input.Id,input.LoaiThietBi});
            builder.Property(input => input.Max);
            builder.Property(input => input.Min);
            builder.Property(input => input.ThoiGianTruyXuat);
            builder.Property(input => input.FeedName);
            builder.Property(input => input.DonVi);
            builder.Property(input => input.Calculator);
            builder.HasOne(equipment => equipment.Equipment)
                .WithMany(input => input.Input)
                .HasForeignKey(input => input.Id);
        }
    }
}
