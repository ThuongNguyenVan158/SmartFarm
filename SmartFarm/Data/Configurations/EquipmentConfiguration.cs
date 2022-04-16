using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartFarm.Data.Entities;

namespace SmartFarm.Data
{
    public class EquipmentConfiguration: IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.ToTable("EQUIPMENT");
            builder.HasKey(equipment => equipment.Id);
            builder.Property(equipment => equipment.Ten);
            builder.Property(equipment => equipment.Image);
            builder.Property(equipment => equipment.Loai);
            builder.Property(equipment => equipment.ThuocVeTrangTrai);
            builder.Property(equipment => equipment.ThongTin);
            builder.Property(equipment => equipment.TrangThai);
            builder.Property(equipment => equipment.ViTriDat);
            builder.Property(equipment => equipment.ThongTin);
            builder.HasOne(farm => farm.Farm)
                .WithMany(equipment => equipment.Equipments)
                .HasForeignKey(equipment => equipment.ThuocVeTrangTrai);
        }
    }
}
