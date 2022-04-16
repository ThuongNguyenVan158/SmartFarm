using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartFarm.Data.Entities;

namespace SmartFarm.Data
{
    public class InputOutputConfiguration : IEntityTypeConfiguration<InputOutput>
    {

        public void Configure(EntityTypeBuilder<InputOutput> builder)
        {
            builder.ToTable("INPUTOUTPUT");
            builder.HasKey(a => new {a.IdInput,a.IdOutput,a.LoaiThietBiInput});
            builder.HasOne(a => a.Input)
                    .WithMany(input => input.InputOutputs)
                    .HasForeignKey(a => new{a.IdInput,a.LoaiThietBiInput})
                    .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(a => a.Output)
                    .WithMany(input => input.InputOutputs)
                    .HasForeignKey( a => a.IdOutput)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
