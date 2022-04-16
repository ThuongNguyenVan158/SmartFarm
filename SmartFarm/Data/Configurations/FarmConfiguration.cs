using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartFarm.Data.Entities;

namespace SmartFarm.Data
{
    public class FarmConfiguration : IEntityTypeConfiguration<Farm>
    {
        public void Configure(EntityTypeBuilder<Farm> builder)
        {
            builder.ToTable("FARM");
            builder.HasKey(farm => farm.Id);
            builder.Property(farm => farm.Ten);
            builder.Property(farm => farm.DiaDiem);
            builder.Property(farm => farm.AioKey);
        }
    }
}
