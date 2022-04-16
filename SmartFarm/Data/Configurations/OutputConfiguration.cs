using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartFarm.Data.Entities;

namespace SmartFarm.Data
{
    public class OutputConfiguration : IEntityTypeConfiguration<Output>
    {
        public void Configure(EntityTypeBuilder<Output> builder)
        {
            builder.ToTable("OUTPUT");
            builder.HasKey(output => output.Id);
            builder.Property(output => output.TrangThaiHoatDong);
            builder.Property(output => output.FeedName);
            builder.Property(output => output.ValueOpen);
            builder.Property(output =>output.Auto);
            builder.HasOne(equipment => equipment.Equipment)
                .WithOne(output => output.Output)
                .HasForeignKey<Output>(output => output.Id);
        }
    }
}
